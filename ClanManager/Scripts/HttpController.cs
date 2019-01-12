using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Scripts
{
    public class HttpController
    {
        private static string PRIVATE_KEY = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjExMmQ0NTVlLTg4MDItNGZmMy04NThjLTY1ZDhkOTE4NDE3ZCIsImlhdCI6MTU0NzI4MDk5NCwic3ViIjoiZGV2ZWxvcGVyL2M1ZDhlZGVlLTY1MWYtZjhmNS0yMmNmLTFhNmU2YjdmZjNjNSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjExMS4yMjYuMTk5LjI3Il0sInR5cGUiOiJjbGllbnQifV19.14RAjbQeRKIA2qfFURsicwJio9gvpGIagcBgD0WXsr0GLdgzW0mv7U-yQjjKscGePpoYGoUr-xrw--PWQ8qA8A";
        public static string GetKey() { return PRIVATE_KEY; }
        public static string GetResponse(string url, out string statusCode)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetKey());
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            statusCode = GetReason((int)response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        public static T GetResponse<T>(string url, out string statusCode) where T : class, new()
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetKey());
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            statusCode = GetReason((int)response.StatusCode);

            T result = default(T);
            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;
                result = JsonConvert.DeserializeObject<T>(s);
            }
            return result;
        }

        public static string GetReason(int statusCode)
        {
            string mean = string.Empty;
            switch (statusCode)
            {
                case 200: mean = "响应正常"; break;
                case 400: mean = "客户端请求参数错误。"; break;
                case 403: mean = "令牌错误，访问被拒绝。"; break;
                case 404: mean = "资源未找到。"; break;
                case 429: mean = "请求过于频繁。"; break;
                case 500: mean = "处理请求时发生未知错误。"; break;
                case 503: mean = "由于维护，服务暂时无法使用。"; break;
                default: mean = "发生未知异常请联系开发者。"; break;
            }
            return mean;
        }
    }
}
