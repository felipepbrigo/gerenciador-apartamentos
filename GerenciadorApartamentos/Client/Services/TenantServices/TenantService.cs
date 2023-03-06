using GerenciadorApartamentos.Client.Pages;
using GerenciadorApartamentos.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace GerenciadorApartamentos.Client.Services.TenantServices
{
    public class TenantService : ITenantService
    {
        private readonly HttpClient _http;
        
        private readonly NavigationManager _navigationManager;

        public TenantService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Tenant> Tenants { get; set; }

        public async Task CreateTenant(Tenant tenant)
        {
            var result = await _http.PostAsJsonAsync("api/tenant", tenant);
            await SetTenant(result);
        }

        public async Task DeleteTenant(int id)
        {
            var result = await _http.DeleteAsync($"api/tenant/{id}");
            await SetTenant(result);
        }

        public async Task<Tenant> GetTenant(int id)
        {
            var result = await _http.GetFromJsonAsync<Tenant>($"api/tenant/{id}");
            if (result != null)
                return result;
            throw new Exception("Inquilino não encontrado");
        } 

        public async Task GetTenants()
        {
            var result = await _http.GetFromJsonAsync<List<Tenant>>($"api/tenant");
            if (result != null)
            {
                Tenants = result;
            }
        }

        public async Task UpdateTenant(Tenant tenant)
        {
            var result = await _http.PutAsJsonAsync($"api/tenant/{tenant.Id}", tenant);
            await SetTenant(result);
        }

        private async Task SetTenant(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Tenant>>();
            if (response != null)
            {
                Tenants = response;
                _navigationManager.NavigateTo("Tenants");
            }
        }
    }
}
