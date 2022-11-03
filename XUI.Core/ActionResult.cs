namespace XUI.Core
{
    public enum ActionResultType
    {
        Void,
        Data
    }
    public class ActionResult
    {
        public ActionResultType Type { get; private set; }
        public object? Data { get; set; }

        public static ActionResult VoidResult()
        {
            return new ActionResult() { Type = ActionResultType.Void, Data = null };
        }

        public static ActionResult DataResult(object data)
        {
            return new ActionResult() { Type = ActionResultType.Data, Data = new { Status = true, Message = string.Empty, Data = data } };
        }
        public static ActionResult StatusResult(bool status, string message)
        {
            return new ActionResult() { Type = ActionResultType.Data, Data = new { Status = status, Message = message, Data = null as object } };
        }
        public static ActionResult StatusTrueResult(string message)
        {
            return StatusResult(true, message);
        }
        public static ActionResult StatusFalseResult(string message)
        {
            return StatusResult(false, message);
        }
        public static ActionResult ListResult(object[] data, int size, int index, int total, int pageCount)
        {
            return ActionResult.DataResult(new { Array = data, Size = size, Index = index, Total = total, PageCount = pageCount });
        }
    }
}