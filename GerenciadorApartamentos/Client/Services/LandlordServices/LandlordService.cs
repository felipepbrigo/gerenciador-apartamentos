using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace GerenciadorApartamentos.Client.Services.LandlordServices
{
    public class LandlordService : ILandlordService
    {
        public List<Landlord> Landlords { get ; set ; }

        private readonly HttpClient _http;

        private readonly NavigationManager _navigationManager;
        public LandlordService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public async Task<Landlord> GetLandlord(int id)
        {
            var result = await _http.GetFromJsonAsync<Landlord>($"api/landlord/{id}");
            if (result != null)
                return result;
            throw new Exception("Locador não encontrado");
        }
    }
}
