### 截屏
![截屏](https://raw.githubusercontent.com/wnf0000/xui/master/screenshot20221210_135124.jpg)
![截屏](https://raw.githubusercontent.com/wnf0000/xui/master/screenshot20221210_135234.jpg)
![截屏](https://raw.githubusercontent.com/wnf0000/xui/master/screenshot20221210_135300.jpg)
![截屏](https://raw.githubusercontent.com/wnf0000/xui/master/screenshot20221210_135327.jpg)
![截屏](https://raw.githubusercontent.com/wnf0000/xui/master/screenshot20221210_135517.jpg)
![截屏](https://raw.githubusercontent.com/wnf0000/xui/master/screenshot20221210_140038.jpg)
### 示例程序源代码请下载[xui.sample.zip](https://raw.githubusercontent.com/wnf0000/xui/master/XUI.Sample.zip)压缩包
# 内置xui对象说明
```
xui.invokeAction = async function (controller, action, data) {
        //调用Controller里的方法
        //controller:Controller名称
        //action:方法名称
        //data:参数对象
    }
    xui.invokeActionWithCallback = async function (controller, action, data, callback) {
        //异步调用Controller里的方法
        //controller:Controller名称
        //action:方法名称
        //data:参数对象
        //callback回调函数
    }
    xui.addEventListener = function (eventType, listener) {
        //添加事件监听
    }
    xui.raiseEvent = function (eventType, dataObj) {
        //触发事件
    }
    xui.newGuid = async function (format) {
        //获取新Guid
    }

    xui.openUrl = async function (url, features, onTitleBarInited = null, windowId = null) {
        //在新窗口打开Url
        //返回值:窗口的Id
        //url:url地址
        //features:窗口特性对象
        //onTitleBarInited:窗口标题栏初始化完成后执行函数
        //windowId:指定窗口Id
    }
    xui.openHtml = async function (html, features, onTitleBarInited = null, windowId = null) {
        //在新窗口显示HTML
        //返回值:窗口的Id
        //html:HTML代码
        //features:窗口特性对象
        //onTitleBarInited:窗口标题栏初始化完成后执行函数
        //windowId:指定窗口Id
    }
    xui.setWebViewGuid = async function (guid) {
        //设置当前webview的Guid
        //guid:guid字符串
    }
    xui.getWebViewGuid = async function () {
        //获取当前webview的Guid
    }
    xui.getWindowGuid = async function () {
        //获取当前窗口的Guid
    }
    xui.closeWindow = function () {
        //关闭当前窗口
    }
    xui.closeByWindowId = function (windowId) {
        //通过窗口Id关闭窗口
        //windowId:窗口Id
    }

    
    /******UI方法******/

    xui.ui.minimizedWindow = async function (windowID = null) {
    //窗口最小化
    }
    xui.ui.maximizedWindow = async function (windowID = null) {
    //窗口最大化
    }
    xui.ui.normalizedWindow = async function (windowID = null) {
    //窗口恢复初始状态
    }
    xui.ui.toggleWindowState = async function (windowID = null) {
    //切换窗口状态
    }
    xui.ui.getWindowState = async function (windowID = null) {
    //获取窗口状态
    }
    xui.ui.setWindowState = async function (state, windowID = null) {
    //设置窗口状态
    }
    xui.ui.setTitleBar = async function (html, height = 64, windowID = null) {
    //自定义标题栏
    //html:标题栏html
    //height:标题栏高度
    }
    xui.ui.setThemeContext = function (theme) {
       
    }
    xui.ui.getThemes = async function () {
        
    }
    xui.ui.applyTheme = function (theme) {
        
    }
    xui.ui.setDragableArea = async function (x, y, width, height, windowID = null) {
      //设置拖拽区域
      //x:x坐标
      //y:y坐标
      //width:宽度
      //height:高度
    }
    xui.ui.clearDragableArea = async function (windowID = null) {
    //清除拖拽区域
    }
    xui.ui.setWindowFeatures = async function (features, windowID = null) {
    //设置窗口特性
    }
   

    xui.ui.TitleBar = {
        show: async function (windowID = null) {
        //显示标题栏
        },
        hide: async function (dragableArea, windowID = null) {
        //隐藏标题栏
        },

        extend: async function (html, height, windowID = null) {
        //扩展标题栏
        },
        setTitleText: async function (text, windowID = null) {
        //设置标题栏文本
        },
        changeIconState: async function (iconId, bshow, windowID = null) {
        //改变按钮显示状态
        },

        changeCloseIconState: async function (bshow, windowID = null) {
            //改变关闭按钮显示状态
        },
        changeMiniIconState: async function (bshow, windowID = null) {
            //改变最小化按钮显示状态
        },
        changeMaxiIconState: async function (bshow, windowID = null) {
            //改变最大化按钮显示状态
        },
        changePinIconState: async function (bshow, windowID = null) {
            //改变置顶按钮显示状态
        },
        changeControlsState: async function (bshow, windowID = null) {
            //改变按钮栏显示状态
        },
        addIcon: async function (iconHtml, iconId, onclick, windowID = null) {
            //新增按钮
        },
        addTwoStateIcon: async function (bstate, trueiconHtml, falseiconHtml, iconId, onchange, windowID = null) {
            //新增二态按钮
        }
    }

    xui.messager = {
        postWithinWindow: async function (messageType, data) {
            //窗口内消息传递
        },
        
        postToWebview: async function (webviewId, messageType, data) {
           //给指定webview发消息
        },
        postToWindow: async function (windowId, messageType, data) {
            //给指定窗口发消息
        },
        broacast: async function (messageType, data) {
            //应用内广播消息
        },
        onReceive: function (messageType, handler) {
            //消息接收处理
        }
    }
```
## 常见问题
### 怎么替换App图标？
替换项目views目录下favicon.ico既可
### 如何制作主题
拷贝themes目录下子目录，修改目录名字，修改theme.json文件，主题支持图片主题和纯色主题，修改theme.json包括对象相应的属性即可
### 如何开发新API功能
XUI支持采用C#开发功能API，然后在View层（html网页）通过内置xui对象的invokeAction和invokeActionWithCallback方法调用。功能API通过继承Controller类来提供，
举个例子
```
public class LoginController:Controller
    {
        public ActionResult Login(string userName, string password)
        {
            if (userName == "admin" && password == "admin")
            {
                AppContext.Instance.CurrentUser = new Core.Models.User { UserName = userName };

                return ActionResult.StatusTrueResult("登录成功！");
            }
            else return ActionResult.StatusFalseResult("用户名或密码错误！");
        }
    }
```
然后在view层可以这样调用
```
async function login() {
            let userName = document.querySelector("#userName").value;
            let password = document.querySelector("#password").value;
            let result =  await xui.invokeAction("LoginController","Login",{userName:userName,password:password})

            if (result.data.status) {
                location.href = "index.html";
            }
            else alert(result.data.message);
        }
```


invokeAction和invokeActionWithCallback都是异步方法，然而invokeAction是在主线程执行，如果大量频繁调用则可能会卡界面，而invokeActionWithCallback则是子线程执行异步回调方式执行，一般不会卡界面

### 用于xui.openUrl、xui.openHtml、xui.ui.setWindowFeatures等方法的features对象是什么结构
```
var features={
width:1800,//窗口宽度
height:1200,//窗口高度
left:0,//窗口x坐标
top:0,//窗口y坐标
controls:true,//是否显示标题栏按钮
mini:true,//是否显示最小化按钮
maxi:true,//是否显示最大化按钮
topmost:false,//是否显示置顶按钮
close:true,//是否显示关闭按钮
}
```
## 更多问题待后续补充。。。
