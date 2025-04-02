using System.ComponentModel.Composition;
using Mendix.StudioPro.ExtensionsAPI.UI.DockablePane;
using Mendix.StudioPro.ExtensionsAPI.UI.Services;

namespace SprintrExtension
{
    [Export(typeof(DockablePaneExtension))]//Export the file as a dockable pane
    public class SprintrLogPaneExtension : DockablePaneExtension
    {
        private readonly IAppService _appService;

        // Constructor to inject IAppService
        [ImportingConstructor]
        public SprintrLogPaneExtension(IAppService appService)
        {
            _appService = appService;
        }

        public const string ID = "sprintr-log-pane"; // Define an ID
        public override string Id => ID; // Override ID with id


        public override DockablePaneViewModelBase Open()
        {
            var newPane = new MyDockablePaneExtensionWebViewModel("https://cloud-logs.home.mendix.com/link/logs/" + _appService.GetOnlineAppIDForCurrentAppAsync().Result); // Open a URL using a WebViewModel
            newPane.Title = "Logs";
            return newPane;
        }
    }
}
