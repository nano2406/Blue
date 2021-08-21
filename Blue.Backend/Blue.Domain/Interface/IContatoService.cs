using Blue.Domain.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blue.Domain.Interface
{
    public interface IContatoService : IDisposable
    {
        Task<Contato> Get(Guid id);
        Task<Contato> Post(Contato contato);
        Task<IEnumerable<Contato>> List();
        Task<Contato> Put(Contato contato, Guid id);
        Task<bool> Delete(Contato contato);
    }
}
