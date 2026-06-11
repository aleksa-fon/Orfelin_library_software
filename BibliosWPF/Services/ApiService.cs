using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Orfelin.Core.DTO;
using Orfelin.Core.Models;

namespace Orfelin.WPF.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri("http://localhost:5000/api/");
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

        // KNJIGE
        public async Task<List<Knjiga>?> GetAllKnjige() =>
            await _httpClient.GetFromJsonAsync<List<Knjiga>>("Knjiga");

        public async Task<bool> AddKnjiga(Knjiga knjiga)
        {
            var response = await _httpClient.PostAsJsonAsync("Knjiga", knjiga);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateKnjiga(Knjiga knjiga)
        {
            var response = await _httpClient.PutAsJsonAsync("Knjiga", knjiga);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteKnjiga(int id)
        {
            var response = await _httpClient.DeleteAsync($"Knjiga/{id}");
            return response.IsSuccessStatusCode;
        }

        // KORISNICI
        public async Task<List<Korisnik>?> GetAllKorisnici() =>
            await _httpClient.GetFromJsonAsync<List<Korisnik>>("Korisnik");

        public async Task<bool> AddKorisnik(Korisnik korisnik)
        {
            var response = await _httpClient.PostAsJsonAsync("Korisnik", korisnik);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateKorisnik(Korisnik korisnik)
        {
            var response = await _httpClient.PutAsJsonAsync("Korisnik", korisnik);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteKorisnik(int id)
        {
            var response = await _httpClient.DeleteAsync($"Korisnik/{id}");
            return response.IsSuccessStatusCode;
        }

        // ZAPOSLENI
        public async Task<List<Zaposleni>?> GetAllZaposleni() =>
            await _httpClient.GetFromJsonAsync<List<Zaposleni>>("Zaposleni");

        public async Task<bool> AddZaposleni(Zaposleni zaposleni)
        {
            var response = await _httpClient.PostAsJsonAsync("Zaposleni", zaposleni);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateZaposleni(Zaposleni zaposleni)
        {
            var response = await _httpClient.PutAsJsonAsync("Zaposleni", zaposleni);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteZaposleni(int id)
        {
            var response = await _httpClient.DeleteAsync($"Zaposleni/{id}");
            return response.IsSuccessStatusCode;
        }

        // POZAJMICE
        public async Task<List<Pozajmica>?> GetAllPozajmice() =>
            await _httpClient.GetFromJsonAsync<List<Pozajmica>>("Pozajmica");

        public async Task<bool> AddPozajmica(Pozajmica pozajmica)
        {
            var response = await _httpClient.PostAsJsonAsync("Pozajmica", pozajmica);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePozajmica(Pozajmica pozajmica)
        {
            var response = await _httpClient.PutAsJsonAsync("Pozajmica", pozajmica);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePozajmica(int id)
        {
            var response = await _httpClient.DeleteAsync($"Pozajmica/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
