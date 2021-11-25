﻿using BCAvanade_design_patterns.Domain.Entities;
using BCAvanade_design_patterns.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCAvanade_design_patterns.Infra.Repository.EF
{
    public class FrotaRepository : IVeiculoRepository
    {
        private readonly FrotaContext dbContext;

        public FrotaRepository(FrotaContext dbContext) => this.dbContext = dbContext;
        public void Add(Veiculo veiculo)
        {
            dbContext.Veiculos.Add(veiculo);
            dbContext.SaveChanges();
        }

        public void Delete(Veiculo veiculo)
        {
            dbContext.Veiculos.Remove(veiculo);
            dbContext.SaveChanges();
        }

        public IEnumerable<Veiculo> GetAll() => dbContext.Veiculos.ToListAsync().Result;

        public Veiculo GetById(Guid Id) => dbContext.Veiculos.SingleOrDefaultAsync().Result;

        public void Update(Veiculo veiculo)
        {
            dbContext.Entry(veiculo).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}