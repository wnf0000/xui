using XUI.Core.Models;

namespace XUI.Core
{
    public class App
    {
        public User CurrentUser { get; set; }


        private App()
        {
        }
        static App _instance;
        public static App Instance { get { return _instance ?? (_instance = new App()); } }
    }
}
