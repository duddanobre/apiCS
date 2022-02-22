using System.Collections.Generic;
using System.Threading.Tasks;
using Pedidos.API.Domain.Models;

namespace Pedidos.API.Domain.Services{
    public interface IEncomendaService{
        Task<IEnumerable<Pedido>> ListAsync();
    }
}