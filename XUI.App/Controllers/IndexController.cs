using XUI.Core;
using XUI.Core.Attributes;

namespace XUI.App.Controllers
{
    public class IndexController:Controller
    {
        [RequiredLogin]
        public ActionResult Dashboard()
        {
            return ActionResult.DataResult(new
            {
                Income = 10000m,
                NewCustomers=998,
                NewOrders=1000
            });
        }
    }
}
