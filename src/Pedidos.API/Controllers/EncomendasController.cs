using Microsoft.AspNetCore.Mvc;
using Pedidos.API.Domain.Services;
using System.Threading.Tasks;
using Pedidos.API.Domain.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pedidos.API.Persistence.Contexts;
using System.Linq;

namespace Pedidos.API.Controllers{
    [Route("/api/sales")]
    public class EncomendasController : Controller{

        private readonly IEncomendaService service;
        private readonly AppDbContext dbContext;
        public EncomendasController(IEncomendaService encomendaService, AppDbContext context){
            service = encomendaService;
            dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Pedido>> GetAllAsync( ){

            var encomendas = await service.ListAsync();

            return encomendas;
        }

        public async Task<IActionResult> Index(
                                        string sortOrder,
                                        string currentFilter,
                                        string searchString,
                                        int? pageNumber){
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            
            if (searchString != null){
                pageNumber = 1;
            }else{
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var sales = from s in dbContext.Pedidos select s;
            
            switch(sortOrder){
                case "Date":
                sales = sales.OrderBy(s => s.Data_create);
                break;
                case "date_desc":
                sales = sales.OrderByDescending(s => s.Data_create);
                break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Pedido>.CreateAsync(sales.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }}