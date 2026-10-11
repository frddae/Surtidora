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
        public int CrearProducto(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(_configuration))
            {
                SqlCommand cmd = new SqlCommand("sp_CrearProducto", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@ProveedorId", producto.ProveedorId);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                con.Open();
                int result = cmd.ExecuteNonQuery();//devuelve el numero de filas afectadas
                return result;
            }
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
                        ProductoId = Convert.ToInt32(row["productoId"]),
                        NombreProducto = (string)row["producto"],
                        ProveedorId = Convert.ToInt32(row["proveedor"]),
                        Precio = Convert.ToSingle(row["precio"]),
                        Activo = Convert.ToBoolean(row["activo"])
                    });
                }
            }
            return productos;
        }

        public List<Producto> ObtenerProductosActivos()
        {
            var productos = new List<Producto>();

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
                    productos.Add(new Producto
                    {
                        ProductoId = Convert.ToInt32(row["productoId"]),
                        NombreProducto = (string)row["producto"],
                        ProveedorId = Convert.ToInt32(row["proveedor"]),
                        Precio = Convert.ToSingle(row["precio"]),
                        Activo = Convert.ToBoolean(row["activo"])
                    });

                }
            }
            return productos;
        }
        
        public LoteProducto InsertarLoteProducto(LoteProducto loteProducto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Sp_InsertarLote]", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                sqlConnection.Open();
                da.Fill(ds);

                // Verifica que el procedimiento almacenado haya devuelto al menos una tabla y una fila
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0]; // Obtenemos la primera fila

                    loteProducto.ProductoId = Convert.ToInt32(row["ProductoId"]);
                    loteProducto.CodigoLote = row["CodigoLote"].ToString();
                    loteProducto.FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]);
                    loteProducto.CantidadInicial = Convert.ToInt32(row["CantidadInicial"]);
                }
            }

            return loteProducto;
        }

        public List<MostrarLoteProducto> ObtenerLoteProductos()
        {
            var productos = new List<MostrarLoteProducto>();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration))
            {
                SqlCommand cmd = new SqlCommand("dbo.Sp_MostrarLoteProductos", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                sqlConnection.Open();
                da.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    productos.Add(new MostrarLoteProducto
                    {
                        ProductoId = Convert.ToInt32(row["ProductoId"]),
                        Producto = (string)row["Producto"],
                        CodigoLoteFabricante = (string)row["CodigoLoteFabricante"],
                        Proveedor = (string)row["Proveedor"],
                        Precio = Convert.ToDecimal(row["Precio"]),
                        CantidadInicial = Convert.ToInt32(row["CantidadInicial"]),
                        StockActual = Convert.ToInt32(row["StockActual"]),
                        Presentacion = (string)row["Presentacion"],
                        FechaVencimiento = Convert.ToDateTime(row["FechaVencimiento"]),
                        Estado = (string)row["Estado"]
                    });

                }
            }
            return productos;
        }
    }
}
