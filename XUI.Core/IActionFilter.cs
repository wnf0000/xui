using System.Reflection;

namespace XUI.Core
{
    public interface IActionFilter
    {
        public FilterResult BeforeInvoke(App context, Controller controller, MethodInfo action);
    }
}
