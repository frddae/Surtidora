using System.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class ClienteRepository : IClienteRepository
    {
        public string? _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            var ConectionString = configuration.GetConnectionString("Surtidora");

            _configuration = ConectionString
               ?? throw new ArgumentNullException(
                   nameof(configuration),
                   "no se encontro la cadena de conexion");
        }
        public List<Cliente> ObtenerClientes()
        {
            var clientes = new List<Cliente>();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration))
            {
                SqlCommand cmd = new SqlCommand("dbo.Sp_MostrarClientes", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                sqlConnection.Open();
                da.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clientes.Add(new Cliente
                    {
                        ClienteId = Convert.ToInt32(row["ClienteId"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Documento = row["Documento"].ToString(),
                        FechaRegistro = (DateTime)row["FechaRegistro"],
                        IsActive = Convert.ToBoolean(row["IsActive"])
                    });
                }
            }

            return clientes;
        }
        public int CrearCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(_configuration))
            {

                SqlCommand cmd = new SqlCommand("sp_CrearClientes", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Documento", cliente.Documento);

                SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(Id);

                con.Open();
                cmd.ExecuteNonQuery();
                return (int)Id.Value;
            }
        }

        public void EditarCliente(Cliente cliente)
        {
            using SqlConnection con = new SqlConnection(_configuration);
            {
                SqlCommand cmd = new SqlCommand("Sp_EditarClientes", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Documento", cliente.Documento);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool EliminarCliente(int clienteId)
        {
            using SqlConnection con = new SqlConnection(_configuration);
            {
                SqlCommand cmd = new SqlCommand("Sp_EliminarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ClienteId", clienteId);

                con.Open();
                bool filasAfectadas = cmd.ExecuteNonQuery() > 0;
                return filasAfectadas;
            }
        }
    }
}
