using Core.Entities;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Data
{
    public class ProveedorRepository : IProveedorRepository
    {
        public string? _configuration;
    
        public ProveedorRepository(IConfiguration configuration)
        {
            var ConectionString = configuration.GetConnectionString("Surtidora");
            _configuration = ConectionString
               ?? throw new ArgumentNullException(
                   nameof(configuration),
                   "no se encontro la cadena de conexion");
        }

        public int CrearProveedor(Proveedor proveedor)
        {
            using (SqlConnection con = new SqlConnection(_configuration))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarProveedor", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@nombreProveedor", proveedor.NombreProveedor);
                cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
        }

        public List<Proveedor> ObtenerProveedores()
        {
            var proveedores = new List<Proveedor>();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration))
            {
                SqlCommand cmd = new SqlCommand("dbo.Sp_MostrarProveedores", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlConnection.Open();
                da.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    proveedores.Add(new Proveedor
                    {
                        ProveedorId = Convert.ToInt32(row["proveedorId"]),
                        NombreProveedor = (string)row["nombre"],
                        Direccion = (string)row["direccion"],
                        Telefono = (string)(row["telefono"]),
                        FechaIngreso = Convert.ToDateTime(row["fechaRegistro"]),
                        Activo = Convert.ToBoolean(row["activo"])
                    });
                }
            }
            return proveedores;
        }

        public List<Proveedor> ObtenerProveedoresActivos()
        {
            var proveedores = new List<Proveedor>();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration))
            {
                SqlCommand cmd = new SqlCommand("dbo.Sp_MostrarProveedoresActivos", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlConnection.Open();
                da.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    proveedores.Add(new Proveedor
                    {
                        ProveedorId = Convert.ToInt32(row["proveedorId"]),
                        NombreProveedor = (string)row["nombre"],
                        Direccion = (string)row["direccion"],
                        Telefono = (string)(row["telefono"]),
                        FechaIngreso = Convert.ToDateTime(row["fechaRegistro"]),
                        Activo = Convert.ToBoolean(row["activo"])
                    });
                }
            }
            return proveedores;
        }
    }
}
