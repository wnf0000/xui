using System.Reflection;

namespace XUI.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public abstract class ActionFilterAttribute : Attribute, IActionFilter
    {
        public int Order { get; private set; }

        public virtual FilterResult BeforeInvoke(App context, Controller controller, MethodInfo action)
        {
            throw new NotImplementedException();
        }
    }
}
