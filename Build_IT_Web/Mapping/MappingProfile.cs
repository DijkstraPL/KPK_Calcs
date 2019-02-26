using AutoMapper;
using Build_IT_Web.Controllers.Resources;
using Build_IT_Web.Core.Models;
using System;
using System.Linq;

namespace Build_IT_Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain Resource to API
            CreateMap<Script, ScriptResource>()
                .ForMember(svm => svm.Tags, operation => operation.MapFrom(s => s.Tags.Select(st => st.Tag)));
            CreateMap<Tag, TagResource>();
            CreateMap<Parameter, ParameterResource>();
            CreateMap<ValueOption, ValueOptionResource>();
            CreateMap<AlternativeScript, AlternativeScriptResource>();

            // API Resource to Domain
            CreateMap<ScriptResource, Script>()
                .ForMember(s => s.Id, operation => operation.Ignore())
                .ForMember(s => s.Tags, operation => operation.Ignore())
                .AfterMap((sr, s) =>
                {
                    RemoveNotAddedTags(sr, s);
                    AddNewTags(sr, s);
                });
            CreateMap<TagResource, Tag>();
            CreateMap<ParameterResource, Parameter>()
                .ForMember(p => p.Script, operation => operation.Ignore())
                .ForMember(p => p.ScriptId, operation => operation.Ignore());
            CreateMap<ValueOptionResource, ValueOption>();
        }

        private void RemoveNotAddedTags(ScriptResource scriptResource, Script script)
        {
            var removedTags = script.Tags.Where(t =>
            !scriptResource.Tags.Select(tr => tr.Id).Contains(t.TagId)).ToList();
            foreach (var tag in removedTags)
                script.Tags.Remove(tag);
        }

        private void AddNewTags(ScriptResource scriptResource, Script script)
        {
            var addedTags = scriptResource.Tags.Where(tvm => !script.Tags.Any(t => t.TagId == tvm.Id))
                 .Select(tvm => new ScriptTag { TagId = tvm.Id }).ToList();
            foreach (var tag in addedTags)
                script.Tags.Add(tag);
        }
    }
}
