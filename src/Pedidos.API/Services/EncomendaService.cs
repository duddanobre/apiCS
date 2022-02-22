using System.Collections.Generic;
using System.Threading.Tasks;
using Pedidos.API.Domain.Models;
using Pedidos.API.Domain.Services;
using Pedidos.API.Domain.Repositories;

namespace Pedidos.API.Services{
    public class EncomendaService : IEncomendaService{

        private readonly IEncomendaRepository repository;

        public EncomendaService(IEncomendaRepository encomendaRepository){
            repository = encomendaRepository;
        }
        public async Task<IEnumerable<Pedido>> ListAsync(){
              
          return await repository.ListAsync();    
        }

    }
}