using XUI.Core.Attributes;

namespace XUI.Core
{
    public abstract class Controller
    {
        public App Context => App.Instance;
        public async Task<object?> InvokeAction(string action, Message message)
        {
            var controllerType = this.GetType();
            var actionInfo = controllerType.GetMethod(action);
            if (actionInfo == null) throw new Exception($"Action '{action}'不存在！");

            var attrs = (ActionFilterAttribute[])Attribute.GetCustomAttributes(controllerType, typeof(ActionFilterAttribute));

            foreach (var attr in attrs.OrderBy(w => w.Order))
            {
                var result =  attr.BeforeInvoke(Context, this, actionInfo);
                if (result.Type != FilterResultType.Passed)
                {
                    return result;
                }
            }
            attrs = (ActionFilterAttribute[])Attribute.GetCustomAttributes(actionInfo, typeof(ActionFilterAttribute));

            foreach (var attr in attrs.OrderBy(w => w.Order))
            {
                var result =  attr.BeforeInvoke(Context, this, actionInfo);
                if (result.Type != FilterResultType.Passed)
                {
                    return result;
                }
            }

            var pms = actionInfo.GetParameters().OrderBy(w => w.Position).ToArray();
            var pvs = new List<object>();
            foreach (var p in pms)
            {
                if (p.ParameterType == typeof(Message))
                {
                    pvs.Add(message);
                    continue;
                }
                var val = (message.Data?[p.Name] as Newtonsoft.Json.Linq.JToken)?.ToObject(p.ParameterType);
                pvs.Add(val);

            }
            var actionResult = actionInfo.Invoke(this, pvs.ToArray());

            return actionResult;
        }
    }
}
