using Microsoft.AspNetCore.Mvc;

namespace GerenciadorApartamentos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly DataContext _context;

        public RentalController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rental>>> GetRentals()
        {
            var rentals = await _context.Rentals.Include(r => r.Apartment).Include(r => r.Tenant).Include(r => r.Apartment.Building).ToListAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental (int id)
        {
            var rental = await _context.Rentals.Include(r => r.Apartment).Include(r => r.Tenant).FirstOrDefaultAsync(r => r.Id == id);
            if (rental == null)
            {
                return NotFound("Nenhum aluguel encontrado.");
            }
            return Ok(rental);
        }

        [HttpPost]
        public async Task<ActionResult<List<Rental>>> CreateRental(Rental rental)
        {
            rental.Apartment = null;
            rental.Tenant = null;

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return Ok(await GetDbRentals());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Rental>>> UpdateApartment(Rental rental, int id)
        {
            var dbRental = await _context.Rentals.Include(r => r.Tenant).Include(r => r.Apartment).FirstOrDefaultAsync(a => a.Id == id);
            if (dbRental == null)
            {
                return NotFound("Nenhum apartamento encontrado.");
            }
            dbRental.StartDate = rental.StartDate;
            dbRental.EndDate = rental.EndDate;
            dbRental.TenantId = rental.TenantId;
            dbRental.ApartmentId = rental.ApartmentId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbRentals());
        }
        private async Task<List<Rental>> GetDbRentals()
        {
            return await _context.Rentals.Include(r => r.Tenant).Include(r => r.Apartment).ToListAsync();
        }
    }
}
