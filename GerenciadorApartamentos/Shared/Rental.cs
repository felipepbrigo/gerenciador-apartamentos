using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorApartamentos.Shared
{
    public class Rental
    {
        public int Id { get; set; }
        public int? ApartmentId { get; set; } = null;
        public Apartment? Apartment { get; set; } = null;
        public int? TenantId { get; set; } = null;
        public Tenant? Tenant { get; set; } = null;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
    }
}
