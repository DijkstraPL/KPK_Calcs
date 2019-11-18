using Build_IT_Application.Exceptions;
using Build_IT_Data.Entities.Application;
using Build_IT_DataAccess.Application;
using Build_IT_DataAccess.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.Application.User.Commands.GetToken
{
    [JsonObject(MemberSerialization.OptOut)]
    public class TokenRequestCommand : IRequest<TokenResponseQuery>
    {
        #region Properties

        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string refresh_token { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<TokenRequestCommand, TokenResponseQuery>
        {
            private ApplicationDbContext _dbContext;
            private RoleManager<IdentityRole> _roleManager;
            private UserManager<ApplicationUser> _userManager;
            private IConfiguration _configuration;
            private JsonSerializerSettings _jsonSettings;
            private SignInManager<ApplicationUser> _signInManager;
            private IApplicationUnitOfWork _unitOfWork;

            public Handler(
                ApplicationDbContext context,
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager,
                SignInManager<ApplicationUser> signInManager,
                IApplicationUnitOfWork unitOfWork,
                IConfiguration configuration
            )
            {
                _dbContext = context;
                _roleManager = roleManager;
                _userManager = userManager;
                _unitOfWork = unitOfWork;
                _configuration = configuration;

                // Utwórz pojedynczy obiekt JsonSerializerSettings,
                // który może być używany wielokrotnie
                _jsonSettings = new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                };

                _signInManager = signInManager;
            }

            public async Task<TokenResponseQuery> Handle(TokenRequestCommand request, CancellationToken cancellationToken)
            {
                if (request == null)
                    throw new BadRequestException(nameof(TokenRequestCommand), request);

                switch (request.grant_type)
                {
                    case "password":
                        return await GetToken(request);
                    case "refresh_token":
                        return await RefreshToken(request);
                    default:
                        throw new UnauthorizedAccessException();
                }
            }

            private async Task<TokenResponseQuery> GetToken(TokenRequestCommand request)
            {
                try
                {
                    // Sprawdź, czy istnieje użytkownik o podanej nazwie
                    var user = await _userManager.FindByNameAsync(request.username);
                    // Dopóść użycie adresu e-mail w zastępstwie nazwy użytkownika
                    if (user == null && request.username.Contains("@"))
                        user = await _userManager.FindByEmailAsync(request.username);

                    if (user == null
                        || !await _userManager.CheckPasswordAsync(user, request.password))
                    {
                        // Użytkownik nie istnieje lub hasła nie pasują do siebie
                        throw new UnauthorizedAccessException();
                    }

                    // Nazwa użytkownika i hasło jest prawidłowe - utwórz tokeny
                    var rt = CreateRefreshToken(request.client_id, user.Id);

                    // Dodaj nowy tokoen odświeżania do bazy danych
                    _dbContext.Tokens.Add(rt);
                    await _unitOfWork.CompleteAsync();

                    // Utwórz i zwróć token dostępowy
                    return CreateAccessToken(user.Id, rt.Value);

                }
                catch
                {
                    throw new UnauthorizedAccessException();
                }
            }

            private async Task<TokenResponseQuery> RefreshToken(TokenRequestCommand request)
            {
                try
                {
                    // Sprawdź, czy otrzymany token oświeżenia istnieje dla danego clientId
                    var rt = _dbContext.Tokens
                        .FirstOrDefault(t =>
                        t.ClientId == request.client_id
                        && t.Value == request.refresh_token);

                    if (rt == null)
                    {
                        // Token nie istnieje lub jest niepoprawny (albo przekazano złe clientId)
                        throw new UnauthorizedAccessException();
                    }

                    // Sprawdź, czy istnieje użytkownik o userId z tokena odświeżenia
                    var user = await _userManager.FindByIdAsync(rt.ApplicationUserId);

                    if (user == null)
                    {
                        // Użytkownika nie odnaleziono lub UserId jest nieprawidłowe
                        throw new UnauthorizedAccessException();
                    }

                    // Wygeneruj nowy token odświeżania
                    var rtNew = CreateRefreshToken(rt.ClientId, rt.ApplicationUserId);

                    // Unieważnij stary token odświeżania (poprzez jego usunięcie)
                    _dbContext.Tokens.Remove(rt);

                    // Dodaj nowy token odświeżania
                    _dbContext.Tokens.Add(rtNew);

                    // Zapisz zmiany w bazie danych
                    await _unitOfWork.CompleteAsync();

                    // Utwórz nowy token dostępowy
                    return CreateAccessToken(rtNew.ApplicationUserId, rtNew.Value);
                    // ... i wyślij go do klienta
                }
                catch
                {
                    throw new UnauthorizedAccessException();
                }
            }

            private Token CreateRefreshToken(string clientId, string userId)
            {
                return new Token()
                {
                    ClientId = clientId,
                    ApplicationUserId = userId,
                    Type = 0,
                    Value = Guid.NewGuid().ToString("N"),
                    CreatedDate = DateTime.UtcNow
                };
            }

            private TokenResponseQuery CreateAccessToken(string userId, string refreshToken)
            {
                DateTime now = DateTime.UtcNow;

                // Dodaj odpowiednie roszczenia do JWT (RFC7519).
                // Więcej informacji znajdziesz pod adresem https://tools.ietf.org/html/rfc7519#section-4.1
                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(now).ToUnixTimeSeconds().ToString())
                // NA-POZNIEJ: dodaj dodatkowe roszczenia
            };

                var tokenExpirationMins =
                    _configuration.GetValue<int>("Auth:Jwt:TokenExpirationInMinutes");
                var issuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Auth:Jwt:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Auth:Jwt:Issuer"],
                    audience: _configuration["Auth:Jwt:Audience"],
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(tokenExpirationMins)),
                    signingCredentials: new SigningCredentials(
                        issuerSigningKey, SecurityAlgorithms.HmacSha256)
                );
                var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

                return new TokenResponseQuery()
                {
                    token = encodedToken,
                    expiration = tokenExpirationMins,
                    refresh_token = refreshToken
                };
            }
        }
    }
}
