using Blue.Domain.Interface;
using Blue.Domain.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blue.Domain.Services
{
    public class ContatoService : IContatoService
    {

        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<Contato> Get(Guid id)
        {
            var contato = await _contatoRepository.ObterPorId(id);

            return contato;
        }

        public async Task<IEnumerable<Contato>> List()
        {
            return await _contatoRepository.ObterTodos();
        }

        public async Task<Contato> Put(Contato contatoForPut, Guid id)
        {
            var contato = await _contatoRepository.ObterPorId(id);

            if (contatoForPut.Nome != null)
            {
                contato.Nome = contatoForPut.Nome;
            }
            if (contatoForPut.Fone != null)
            {
                contato.Fone = contatoForPut.Fone;
            }
            if (contatoForPut.Email != null)
            {
                contato.Email = contatoForPut.Email;
            }

            if (contato.IsValiIdForPatch() && contato != null)
            {
                
               return await _contatoRepository.Atualizar(contato);
            }
            
            return null;
        }

        public async Task<Contato> Post(Contato contato)
        {
            if (contato.IsValiIdForCreation())
            {
                await _contatoRepository.Adicionar(contato);
            }
            return contato;
        }

        public async Task<bool> Delete(Contato contato)
        {

            if(contato.IsValiIdForDelete())
            {
                await _contatoRepository.Remover(contato.Id);
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            _contatoRepository?.Dispose();
        }
    }
}
