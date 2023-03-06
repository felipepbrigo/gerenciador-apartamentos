using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace GerenciadorApartamentos.Client.Services.RentalServices
{
    public class RentalService : IRentalService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public RentalService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Rental> Rentals { get; set; }

        public async Task CreateRental(Rental rental)
        {
            var result = await _http.PostAsJsonAsync("api/rental", rental);
            await SetRental(result);
        }

        private async Task SetRental(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Rental>>();
            if (response != null)
            {
                Rentals = response;
            }
        }
        public async Task<Rental> GetRental(int id)
        {
            var result = await _http.GetFromJsonAsync<Rental>($"api/rental/{id}");
            if (result != null)
                return result;
            throw new Exception("Aluguel não encontrado");
        }

        public async Task GetRentals()
        {
            var result = await _http.GetFromJsonAsync<List<Rental>>($"api/rental");
            if (result != null)
            {
                Rentals = result;
            }
        }
        public async Task UpdateRental(Rental rental)
        {
            var result = await _http.PutAsJsonAsync($"api/rental/{rental.Id}", rental);
            await SetRental(result);
        }
    }
}