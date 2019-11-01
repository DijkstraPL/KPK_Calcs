using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
using Build_IT_Application.ScriptInterpreter.TestDatas.Queries;
using Build_IT_Data.Entities.Scripts;
using System.Collections.Generic;

namespace Build_IT_Application.Mapping
{
    public interface IScriptMappingProfile
    {
        #region Public_Methods
        
        void UpdateValueOptions(ICollection<ValueOptionResource> valueOptionsResource, Parameter parameter);
        void RemoveNotAddedValueOptions(ICollection<ValueOptionResource> valueOptionsResource, Parameter parameter);
        void AddNewValueOptions(ICollection<ValueOptionResource> valueOptionsResource, Parameter parameter);

        void RemoveNotAddedAssertions(ICollection<AssertionResource> assertionsResource, TestData testData);
        void AddNewAssertions(ICollection<AssertionResource> assertionsResources, TestData testData);
        void UpdateAssertions(ICollection<AssertionResource> assertionsResource, TestData testData);

        void UpdateTestParameters(ICollection<TestParameterResource> testParametersResource, TestData testData);
        void RemoveNotAddedTestParameters(ICollection<TestParameterResource> testParametersResource, TestData testData);
        void AddNewTestParameters(ICollection<TestParameterResource> testParametersResource, TestData testData);

        #endregion // Public_Methods
    }
}