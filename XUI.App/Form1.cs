using XUI.Core;

namespace XUI.App
{
    public partial class Form1 : Form
    {
        CustomWebView2 customWebView2;
        public Form1()
        {
            InitializeComponent();
            //创建WebView2组件，并添加到Form窗体
            customWebView2 = new CustomWebView2();
            customWebView2.Dock = DockStyle.Fill;
            Controls.Add(customWebView2);
            //初始化webview
            customWebView2.Init().ContinueWith(r => {
                //加载网页
                this.Invoke(() => customWebView2.CoreWebView2.Navigate(Path.GetFullPath("views/dashboard.html")));

            });
            
        }
    }
}