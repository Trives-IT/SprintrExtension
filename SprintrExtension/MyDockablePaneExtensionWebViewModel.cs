using Mendix.StudioPro.ExtensionsAPI.UI.DockablePane;
using Mendix.StudioPro.ExtensionsAPI.UI.WebView;

namespace SprintrExtension
{
    internal class MyDockablePaneExtensionWebViewModel(string myURL) : WebViewDockablePaneViewModel//String myURL parameter passed in (your desired URL) + WebViewDockablePaneViewModel ->extensions API
    {
        public override void InitWebView(IWebView webView)
        {
            webView.Address = new Uri(myURL);//opens the url in the Webview
        }
    }
}
