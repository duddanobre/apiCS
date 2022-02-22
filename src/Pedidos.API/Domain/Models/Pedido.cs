using System.Collections.Generic;
using System;

namespace Pedidos.API.Domain.Models{
    public class Pedido{
        public int Id{get; set;}

        public DateTime Data_create {get; set;}
        public DateTime Data_entrega{get; set;}

        public string Endereco{get; set;}

        public List<Product> Produtos {get;} = new List<Product>();


    }
}