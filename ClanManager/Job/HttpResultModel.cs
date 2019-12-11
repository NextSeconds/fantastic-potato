namespace ClanManager.Job
{
    public class HttpResultModel
    {
        public Data d;
    }

    public class Data
    {
        public string __type { get; set; }
        /// <summary>
        /// 请求是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 异常消息
        /// </summary>
        public string ErrorMsg { get; set; }
    }
}