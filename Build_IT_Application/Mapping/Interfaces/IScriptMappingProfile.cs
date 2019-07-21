using Build_IT_Application.ScriptInterpreter.Parameters.Queries;
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

        #endregion // Public_Methods
    }
}