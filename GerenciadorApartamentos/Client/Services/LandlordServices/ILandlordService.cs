namespace GerenciadorApartamentos.Client.Services.LandlordServices
{
    public interface ILandlordService
    {
        List<Landlord> Landlords { get; set; }
        Task<Landlord> GetLandlord(int id);       
    }
}
