namespace GerenciadorApartamentos.Client.Services.ApartmentServices
{
    public interface IApartmentService
    {
        List<Apartment> Apartments { get; set; }
        Task GetApartments();
        Task<Apartment> GetApartment(int id);
        Task CreateApartment(Apartment apartment);
        Task UpdateApartment(Apartment apartment);
        Task DeleteApartment(int id);
    }
}