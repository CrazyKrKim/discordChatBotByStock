using InvestSupTool.Util;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


#nullable enable
namespace InvestSupTool
{
    public static class RestApiUtil
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> PostRequest(
          string url,
          string jsonData,
          Dictionary<string, string> headers,
          Dictionary<string, string> queryParams)
        {
            try
            {
                string finalUrl = queryParams == null || queryParams.Count <= 0 ? url : QueryHelpers.AddQueryString(url, (IDictionary<string, string>)RestApiUtil.ConvertToNullableDictionary(queryParams));
                LogUtil.Info("요청 URL: " + finalUrl);
                using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, finalUrl))
                {
                    requestMessage.Content = (HttpContent)new StringContent(jsonData, Encoding.UTF8, "application/json");
                    if (headers != null)
                    {
                        foreach (KeyValuePair<string, string> header1 in headers)
                        {
                            KeyValuePair<string, string> header = header1;
                            requestMessage.Headers.Add(header.Key, header.Value);
                            header = new KeyValuePair<string, string>();
                        }
                    }
                    HttpResponseMessage response = await RestApiUtil.client.SendAsync(requestMessage);
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorBody = await response.Content.ReadAsStringAsync();
                        LogUtil.Error("--- API 요청 실패 로그 ---");
                        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
                        interpolatedStringHandler.AppendLiteral("상태 코드: ");
                        interpolatedStringHandler.AppendFormatted<int>((int)response.StatusCode);
                        interpolatedStringHandler.AppendLiteral(" (");
                        interpolatedStringHandler.AppendFormatted(response.ReasonPhrase);
                        interpolatedStringHandler.AppendLiteral(")");
                        LogUtil.Error(interpolatedStringHandler.ToStringAndClear());
                        LogUtil.Error("요청 URL: " + finalUrl);
                        LogUtil.Error("응답 본문: " + errorBody);
                        LogUtil.Error("--------------------------");
                        return errorBody;
                    }
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
            catch (HttpRequestException ex)
            {
                LogUtil.Error("HttpRequestException", (Exception)ex);
                return "";
            }
        }

        private static Dictionary<string, string?> ConvertToNullableDictionary(
          Dictionary<string, string> dictionary)
        {
            Dictionary<string, string> nullableDictionary = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> keyValuePair in dictionary)
                nullableDictionary[keyValuePair.Key] = keyValuePair.Value;
            return nullableDictionary;
        }

        public static async Task RequestDownloadFile(string url, string baseDir, string fileName)
        {
            string filePath = Path.Combine(baseDir, fileName);
            Directory.CreateDirectory(baseDir);
            LogUtil.Info("다운로드를 시작합니다.");
            HttpClientHandler handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            using (HttpClient httpClient = new HttpClient((HttpMessageHandler)handler))
            {
                try
                {
                    using (Stream responseStream = await httpClient.GetStreamAsync(url))
                    {
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                            await responseStream.CopyToAsync((Stream)fileStream);
                    }
                    LogUtil.Info("다운로드를 완료되었습니다.");
                }
                catch (Exception ex)
                {
                    LogUtil.Error("다운로드를 중단합니다.", ex);
                    filePath = (string)null;
                    handler = (HttpClientHandler)null;
                    return;
                }
            }
            filePath = (string)null;
            handler = (HttpClientHandler)null;
        }
    }
}
