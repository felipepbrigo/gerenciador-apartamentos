using Microsoft.AspNetCore.Mvc;


namespace GerenciadorApartamentos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly DataContext _context;

        public BuildingController(DataContext context)
        {
            _context = context;
        }

        public static List<Building> buildings = new List<Building> { };

        [HttpGet]
        public async Task<ActionResult<List<Building>>> GetBuildings()
        {
            var buildings = await _context.Buildings.ToListAsync();
            return Ok(buildings);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Building>>> GetBuilding(int id)
        {
            var building = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == id);
            if (building == null)
                return NotFound("Nenhum Edifício encontrado.");
            return Ok(building);
        }
        [HttpPost]
        public async Task<ActionResult<List<Building>>> CreateBuilding(Building building)
        {
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();
            return Ok(await GetDbBuildings());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Building>>> UpdateBuilding(Building building, int id)
        {
            var dbBuilding = await _context.Buildings.FirstOrDefaultAsync(b => b.Id == id);
            if (dbBuilding == null)
            {
                return NotFound("Nenhum edifício encontrado.");
            }
            dbBuilding.Name = building.Name;
            dbBuilding.Address = building.Address;

            await _context.SaveChangesAsync();

            return Ok(await GetDbBuildings());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Building>>> DeleteBuilding(int id)
        {
            var dbBuilding = await _context.Buildings.FirstOrDefaultAsync(a => a.Id == id);
            if (dbBuilding == null)
            {
                return NotFound("Nenhum apartamento encontrado.");
            }
            _context.Buildings.Remove(dbBuilding);
            await _context.SaveChangesAsync();
            return Ok(await GetDbBuildings());
        }
        private async Task<List<Building>> GetDbBuildings()
        {
            return await _context.Buildings.ToListAsync();
        }
    }
}
