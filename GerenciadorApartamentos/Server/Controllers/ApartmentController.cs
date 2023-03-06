using Microsoft.AspNetCore.Mvc;


namespace GerenciadorApartamentos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {

        private readonly DataContext _context;


        public ApartmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Apartment>>> GetApartments()
        {
            var apartments = await _context.Apartments.Include(a => a.Building).Include(a => a.Landlord).ToListAsync();
            return Ok(apartments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Apartment>> GetApartment(int id)
        {
            var apartment = await _context.Apartments.Include(a => a.Building).Include(a => a.Landlord).FirstOrDefaultAsync(a => a.Id == id);
            if (apartment == null)
            {
                return NotFound("Nenhum apartamento encontrado.");
            }
            return Ok(apartment);
        }

        [HttpPost]
        public async Task<ActionResult<List<Apartment>>> CreateApartment(Apartment apartment)
        {
            apartment.Building = null;
            apartment.Landlord = null;

            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();

            return Ok(await GetDbApartments());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Apartment>>> UpdateApartment(Apartment apartment, int id)
        {
            var dbApartment = await _context.Apartments.Include(a => a.Building).Include(a => a.Landlord).FirstOrDefaultAsync(a => a.Id == id);
            if (dbApartment == null)
            {
                return NotFound("Nenhum apartamento encontrado.");
            }
            dbApartment.Number = apartment.Number;
            dbApartment.RentValue = apartment.RentValue;
            dbApartment.BuildingId = apartment.BuildingId;
            dbApartment.LandlordId = apartment.LandlordId;
            dbApartment.IsRented = apartment.IsRented;

            await _context.SaveChangesAsync();

            return Ok(await GetDbApartments());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Apartment>>> DeleteApartment(int id)
        {
            var dbApartment = await _context.Apartments.Include(a => a.Building).Include(a => a.Landlord).FirstOrDefaultAsync(a => a.Id == id);
            if (dbApartment == null)
            {
                return NotFound("Nenhum apartamento encontrado.");
            }
            _context.Apartments.Remove(dbApartment);
            await _context.SaveChangesAsync();

            return Ok(await GetDbApartments());
        }
        private async Task<List<Apartment>> GetDbApartments()
        {
            return await _context.Apartments.Include(a => a.Building).Include(a => a.Landlord).ToListAsync();
        }
    }
}
