namespace GerenciadorApartamentos.Client.Services.TenantServices
{
    public interface ITenantService
    {
        List<Tenant> Tenants { get; set; }
        Task CreateTenant(Tenant tenant);
        Task DeleteTenant(int id);
        Task<Tenant> GetTenant(int id);
        Task GetTenants();
        Task UpdateTenant(Tenant tenant);
    }
}
