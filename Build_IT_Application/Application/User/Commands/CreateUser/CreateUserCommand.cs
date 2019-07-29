using Build_IT_Application.Exceptions;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Application;
using Build_IT_DataAccess.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.Application.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        #region Properties
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<CreateUserCommand>
        {
            #region Fields

            private readonly IDateTime _dateTime;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IApplicationUnitOfWork _unitOfWork;

            #endregion // Fields

            #region Constructors

            public Handler(
                IDateTime dateTime,
                UserManager<ApplicationUser> userManager,
                IApplicationUnitOfWork unitOfWork)
            {
                _dateTime = dateTime;
                _userManager = userManager;
                _unitOfWork = unitOfWork;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(request.UserName);
                if (user != null)
                    throw new  BadRequestException(nameof(CreateUserCommand), request.UserName);
                user = await _userManager.FindByEmailAsync(request.Email);
                if (user != null)
                    throw new BadRequestException(nameof(CreateUserCommand), request.Email);

                var now = _dateTime.Now;

                user = new ApplicationUser()
                {
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.UserName,
                    Email = request.Email,
                    DisplayName = request.DisplayName,
                    CreatedDate = now,
                    LastModifiedDate = now
                };

                await _userManager.CreateAsync(user, request.Password);

                await _userManager.AddToRoleAsync(user, "RegisteredUser");

                user.EmailConfirmed = true;
                user.LockoutEnabled = false;

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods

        }
    }
}
