using GerenciadorApartamentos.Client.Pages;
using GerenciadorApartamentos.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace GerenciadorApartamentos.Client.Services.BuildingServices
{
    public class BuildingService : IBuildingService
    {
        private readonly HttpClient _http;

        private readonly NavigationManager _navigationManager;

        public BuildingService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Building> Buildings { get; set ; }

        public async Task CreateBuilding(Building building)
        {
            var result = await _http.PostAsJsonAsync("api/building", building);
            await SetBuilding(result);
        }

        public async Task DeleteBuilding(int id)
        {
            var result = await _http.DeleteAsync($"api/building/{id}");
            await SetBuilding(result);
        }

        public async Task<Building> GetBuilding(int id)
        {
            var result = await _http.GetFromJsonAsync<Building>($"api/building/{id}");
            if (result != null)
                return result;
            throw new Exception("Edifício não encontrado");

        }

        public async Task GetBuildings()
        {
            var result = await _http.GetFromJsonAsync<List<Building>>($"api/building");
            if (result != null)
            {
                Buildings = result;
            }
        }

        public async Task UpdateBuilding(Building building)
        {
            var result = await _http.PutAsJsonAsync($"api/building/{building.Id}", building);
            await SetBuilding(result);

        }

        private async Task SetBuilding(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Building>>();
            if (response != null)
            {
                Buildings = response;
                _navigationManager.NavigateTo("Buildings");
            }
        }

    }
}
