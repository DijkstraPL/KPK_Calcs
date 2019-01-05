using Build_IT_ScriptInterpreter.Parameters;
using Build_IT_ScriptInterpreter.Parameters.Interfaces;
using Build_IT_ScriptInterpreter.Scripts.Interfaces;
using System;

namespace Build_IT_ScriptInterpreter.Scripts
{
    public class ScriptBuilder
    {
        private readonly Script _script;

        public event EventHandler Modification;

        public static ScriptBuilder Create(string name, string description, params string[] tags)
        {
            var sb = new ScriptBuilder();
            sb.SetName(name)
              .SetDescription(description)
              .AppendTags(tags);

            return sb;
        }

        private ScriptBuilder()
        {
            _script = new Script();
            _script.Added = DateTime.Now;
            Modification += OnModification;
        }

        ~ScriptBuilder()
        {
            Modification -= OnModification;
        }

        private void OnModification(object sender, EventArgs e)
        {
            _script.Modified = DateTime.Now;
        }

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

        public ScriptBuilder AppendParameter(Parameter parameter)
        {
            _script.Parameters.Add(parameter);
            Modification(this, EventArgs.Empty);
            return this;
        }

        public ScriptBuilder AppendParameters(params Parameter[] parameters)
        {
            foreach (var parameter in parameters)
                _script.Parameters.Add(parameter);
            Modification(this, EventArgs.Empty);
            return this;
        }
    }
}
