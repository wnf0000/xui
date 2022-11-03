using System.Reflection;

namespace XUI.Core.Attributes
{
    public class RequiredLoginAttribute:ActionFilterAttribute
    {
        public override FilterResult BeforeInvoke(App context, Controller controller, MethodInfo action)
        {
            if (context.CurrentUser != null) return FilterResult.PassedResult();
            return FilterResult.RedirectResult("views/login.html");
        }
    }
}
