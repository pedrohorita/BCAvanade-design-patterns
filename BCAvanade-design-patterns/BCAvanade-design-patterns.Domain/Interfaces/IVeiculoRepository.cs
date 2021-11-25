using BCAvanade_design_patterns.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BCAvanade_design_patterns.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        void Add(Veiculo veiculo);
        void Delete(Veiculo veiculo);
        void Update(Veiculo veiculo);
        Veiculo GetById(Guid Id);
        IEnumerable<Veiculo> GetAll();
    }
}
