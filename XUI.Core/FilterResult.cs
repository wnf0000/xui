namespace XUI.Core
{
    public enum FilterResultType
    {
        /// <summary>
        /// 通过
        /// </summary>
        Passed,
        /// <summary>
        /// 重定向
        /// </summary>
        Redirect,
        /// <summary>
        /// 数据
        /// </summary>
        Data,
        /// <summary>
        /// 禁止
        /// </summary>
        NotAllow
    }
    public class FilterResult
    {
        public FilterResultType Type { private set; get; }
        public object? Data { get; private set; }
        public static FilterResult PassedResult()
        {
            return new FilterResult() { Type = FilterResultType.Passed };
        }
        public static FilterResult RedirectResult(string url)
        {
            return new FilterResult() { Type = FilterResultType.Redirect, Data = url };
        }

        public static FilterResult DataResult(object data)
        {
            return new FilterResult() { Type = FilterResultType.Data, Data = data };
        }

        public static FilterResult NotAllowResult(string detail = null)
        {
            return new FilterResult() { Type = FilterResultType.NotAllow, Data = detail };
        }
    }
}
