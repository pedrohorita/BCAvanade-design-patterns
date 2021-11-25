using System;

namespace BCAvanade_design_patterns.Domain.Entities
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string AnoFabricacao { get; set; }
    }
}
