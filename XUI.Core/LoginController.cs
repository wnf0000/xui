namespace XUI.Core
{
    public class LoginController:Controller
    {
        public ActionResult Login(string userName,string password)
        {
            if (userName == "admin" && password == "admin") return ActionResult.StatusTrueResult("登录成功！");
            else return ActionResult.StatusFalseResult("用户名或密码错误！");
        }
    }
}
