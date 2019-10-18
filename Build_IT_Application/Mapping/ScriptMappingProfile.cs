using AutoMapper;
using Build_IT_Application.ScriptInterpreter.Figures.Queries;
using Build_IT_Application.ScriptInterpreter.Parameters.Commands.CreateParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries;
using Build_IT_Application.ScriptInterpreter.Tags.Queries;
using Build_IT_Application.ScriptInterpreter.Translations.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Translations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Build_IT_Application.Mapping
{
    public class ScriptMappingProfile : Profile, IScriptMappingProfile
    {
        #region Public_Methods

        public ScriptMappingProfile()
        {
            // Domain Resource to API
            CreateMap<Script, ScriptResource>()
                .ForMember(sr => sr.Tags, operation
                => operation.MapFrom(s => s.Tags.Select(st => st.Tag)));
            CreateMap<Tag, TagResource>();
            CreateMap<Group, GroupResource>();
            CreateMap<Parameter, ParameterResource>()
                .ForMember(p => p.Equation, operation => operation.Ignore())
                .ForMember(pr => pr.Figures, operation
                => operation.MapFrom(p => p.ParameterFigures.Select(pp => pp.Figure)));
            CreateMap<ValueOption, ValueOptionResource>();
            CreateMap<Figure, FigureResource>();
            CreateMap<ScriptTranslation, ScriptTranslationResource>();
            CreateMap<ParameterTranslation, ParameterTranslationResource>();
            CreateMap<ValueOptionTranslation, ValueOptionTranslationResource>();

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
            CreateMap<GroupResource, Group>();
            CreateMap<ParameterResource, Parameter>()
                .ForMember(p => p.Script, operation => operation.Ignore())
                .ForMember(p => p.ScriptId, operation => operation.Ignore())
                .ForMember(s => s.ValueOptions, operation => operation.Ignore())
                .AfterMap((pr, p) =>
                {
                    if (pr.ValueOptions == null)
                        pr.ValueOptions = new Collection<ValueOptionResource>();
                    UpdateValueOptions(pr.ValueOptions, p);
                    RemoveNotAddedValueOptions(pr.ValueOptions, p);
                    AddNewValueOptions(pr.ValueOptions, p);
                })
                .ForMember(p => p.ParameterFigures, operation => operation.Ignore())
                .AfterMap((pr, p) =>
                {
                    RemoveNotAddedPhotos(pr, p);
                    AddNewPhotos(pr, p);
                });
            CreateMap<ValueOptionResource, ValueOption>()
                .ForMember(vo => vo.Id, operation => operation.Ignore())
                .ForMember(vo => vo.Parameter, operation => operation.Ignore())
                .ForMember(vo => vo.ParameterId, operation => operation.Ignore());
            CreateMap<ScriptTranslationResource, ScriptTranslation>();
            CreateMap<ParameterTranslationResource, ParameterTranslation>();
            CreateMap<ValueOptionTranslationResource, ValueOptionTranslation>()
                .ForMember(vot => vot.ValueOption, operation => operation.Ignore());
        }

        public void UpdateValueOptions(ICollection<ValueOptionResource> valueOptionsResource, Parameter parameter)
        {
            foreach (var valueOptionResource in valueOptionsResource)
            {
                var valueOption = parameter.ValueOptions.FirstOrDefault(vo => vo.Id == valueOptionResource.Id);
                if (valueOption == null)
                    continue;
                valueOption.Name = valueOptionResource.Name;
                valueOption.Number = valueOptionResource.Number;
                valueOption.Value = valueOptionResource.Value;
                valueOption.Description = valueOptionResource.Description;
            }
        }

        public void RemoveNotAddedValueOptions(ICollection<ValueOptionResource> valueOptionsResource, Parameter parameter)
        {
            var removedValueOptions = parameter.ValueOptions.Where(vo =>
            !valueOptionsResource.Select(vor => vor.Id).Contains(vo.Id)).ToList();
            foreach (var valueOption in removedValueOptions)
                parameter.ValueOptions.Remove(valueOption);
        }

        public void AddNewValueOptions(ICollection<ValueOptionResource> valueOptionsResource, Parameter parameter)
        {
            var addedValueOptions = valueOptionsResource
                .Where(vor => !parameter.ValueOptions.Any(vo => vo.Id == vor.Id))
                 .Select(vor =>
                 new ValueOption { Name = vor.Name, Number = vor.Number, Description = vor.Description, Value = vor.Value }
                 ).ToList();
            foreach (var valueOption in addedValueOptions)
                parameter.ValueOptions.Add(valueOption);
        }

        #endregion // Public_Methods

        #region Private_Methods

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

        private void RemoveNotAddedPhotos(ParameterResource parameterResource, Parameter parameter)
        {
            var removedFigures = parameter.ParameterFigures
                .Where(pp => !parameterResource.Figures.Select(pr => pr.Id).Contains(pp.FigureId)).ToList();
            foreach (var figure in removedFigures)
                parameter.ParameterFigures.Remove(figure);
        }

        private void AddNewPhotos(ParameterResource parameterResource, Parameter parameter)
        {
            var addedFigures = parameterResource.Figures
                .Where(pr => !parameter.ParameterFigures.Any(pp => pp.FigureId == pr.Id))
                 .Select(pr => new ParameterFigure { FigureId = pr.Id }).ToList();
            foreach (var figure in addedFigures)
                parameter.ParameterFigures.Add(figure);
        }

        #endregion // Private_Methods
    }
}
