using System.ComponentModel.Composition;
using Mendix.StudioPro.ExtensionsAPI.UI.Menu;
using Mendix.StudioPro.ExtensionsAPI.UI.Services;

namespace SprintrExtension


{
    [method: ImportingConstructor]
    [Export(typeof(MenuExtension))]
    internal class MyMenuExtension(IDockingWindowService dockingWindowService, IMessageBoxService messageBoxService, IVersionControlService versionControlService, IAppService appService) : MenuExtension
    {
        public override IEnumerable<MenuViewModel> GetMenus()
        {
            yield return new MenuViewModel("Home", () => dockingWindowService.OpenPane(SprintrHomePaneExtension.ID));
            yield return new MenuViewModel("Team", () => dockingWindowService.OpenPane(SprintrTeamPaneExtension.ID));
            yield return new MenuViewModel("Settings", () => dockingWindowService.OpenPane(SprintrSettingsPaneExtension.ID));
            yield return new MenuViewModel("Environments" , () => dockingWindowService.OpenPane(SprintrEnvironmentsPaneExtension.ID));
            yield return new MenuViewModel("Logs", () => dockingWindowService.OpenPane(SprintrLogPaneExtension.ID));
            yield return new MenuViewModel("Backups", () => dockingWindowService.OpenPane(SprintrBackupPaneExtension.ID));
        }
    }
}



