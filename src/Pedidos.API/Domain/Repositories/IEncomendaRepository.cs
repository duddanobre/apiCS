using System.Collections.Generic;
using System.Threading.Tasks;
using Pedidos.API.Domain.Models;

namespace Pedidos.API.Domain.Repositories{
    public interface IEncomendaRepository{
        Task<IEnumerable<Pedido>> ListAsync();

        Task<Pedido> FindByDateAsync(System.DateTime date);
    }
}