using AutoMapper;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Core;
using Build_IT_Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Build_IT_Web.Controllers
{
    [Route("api/scripts")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        private readonly IParameterRepository _parameterRepository;
        private readonly IMapper _mapper;

        public ParametersController(
            IParameterRepository parameterRepository, 
            IMapper mapper)
        {
            _parameterRepository = parameterRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}/editable_parameters")]
        public async Task<IEnumerable<ParameterResource>> GetEditableParameters(long id)
        {
            var parameters = await _parameterRepository.GetEditableParameters(id);

            return _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
        }

        [HttpGet("{id}/parameters")]
        public async Task<IEnumerable<ParameterResource>> GetAllParameters(long id)
        {
            var parameters = await _parameterRepository.GetAllParameters(id);

            return _mapper.Map<List<Parameter>, List<ParameterResource>>(parameters);
        }
    }
}
