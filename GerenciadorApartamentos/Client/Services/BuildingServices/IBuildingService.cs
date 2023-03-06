namespace GerenciadorApartamentos.Client.Services.BuildingServices
{
    public interface IBuildingService
    {
        List<Building> Buildings { get; set; }
        Task GetBuildings();
        Task<Building> GetBuilding(int id);
        Task CreateBuilding(Building building);
        Task UpdateBuilding(Building building);
        Task DeleteBuilding(int id);
    }
}
