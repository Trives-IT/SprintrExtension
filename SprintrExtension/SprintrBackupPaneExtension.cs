using System.ComponentModel.Composition;
using Mendix.StudioPro.ExtensionsAPI.UI.DockablePane;
using Mendix.StudioPro.ExtensionsAPI.UI.Services;

namespace SprintrExtension
{
    [Export(typeof(DockablePaneExtension))]//Export the file as a dockable pane
    public class SprintrBackupPaneExtension : DockablePaneExtension
    {
        private readonly IAppService _appService;

        // Constructor to inject IAppService
        [ImportingConstructor]
        public SprintrBackupPaneExtension(IAppService appService)
        {
            _appService = appService;
        }

        public const string ID = "sprintr-backup-pane"; // Define an ID
        public override string Id => ID; // Override ID with id


        public override DockablePaneViewModelBase Open()
        {
            var newPane = new MyDockablePaneExtensionWebViewModel("https://cloud.home.mendix.com/link/backups/" + _appService.GetOnlineAppIDForCurrentAppAsync().Result); // Open a URL using a WebViewModel
            newPane.Title = "Backups";
            return newPane;
        }
    }
}
