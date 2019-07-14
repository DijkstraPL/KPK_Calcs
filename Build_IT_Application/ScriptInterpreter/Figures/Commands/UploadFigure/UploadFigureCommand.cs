using AutoMapper;
using Build_IT_Application.Exceptions;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.ScriptInterpreter.Figures.Commands.UploadFigure
{
    public class UploadFigureCommand : IRequest
    {
        #region Properties

        public long ParameterId { get; set; }
        public IFormFile File { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<UploadFigureCommand, Unit>
        {
            #region Fields

            private readonly IHostingEnvironment _host;
            private readonly IParameterRepository _parameterRepository;
            private readonly IScriptInterpreterUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly FigureSettings _photoSettings;

            #endregion // Fields

            #region Constructors

            public Handler(
                IHostingEnvironment host,
                IParameterRepository parameterRepository,
                IScriptInterpreterUnitOfWork unitOfWork,
                IMapper mapper,
                IOptionsSnapshot<FigureSettings> options)
            {
                _host = host;
                _parameterRepository = parameterRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _photoSettings = options.Value;
            }

            #endregion // Constructors

            #region Public_Methods

            public async Task<Unit> Handle(UploadFigureCommand request, CancellationToken cancellationToken)
            {
                var parameter = await _parameterRepository.GetAsync(request.ParameterId);
                if (parameter == null)
                    throw new NotFoundException(nameof(Figure), request.ParameterId);
                if (request.File == null)
                    throw new BadRequestException(nameof(Figure), "Null file");
                if (request.File.Length == 0)
                    throw new BadRequestException(nameof(Figure), "Empty file");
                if (request.File.Length > _photoSettings.MaxBytes)
                    throw new BadRequestException(nameof(Figure), "Max file size exceeded");
                if (!_photoSettings.IsSupported(request.File.FileName))
                    throw new BadRequestException(nameof(Figure), "Invalid file type");

                string uploadsFolderPath = Path.Combine(_host.WebRootPath, "clientapp", "uploads", "parameters");
                if (!Directory.Exists(uploadsFolderPath))
                    Directory.CreateDirectory(uploadsFolderPath);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.File.FileName);
                string filePath = Path.Combine(uploadsFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                }

                var figure = new Figure { FileName = fileName };
                var parameterPhoto = new ParameterFigure { Parameter = parameter, Figure = figure };
                parameter.ParameterFigures.Add(parameterPhoto);

                await _unitOfWork.CompleteAsync();

                return Unit.Value;
            }

            #endregion // Public_Methods
        }
    }
}
