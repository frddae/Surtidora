using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MostrarLoteProducto
    {
        public int ProductoId { get; set; }

        public string? Producto { get; set; }

        public string? CodigoLoteFabricante { get; set; }

        public string? Proveedor { get; set; }
        public decimal Precio { get; set; }

        public int CantidadInicial { get; set; }

        public int StockActual { get; set; }

        public string? Presentacion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string? Estado { get; set; }
    }
}
