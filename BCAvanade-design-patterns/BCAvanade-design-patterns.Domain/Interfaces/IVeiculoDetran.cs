using System;
using System.Threading.Tasks;

namespace BCAvanade_design_patterns.Domain.Interfaces
{
    public interface IVeiculoDetran
    {
        public Task AgendarVistoriaDetran(Guid veiculoId);
    }
}
