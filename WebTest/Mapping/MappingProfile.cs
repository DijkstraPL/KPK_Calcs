using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest.Controllers.Resources;
using WebTest.Models;

namespace WebTest.Mapping
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
