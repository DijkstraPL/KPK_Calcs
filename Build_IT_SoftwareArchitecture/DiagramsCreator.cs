using Structurizr;
using Structurizr.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_SoftwareArchitecture
{
    internal class DiagramsCreator
    {
        #region Fields
        
        private readonly Workspace _workspace;
        private readonly SoftwareSystem _softwareSystem;

        #endregion // Fields

        #region Constructors
        
        public DiagramsCreator(Workspace workspace, SoftwareSystem softwareSystem)
        {
            _workspace = workspace ?? throw new ArgumentNullException(nameof(workspace));
            _softwareSystem = softwareSystem ?? throw new ArgumentNullException(nameof(softwareSystem));
        }

        #endregion // Constructors

        #region Internal_Methods
        
        internal void CreateDiagrams()
        {
            ViewSet viewSet = CreateView();
            SetStyles(viewSet);
        }

        #endregion // Internal_Methods

        #region Private_Methods
        
        private ViewSet CreateView()
        {
            ViewSet viewSet = _workspace.Views;
            SystemContextView contextView = viewSet.CreateSystemContextView(_softwareSystem, "SystemContext", "Context for a system as a whole.");
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();
            return viewSet;
        }

        private void SetStyles(ViewSet viewSet)
        {
            Styles styles = viewSet.Configuration.Styles;
            styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#1168bd", Color = "#ffffff" });
            styles.Add(new ElementStyle(Tags.Person) { Background = "#08427b", Color = "#ffffff", Shape = Shape.Person });
        }

        #endregion // Private_Methods
    }
}
