using AutoMapper;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Models;

namespace Build_IT_Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Script, ScriptResource>();
            CreateMap<Tag, TagResource>();
            CreateMap<Parameter, ParameterResource>();
            CreateMap<ValueOption, ValueOptionResource>();
            CreateMap<AlternativeScript, AlternativeScriptResource>();
        }
    }
}
