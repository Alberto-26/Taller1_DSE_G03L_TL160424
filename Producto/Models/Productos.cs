using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Producto.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Existencia { get; set; }
        public int NumPedidos { get; set; }
    }
    public class ProductoDBContext:DbContext
    {
        public DbSet<Productos> Producto { get; set; }
    }
}