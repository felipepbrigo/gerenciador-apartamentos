using Microsoft.AspNetCore.Mvc;

namespace GerenciadorApartamentos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly DataContext _context;

        public TenantController(DataContext context)
        {
            _context = context;
        }

        public static List<Tenant> tenants = new List<Tenant> { };

        [HttpGet]
        public async Task<ActionResult<List<Tenant>>> GetTenants()
        {
            var tenants = await _context.Tenants.ToListAsync();
            return Ok(tenants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tenant>>> GetTenant(int id)
        {
            var tenant = await _context.Tenants.FirstOrDefaultAsync(t => t.Id == id);
            if (tenant == null)
                return NotFound("Nenhum locatário encontrado.");
            return Ok(tenant);
        }
        [HttpPost]
        public async Task<ActionResult<List<Tenant>>> CreateTenant(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTenants());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Tenant>>> UpdateTenant(Tenant tenant, int id)
        {
            var dbTenants = await _context.Tenants.FirstOrDefaultAsync(t => t.Id == id);
            if (dbTenants == null)
            {
                return NotFound("Nenhum locatário encontrado.");
            }
            dbTenants.Name = tenant.Name;
            dbTenants.CPF = tenant.CPF;
            dbTenants.Address = tenant.Address;

            await _context.SaveChangesAsync();

            return Ok(await GetDbTenants());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Tenant>>> DeleteTenant(int id)
        {
            var dbTenants = await _context.Tenants.FirstOrDefaultAsync(a => a.Id == id);
            if (dbTenants == null)
            {
                return NotFound("Nenhum locatário encontrado.");
            }
            _context.Tenants.Remove(dbTenants);
            await _context.SaveChangesAsync();
            return Ok(await GetDbTenants());
        }
        private async Task<List<Tenant>> GetDbTenants()
        {
            return await _context.Tenants.ToListAsync();
        }
    }
}

