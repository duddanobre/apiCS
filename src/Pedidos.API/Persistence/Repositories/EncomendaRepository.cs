using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedidos.API.Domain.Models;
using Pedidos.API.Domain.Repositories;
using Pedidos.API.Persistence.Contexts;

namespace Pedidos.API.Persistence.Repositories{
    public class EncomendaRepository : BaseRepository, IEncomendaRepository{
        public EncomendaRepository(AppDbContext context) :base(context){

        }

        public async Task<IEnumerable<Pedido>> ListAsync(){
            return await dbContext.Pedidos.ToListAsync();
        }

        public async Task<Pedido> FindByDateAsync(System.DateTime data){
           return await dbContext.Pedidos.FindAsync(data);
        }

    }
}