using XUI.Core;
using AppContext = XUI.Core.App;
namespace XUI.App.Controllers
{
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
}
