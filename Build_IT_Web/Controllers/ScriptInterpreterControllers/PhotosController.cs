using AutoMapper;
using Build_IT_DataAccess.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Controllers.ScriptInterpreterControllers.Resources;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers.ScriptInterpreterControllers
{
    [Route("api/parameters/{parameterId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        #region Fields

        private readonly IHostingEnvironment _host;
        private readonly IParameterRepository _parameterRepository;
        private readonly IScriptInterpreterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PhotoSettings _photoSettings;

        #endregion // Fields

        #region Constructors

        public PhotosController(IHostingEnvironment host,
            IParameterRepository parameterRepository,
            IScriptInterpreterUnitOfWork unitOfWork,
            IMapper mapper,
            IOptionsSnapshot<PhotoSettings> options)
        {
            _host = host;
            _parameterRepository = parameterRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoSettings = options.Value;
        }

        #endregion // Constructors

        #region Public_Methods
        
        [HttpPost]
        public async Task<IActionResult> Upload(long parameterId, IFormFile file)
        {
            var parameter = await _parameterRepository.GetAsync(parameterId);
            if (parameter == null)
                return NotFound();
            if (file == null)
                return BadRequest("Null file");
            if (file.Length == 0)
                return BadRequest("Empty file");
            if (file.Length > _photoSettings.MaxBytes)
                return BadRequest("Max file size exceeded");
            if (!_photoSettings.IsSupported(file.FileName))
                return BadRequest("Invalid file type");

            string uploadsFolderPath = Path.Combine(_host.WebRootPath, "clientapp", "upload", parameterId.ToString());
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo { FileName = fileName };
            var parameterPhoto = new ParameterPhoto { Parameter = parameter, Photo = photo };
            parameter.ParameterPhotos.Add(parameterPhoto);

            await _unitOfWork.CompleteAsync();

            return Ok(_mapper.Map<Photo, PhotoResource>(photo));
        }

        #endregion // Public_Methods
    }
}