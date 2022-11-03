using XUI.Core;

namespace XUI.App
{
    public partial class Form1 : Form
    {
        CustomWebView2 customWebView2;
        public Form1()
        {
            InitializeComponent();
            //����WebView2���������ӵ�Form����
            customWebView2 = new CustomWebView2();
            customWebView2.Dock = DockStyle.Fill;
            Controls.Add(customWebView2);
            //��ʼ��webview
            customWebView2.Init().ContinueWith(r => {
                //������ҳ
                this.Invoke(() => customWebView2.CoreWebView2.Navigate(Path.GetFullPath("views/dashboard.html")));

            });
            
        }
    }
}