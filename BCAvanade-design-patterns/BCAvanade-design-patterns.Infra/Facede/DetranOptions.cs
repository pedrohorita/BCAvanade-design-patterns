using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCAvanade_design_patterns.Infra.Facede
{
    public class DetranOptions
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string BaseUrl { get; set; }
        public string VistoriaUri { get; set; }
        public int QuantidadeDiasParaAgendamento { get; set; }
    }
}
