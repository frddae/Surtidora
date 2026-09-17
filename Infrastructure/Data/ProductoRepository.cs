using Core.Entities;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Data
{
    public class ProductoRepository : IProductoRepository
    {
        public string? _configuration;

        public ProductoRepository(IConfiguration configuration)
        {
            var ConectionString = configuration.GetConnectionString("Surtidora");

            _configuration = ConectionString
               ?? throw new ArgumentNullException(
                   nameof(configuration),
                   "no se encontro la cadena de conexion");
        }
        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration))
            {
                SqlCommand cmd = new SqlCommand("dbo.Sp_MostrarProductos", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                sqlConnection.Open();
                da.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    productos.Add(new Producto
                    {
                        ProductoId = Convert.ToInt32(row["ProductoId"]),
                        NombreProducto = (string)row["Producto"],
                        Proveedor = (string)row["Proveedor"],
                        Precio = Convert.ToSingle(row["Precio"]),
                        Cantidad = Convert.ToInt32(row["Cantidad"]),
                        Presentacion = (string)row["Presentacion"],
                        Fecha_Caducidad = Convert.ToDateTime(row["Fecha_Caducidad"]),
                        Activo = Convert.ToBoolean(row["Activo"])
                    });

                }
            }
            return productos;
        }
        public List<ProductosActivos> ObtenerProductosActivos()
        {
            var productos = new List<ProductosActivos>();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration))
            {
                SqlCommand cmd = new SqlCommand("dbo.Sp_MostrarProductosActivos", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                sqlConnection.Open();
                da.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    productos.Add(new ProductosActivos
                    {
                        ProductoId = Convert.ToInt32(row["ProductoId"]),
                        NombreProducto = (string)row["Producto"],
                        Proveedor = (string)row["Proveedor"],
                        Precio = Convert.ToSingle(row["Precio"]),
                        Cantidad = Convert.ToInt32(row["Cantidad"]),
                        Presentacion = (string)row["Presentacion"],
                        Fecha_Caducidad = Convert.ToDateTime(row["Fecha_Caducidad"]),
                    });

                }
            }
            return productos;
        }
    }
}
