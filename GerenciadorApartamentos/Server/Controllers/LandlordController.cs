using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorApartamentos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordController : ControllerBase
    {
        private readonly DataContext _context;

        public LandlordController(DataContext context)
        {
            _context = context;
        }
        public static List<Landlord> landlords = new List<Landlord> { };

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Landlord>>> GetLandlord(int id)
        {
            var landlord = await _context.Landlords.FirstOrDefaultAsync(l => l.Id == id);
            if (landlord == null)
                return NotFound("Nenhum locador encontrado.");
            return Ok(landlord);
        }
    }
}
