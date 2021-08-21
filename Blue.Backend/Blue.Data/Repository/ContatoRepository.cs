using Blue.Domain.Interface;
using Blue.Domain.Modelos;
using Blue.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blue.Infra.Repository
{
    public class ContatoRepository : Repository<Contato> , IContatoRepository
    {
        public ContatoRepository(BlueContext context) : base(context) { }
    }
}
