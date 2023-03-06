namespace GerenciadorApartamentos.Client.Services.RentalServices
{
    public interface IRentalService
    {
        List<Rental> Rentals { get; set; }
        Task GetRentals();
        Task<Rental> GetRental(int id);
        Task CreateRental(Rental rental);
        Task UpdateRental(Rental rental);
    }
}
