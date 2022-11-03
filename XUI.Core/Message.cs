namespace XUI.Core
{
    public class Message
    {
        public Guid WebViewGuid { get; set; }
        public string Controller { set; get; }
        public string Action { set; get; }
        public dynamic? Data { set; get; }
        public string Listenerkey { set; get; }
        public dynamic? Ext { set; get; }

        public Message(string controller, string action, dynamic? data, string listenerkey,dynamic?ext=null) 
        {
            Controller = controller; Action = action; Data = data; Listenerkey = listenerkey;Ext= ext; 
        }
    }
}
