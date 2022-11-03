using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.InteropServices;
using Timer = System.Timers.Timer;

namespace XUI.Core
{
    public class CustomWebView2 : WebView2
    {
        Timer timer;
        public CustomWebView2()
        {
        }
        public async Task Init()
        {
            //webview2初始化
            await this.EnsureCoreWebView2Async();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += (s, e) =>
            {
                //每一秒发送一次当前时间
                this.Invoke(() => this.CoreWebView2.PostWebMessageAsString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            };
            timer.Start();
            //注册WebMessage接收处理程序，接收前端发送过来的暂停或继续命令
            this.CoreWebView2.WebMessageReceived += (s, e) =>
            {
                string command = e.WebMessageAsJson;
                if (command == "0")
                {
                    this.CoreWebView2.PostWebMessageAsString("已暂停");
                    timer.Stop();
                }
                else if (command == "1")
                {
                    timer.Start();
                }

            };

            this.CoreWebView2.AddHostObjectToScript("native", new Native(this));
        }
        [ClassInterface(ClassInterfaceType.None)]
        [ComVisible(true)]
        public class Native
        {

            CustomWebView2 webView;
            public Native(CustomWebView2 webView2)
            {
                this.webView = webView2;
            }

            public void ShowMessageBox(string content)
            {
                MessageBox.Show(content);
            }
            public void CallAlert()
            {
                var script = @"alert('消息来自C#执行JS alert方法')";
                webView.ExecuteScriptAsync(script);
            }

            public string GetSystemInfo()
            {
                return
                    $"OSVersion:{Environment.OSVersion}\r\n" +
                    $"MachineName:{Environment.MachineName}\r\n" +
                    $"SystemDirectory:{Environment.SystemDirectory}"
                    ;

            }

            public string SolveMessage(string messageAsJson)
            {
                Message message = null;
                try
                {
                    message = JsonConvert.DeserializeObject<Message>(messageAsJson);
                    string controller = message.Controller;
                    string action = message.Action;

                    string typePath = "XUI.App.Controllers." + controller;
                    Assembly assembly = Assembly.Load("XUI.App");
                    var controllerInstance = assembly.CreateInstance(typePath) as Controller;
                    
                    var result = controllerInstance?.InvokeAction(action, message).Result;
                    
                    if (result is FilterResult filterResult)
                    {
                        switch (filterResult.Type)
                        {
                            case FilterResultType.Redirect:
                                {
                                    var path = Path.GetFullPath(filterResult.Data as string);
                                    webView.CoreWebView2.Navigate(path);
                                    break;
                                }
                            case FilterResultType.NotAllow:
                                {
                                    //不被允许
                                    //用途以后再将
                                    break;
                                }
                            default: break;

                        }
                    }
                    else if (result is ActionResult actionResult)
                    {
                        if (actionResult.Type == ActionResultType.Data)
                        {
                            message.Data = actionResult.Data;
                            return JsonConvert.SerializeObject(message, new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });
                        }
                    }


                    return "{}";

                }
                catch (Exception ex)
                {
                    if (message != null)
                    {
                        message.Data = ActionResult.StatusFalseResult(ex.Message).Data;
                        return JsonConvert.SerializeObject(message, new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });
                    }
                    return "{}";
                }
            }
        }
    }
}