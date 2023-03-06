using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorApartamentos.Shared
{
    public class Apartment
    { 
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o número do apartamento.")]
        public string Number { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o valor do aluguel do apartamento.")]
        public int RentValue { get; set; } = 0;
        public bool IsRented { get; set; } = false;

        // Relacionamentos
        public Building? Building { get; set; }
        public int BuildingId { get; set; }
        public Tenant? Tenant { get; set; }
        public int? TenantId { get; set; }
        public Landlord? Landlord { get; set; }
        public int? LandlordId { get; set; }
    }
}
