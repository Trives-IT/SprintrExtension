using Mendix.StudioPro.ExtensionsAPI.Model;
using Mendix.StudioPro.ExtensionsAPI.Model.DataTypes;
using Mendix.StudioPro.ExtensionsAPI.Model.Microflows;
using Mendix.StudioPro.ExtensionsAPI.Model.Projects;
using Mendix.StudioPro.ExtensionsAPI.Services;
using Mendix.StudioPro.ExtensionsAPI.UI.Services;
using Mendix.StudioPro.ExtensionsAPI.VersionControl;
using System.ComponentModel.Composition;

namespace SprintrExtension;

[Export(typeof(ModelVersionChecker))]
[method: ImportingConstructor]
class ModelVersionChecker(IMicroflowService microflowService, IMicroflowExpressionService microflowExpressionService, IVersionControlService versionControlService)
{

    public IBranch GetCurrentBranch(IModel currentApp)
    {
        return versionControlService.GetCurrentBranch(currentApp);
    }

    public ICommit GetCurrentVersion(IModel currentApp)
    {
        return versionControlService.GetHeadCommit(currentApp, GetCurrentBranch(currentApp));
    }



}