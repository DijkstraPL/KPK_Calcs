using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts.Interfaces;
using System;

namespace Build_IT_ScriptInterpreter.Scripts
{
    public class ScriptBuilder
    {
        #region Fields

        private readonly Script _script;

        #endregion // Fields

        #region Events

        public event EventHandler Modification;

        #endregion // Events

        #region Factories

        public static ScriptBuilder Create(string name, string description, params string[] tags)
        {
            var sb = new ScriptBuilder();
            sb.SetName(name)
              .SetDescription(description)
              .AppendTags(tags);

            return sb;
        }

        #endregion // Factories

        #region Constructors
        
        private ScriptBuilder()
        {
            _script = new Script
            {
                Added = DateTime.Now
            };
            Modification += OnModification;
        }

        #endregion // Constructors

        #region Destructor

        ~ScriptBuilder()
        {
            Modification -= OnModification;
        }

        #endregion // Destructor

        #region Public_Methods

        public IScript Build() => _script;

        public ScriptBuilder SetName(string name)
        {
            _script.Name = name;
            Modification(this, EventArgs.Empty);
            return this;
        }

        public ScriptBuilder SetDescription(string description)
        {
            _script.Description = description;
            Modification(this, EventArgs.Empty);
            return this;
        }

        public ScriptBuilder SetGroupName(string groupName)
        {
            _script.GroupName = groupName;
            Modification(this, EventArgs.Empty);
            return this;
        }

        public ScriptBuilder SetAuthor(string author)
        {
            _script.Author = author;
            Modification(this, EventArgs.Empty);
            return this;
        }

        public ScriptBuilder SetDocument(string documentName)
        {
            _script.AccordingTo = documentName;
            Modification(this, EventArgs.Empty);
            return this;
        }

        public ScriptBuilder SetNotes(string note)
        {
            _script.Notes = note;
            Modification(this, EventArgs.Empty);
            return this;
        }

        public ScriptBuilder AppendTags(params string[] tags)
        {
            foreach (var tag in tags)
                _script.Tags.Add(tag);
            Modification(this, EventArgs.Empty);
            return this;
        }

        public ScriptBuilder AppendParameter(IParameter parameter)
        {
            _script.Parameters.Add(parameter);
            Modification(this, EventArgs.Empty);
            return this;
        }

        public ScriptBuilder AppendParameters(params IParameter[] parameters)
        {
            foreach (var parameter in parameters)
                _script.Parameters.Add(parameter);
            Modification(this, EventArgs.Empty);
            return this;
        }

        #endregion // Public_Methods

        #region Private_Methods

        private void OnModification(object sender, EventArgs e)
        {
            _script.Modified = DateTime.Now;
        }

        #endregion // Private_Methods
    }
}
