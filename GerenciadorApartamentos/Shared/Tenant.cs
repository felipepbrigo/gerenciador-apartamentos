using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorApartamentos.Shared
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}