using Trasgressori.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Trasgressori.DAO
{
    public class TipoViolazioneDAO
    {
        private readonly string _connectionString;

        public TipoViolazioneDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<TipoViolazione> GetAll()
        {
            var list = new List<TipoViolazione>();

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM TIPO_VIOLAZIONE";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TipoViolazione
                            {
                                IdViolazione = (int)reader["Idviolazione"],
                                Descrizione = reader["Descrizione"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Add(TipoViolazione tipoViolazione)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO TIPO_VIOLAZIONE (Descrizione) VALUES (@Descrizione)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Descrizione", tipoViolazione.Descrizione);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
