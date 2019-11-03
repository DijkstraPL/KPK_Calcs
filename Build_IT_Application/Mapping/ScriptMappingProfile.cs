using AutoMapper;
using Build_IT_Application.ScriptInterpreter.Figures.Queries;
using Build_IT_Application.ScriptInterpreter.Groups.Queries;
using Build_IT_Application.ScriptInterpreter.Parameters.Commands.CreateParameter;
using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Application.ScriptInterpreter.Scripts.Queries;
using Build_IT_Application.ScriptInterpreter.Tags.Queries;
using Build_IT_Application.ScriptInterpreter.TestDatas.Queries;
using Build_IT_Application.ScriptInterpreter.Translations.Queries;
using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Translations;
using System;
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
            CreateMap<TestData, TestDataResource>();
            CreateMap<Assertion, AssertionResource>();
            CreateMap<TestParameter, TestParameterResource>();
            CreateMap<Figure, FigureResource>();
            CreateMap<ScriptTranslation, ScriptTranslationResource>();
            CreateMap<GroupTranslation, GroupTranslationResource>();
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
            CreateMap<TestDataResource, TestData>()
                .ForMember(td => td.Script, operation => operation.Ignore())
                .ForMember(td => td.TestParameters, operation => operation.Ignore())
                .ForMember(td => td.Assertions, operation => operation.Ignore())
                .AfterMap((tdr, td) =>
                {
                    UpdateAssertions(tdr.Assertions, td);
                    RemoveNotAddedAssertions(tdr.Assertions, td);
                    AddNewAssertions(tdr.Assertions, td);
                })
                .AfterMap((tdr, td) =>
                {
                    UpdateTestParameters(tdr.TestParameters, td);
                    RemoveNotAddedTestParameters(tdr.TestParameters, td);
                    AddNewTestParameters(tdr.TestParameters, td);
                });
            CreateMap<AssertionResource, Assertion>();
            CreateMap<TestParameterResource, TestParameter>();
            CreateMap<ScriptTranslationResource, ScriptTranslation>();
            CreateMap<ParameterTranslationResource, ParameterTranslation>();
            CreateMap<GroupTranslationResource, GroupTranslation>();
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
        public void AddNewTestParameters(ICollection<TestParameterResource> testParametersResource, TestData testData)
        {
            var addedTestParameters = testParametersResource
                .Where(tpr => !testData.TestParameters.Any(tp => tp.Id == tpr.Id))
                 .Select(tpr =>
                 new TestParameter { Value = tpr.Value, ParameterId = tpr.ParameterId, TestDataId = tpr.TestDataId }
                 ).ToList();
            foreach (var testParameter in addedTestParameters)
                testData.TestParameters.Add(testParameter);
        }

        public void RemoveNotAddedTestParameters(ICollection<TestParameterResource> testParametersResource, TestData testData)
        {
            var removedTestParameters = testData.TestParameters.Where(tp =>
            !testParametersResource.Select(tpr => tpr.Id).Contains(tp.Id)).ToList();
            foreach (var testParameter in removedTestParameters)
                testData.TestParameters.Remove(testParameter);
        }

        public void UpdateTestParameters(ICollection<TestParameterResource> testParametersResource, TestData testData)
        {
            foreach (var testParameterResource in testParametersResource)
            {
                var testParameter = testData.TestParameters.FirstOrDefault(a => a.Id == testParameterResource.Id);
                if (testParameter == null)
                    continue;
                testParameter.Value = testParameterResource.Value;
            }
        }

        public void UpdateAssertions(ICollection<AssertionResource> assertionsResource, TestData testData)
        {
            foreach (var assertionResource in assertionsResource)
            {
                var assertion = testData.Assertions.FirstOrDefault(a => a.Id == assertionResource.Id);
                if (assertion == null)
                    continue;
                assertion.Value = assertionResource.Value;
            }
        }

        public void AddNewAssertions(ICollection<AssertionResource> assertionsResources, TestData testData)
        {
            var addedAssertions = assertionsResources
                .Where(ar => !testData.Assertions.Any(a => a.Id == ar.Id))
                 .Select(ar =>
                 new Assertion { Value = ar.Value, TestDataId = ar.TestDataId }
                 ).ToList();
            foreach (var assertion in addedAssertions)
                testData.Assertions.Add(assertion);
        }

        public void RemoveNotAddedAssertions(ICollection<AssertionResource> assertionsResource, TestData testData)
        {
            var removedAssertions = testData.Assertions.Where(a =>
            !assertionsResource.Select(ar => ar.Id).Contains(a.Id)).ToList();
            foreach (var assertion in removedAssertions)
                testData.Assertions.Remove(assertion);
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
