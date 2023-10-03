using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace HospitalInformationSystemFrom.PublicClass
{

    public class HttpHelper
    {
        private readonly HttpClient _httpClient;

        public HttpHelper(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public async Task<string> SendPostRequestAsync(string apiUrl, string jsonContent)
        {
            if (string.IsNullOrEmpty(apiUrl))
                throw new ArgumentNullException(nameof(apiUrl));

            if (string.IsNullOrEmpty(jsonContent))
                throw new ArgumentNullException(nameof(jsonContent));

            try
            {
                // 设置请求内容的编码和类型
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // 发送 POST 请求
                var response = await _httpClient.PostAsync(apiUrl, content);

                // 检查响应状态码
                if (response.IsSuccessStatusCode)
                {
                    // 解析响应内容
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException($"HTTP {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            return null;
        }

        public async Task<string> SendGetRequestAsync(string apiUrl)
        {
            if (string.IsNullOrEmpty(apiUrl))
                throw new ArgumentNullException(nameof(apiUrl));

            try
            {
                // 发送 GET 请求
                var response = await _httpClient.GetAsync(apiUrl);

                // 检查响应状态码
                if (response.IsSuccessStatusCode)
                {
                    // 解析响应内容
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException($"HTTP {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
            return null;
        }
    }

    public class Program
    {
        public static async Task Main()
        {
            string apiUrl = "http://localhost:5250/api/User/CreateUser"; // 替换为你的 API 地址

            // 准备要发送的 JSON 数据
            string jsonContent = "{\"FirstName\": \"John\", \"LastName\": \"Doe\", \"Age\": 30}";

            using (var httpClient = new HttpClient())
            {
                var httpHelper = new HttpHelper(httpClient);

                try
                {
                    // 使用公用方法发送 POST 请求
                    var responseContent = await httpHelper.SendPostRequestAsync(apiUrl, jsonContent);
                    Console.WriteLine("Response Content: " + responseContent);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("HTTP request error: " + ex.Message);
                }
            }
        }
    }

}
