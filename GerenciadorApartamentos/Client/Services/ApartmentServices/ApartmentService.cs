using GerenciadorApartamentos.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace GerenciadorApartamentos.Client.Services.ApartmentServices
{
    public class ApartmentService : IApartmentService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ApartmentService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Apartment> Apartments { get; set; }

        public async Task CreateApartment(Apartment apartment)
        {

            var result = await _http.PostAsJsonAsync("api/apartment", apartment);
            await SetApartment(result);
        }

        private async Task SetApartment(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Apartment>>();
            if (response != null)
            {
                Apartments = response;
                _navigationManager.NavigateTo("Apartments");
            }
        }

        public async Task DeleteApartment(int id)
        {
            var result = await _http.DeleteAsync($"api/apartment/{id}");
            await SetApartment(result);
        }

        public async Task<Apartment> GetApartment(int id)
        {
            var result = await _http.GetFromJsonAsync<Apartment>($"api/apartment/{id}");
            if (result != null)
                return result;
            throw new Exception("Apartamento não encontrado");
        }

        public async Task GetApartments()
        {
            var result = await _http.GetFromJsonAsync<List<Apartment>>($"api/apartment");
            if (result != null)
            {
                Apartments = result;
            }
        }

        public async Task UpdateApartment(Apartment apartment)
        {
            var result = await _http.PutAsJsonAsync($"api/apartment/{apartment.Id}", apartment);
            await SetApartment(result);

        }
    }
}
