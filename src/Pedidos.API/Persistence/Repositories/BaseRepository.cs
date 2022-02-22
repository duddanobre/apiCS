using Pedidos.API.Persistence.Contexts;

namespace Pedidos.API.Persistence.Repositories{

    public class BaseRepository{

        protected readonly AppDbContext dbContext;

        public BaseRepository(AppDbContext context){
            dbContext = context;
        }

        
    }

}