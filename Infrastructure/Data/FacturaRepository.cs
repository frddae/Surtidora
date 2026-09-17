using Core.Entities;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Data
{
    public class FacturaRepository : IFacturaRepository
    {
        public string? _configuration;

        public FacturaRepository(IConfiguration configuration)
        {
            var ConectionString = configuration.GetConnectionString("Surtidora");

            _configuration = ConectionString
               ?? throw new ArgumentNullException(
                   nameof(configuration),
                   "no se encontro la cadena de conexion");
        }
        public List<Factura> ObtenerFacturas()
        {
            List<Factura> facturas = new List<Factura>();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration))
            {
                SqlCommand cmd = new SqlCommand("dbo.Sp_MostrarFactura", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                DataSet ds = new DataSet();
                using SqlDataAdapter da = new SqlDataAdapter(cmd);

                sqlConnection.Open();
                da.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    facturas.Add(new Factura
                    {
                        FacturaId = Convert.ToInt32(row["FacturaId"]),
                        ClienteId = Convert.ToInt32(row["ClientId"]),
                        FechaFactura = (DateTime)row["FechaFactura"],
                        Monto = Convert.ToInt32(row["Monto"]),
                        Comentario = row["Comentario"].ToString(),
                    });
                }
            }
            return facturas;
        }
    }
}
