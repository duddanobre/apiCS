using System.Collections.Generic;

namespace Pedidos.API.Domain.Models{
    public class Product{
        public int ProdutoId{get; set;}

        public string Nome{get; set;}
        public string Descricao{get; set;}

        public float Valor{get; set;}

        public int IdPedido {get; set;}

        public Pedido Pedido {get; set;}

    }
}