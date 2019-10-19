using Build_IT_Application.ScriptInterpreter.Scripts.Queries;

namespace Build_IT_Application.ScriptInterpreter.Groups.Queries
{
    public class GroupResource
    {
        #region Properties
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string VisibilityValidator { get; set; }
        public ScriptResource Script { get; set; }

        #endregion // Properties
    }
}