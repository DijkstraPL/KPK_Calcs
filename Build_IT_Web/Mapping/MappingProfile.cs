using AutoMapper;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_Web.Controllers.Resources;
using System;
using System.Collections.ObjectModel;
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
            CreateMap<Parameter, ParameterResource>()
                .ForMember(p => p.Equation, operation => operation.Ignore());
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
                .ForMember(p => p.ScriptId, operation => operation.Ignore())
                .ForMember(s => s.ValueOptions, operation => operation.Ignore())
                .AfterMap((pr, p) =>
                {
                    if (pr.ValueOptions == null)
                        pr.ValueOptions = new Collection<ValueOptionResource>();
                    UpdateValueOptions(pr, p);
                    RemoveNotAddedValueOptions(pr, p);
                    AddNewValueOptions(pr, p);
                });
            CreateMap<ValueOptionResource, ValueOption>()
                .ForMember(vo => vo.Id, operation => operation.Ignore())
                .ForMember(vo => vo.Parameter, operation => operation.Ignore())
                .ForMember(vo => vo.ParameterId, operation => operation.Ignore());
        }

        private void UpdateValueOptions(ParameterResource parameterResource, Parameter parameter)
        {
            foreach (var valueOptionResource in parameterResource.ValueOptions)
            {
                var valueOption = parameter.ValueOptions.FirstOrDefault(vo => vo.Id == valueOptionResource.Id);
                if (valueOption == null)
                    continue;
                valueOption.Value = valueOptionResource.Value;
                valueOption.Description = valueOptionResource.Description;
            }
        }

        private void RemoveNotAddedValueOptions(ParameterResource parameterResource, Parameter parameter)
        {
            var removedValueOptions = parameter.ValueOptions.Where(vo =>
            !parameterResource.ValueOptions.Select(vor => vor.Id).Contains(vo.Id)).ToList();
            foreach (var valueOption in removedValueOptions)
                parameter.ValueOptions.Remove(valueOption);
        }

        private void AddNewValueOptions(ParameterResource parameterResource, Parameter parameter)
        {
            var addedValueOptions = parameterResource.ValueOptions
                .Where(vor => !parameter.ValueOptions.Any(vo => vo.Id == vor.Id))
                 .Select(vor => 
                 new ValueOption { Description = vor.Description, Value = vor.Value }
                 ).ToList();
            foreach (var valueOption in addedValueOptions)
                parameter.ValueOptions.Add(valueOption);
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
            var addedTags = scriptResource.Tags.Where(tr => !script.Tags.Any(t => t.TagId == tr.Id))
                 .Select(tr => new ScriptTag { TagId = tr.Id }).ToList();
            foreach (var tag in addedTags)
                script.Tags.Add(tag);
        }
    }
}
