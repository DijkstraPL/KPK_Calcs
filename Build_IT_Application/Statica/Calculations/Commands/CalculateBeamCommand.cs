using Build_IT_Application.Mapping.Interfaces;
using Build_IT_BeamStatica;
using Build_IT_BeamStatica.Factories;
using Build_IT_BeamStatica.Nodes.Interfaces;
using Build_IT_BeamStatica.Spans.Interfaces;
using Build_IT_Data.Materials;
using Build_IT_Data.Sections;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Build_IT_Application.Statica.Calculations.Commands
{
    public class CalculateBeamCommand : IRequest<BeamResultResource>
    {
        #region Properties

        public BeamDataResource InputData { get; set; }

        #endregion // Properties

        public class Handler : IRequestHandler<CalculateBeamCommand, BeamResultResource>
        {
            #region Fields

            private BeamCalculator _beamCalculator;
            private readonly IStaticaMappingProfile _staticaMappingProfile;

            #endregion // Fields

            #region Constructors

            public Handler(BeamCalculator beamCalculator, IStaticaMappingProfile staticaMappingProfile)
            {
                _beamCalculator = beamCalculator;
                _staticaMappingProfile = staticaMappingProfile;
            }

            #endregion // Constructors

            #region Public_Methods

            public Task<BeamResultResource> Handle(CalculateBeamCommand request, CancellationToken cancellationToken)
            {
                // _beamCalculator.BeamData = request.InputData;
                throw new NotImplementedException();
            }

            #endregion // Public_Methods
        }
    }
}
