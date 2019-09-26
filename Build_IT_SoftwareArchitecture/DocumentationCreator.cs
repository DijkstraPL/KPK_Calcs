using Structurizr;
using Structurizr.Documentation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Build_IT_SoftwareArchitecture
{
    public class DocumentationCreator
    {
        #region Fields
        
        private readonly Workspace _workspace;
        private readonly SoftwareSystem _softwareSystem;

        #endregion // Fields

        #region Constructors
        
        public DocumentationCreator(Workspace workspace, SoftwareSystem softwareSystem)
        {
            _workspace = workspace;
            _softwareSystem = softwareSystem;
        }

        #endregion // Constructors

        #region Public_Methods
        
        public void CreateDocumentation()
       {
            var template = new StructurizrDocumentationTemplate(_workspace);
            
            var documentationRoot = new DirectoryInfo( "Documents" + 
                Path.DirectorySeparatorChar + "Decisions");

            foreach (var fileInfo in documentationRoot.EnumerateFiles())
                template.AddSection(_softwareSystem, fileInfo.Name, fileInfo);
        }

        #endregion // Public_Methods
    }
}
