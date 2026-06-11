using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Orfelin.Core.DTO;

namespace Orfelin.WPF.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7240/api/");
        }

        public async Task<LoginResponse?> Login(string username, string password)
        {
            var request = new LoginRequest
            {
                Username = username,
                Password = password
            };

            var response = await _httpClient.PostAsJsonAsync("Auth/login", request);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<LoginResponse>();

            return null;
        }
    }
}
