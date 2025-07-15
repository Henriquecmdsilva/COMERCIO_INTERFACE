using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace appComercio
{
    public static class AuthManager
    {
        private static string _apiKey;
        private static HttpClient _httpClient;

        public static bool IsAuthenticated => !string.IsNullOrEmpty(_apiKey);
        public static string ApiKey => _apiKey;

        public static void SetApiKey(string apiKey)
        {
            _apiKey = apiKey;
            ConfigureHttpClient();
        }

        public static void ClearApiKey()
        {
            _apiKey = null;
            _httpClient?.Dispose();
            _httpClient = null;
        }

        private static void ConfigureHttpClient()
        {
            if (_httpClient != null)
            {
                _httpClient.Dispose();
                _httpClient = null;
            }

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://127.0.0.1:5000/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(_apiKey))
            {
                _httpClient.DefaultRequestHeaders.Add("X-API-Key", _apiKey);
            }
        }

        public static HttpClient GetHttpClient()
        {
            if (_httpClient == null)
            {
                ConfigureHttpClient();
            }
            return _httpClient;
        }
    }
}