using System.ComponentModel.Composition;
using Mendix.StudioPro.ExtensionsAPI.UI.DockablePane;
using Mendix.StudioPro.ExtensionsAPI.UI.Services;

namespace SprintrExtension
{
    [Export(typeof(DockablePaneExtension))]//Export the file as a dockable pane
    public class SprintrTeamPaneExtension : DockablePaneExtension
    {
        private readonly IAppService _appService;

        // Constructor to inject IAppService
        [ImportingConstructor]
        public SprintrTeamPaneExtension(IAppService appService)
        {
            _appService = appService;
        }

        public const string ID = "sprintr-team-pane"; // Define an ID
        public override string Id => ID; // Override ID with id


        public override DockablePaneViewModelBase Open()
        {
            var newPane = new MyDockablePaneExtensionWebViewModel("https://sprintr.home.mendix.com/link/team/" + _appService.GetOnlineAppIDForCurrentAppAsync().Result); // Open a URL using a WebViewModel
            newPane.Title = "Team";
            return newPane;
        }
    }
}
