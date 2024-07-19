using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Trasgressori.Models;

namespace Trasgressori.DAO
{
    public class AnagraficaDAO
    {
        private readonly string _connectionString;

        public AnagraficaDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Anagrafica> GetAll()
        {
            var list = new List<Anagrafica>();

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM ANAGRAFICA";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Anagrafica
                            {
                                Idanagrafica = (int)reader["IdAnagrafica"],
                                Cognome = reader["Cognome"].ToString(),
                                Nome = reader["Nome"].ToString(),
                                Indirizzo = reader["Indirizzo"].ToString(),
                                Città = reader["Città"].ToString(),
                                CAP = reader["CAP"].ToString(),
                                Cod_Fisc = reader["Cod_Fisc"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Add(Anagrafica anagrafica)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO ANAGRAFICA (Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc) VALUES (@Cognome, @Nome, @Indirizzo, @Città, @CAP, @Cod_Fisc)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cognome", anagrafica.Cognome);
                    command.Parameters.AddWithValue("@Nome", anagrafica.Nome);
                    command.Parameters.AddWithValue("@Indirizzo", anagrafica.Indirizzo);
                    command.Parameters.AddWithValue("@Città", anagrafica.Città);
                    command.Parameters.AddWithValue("@CAP", anagrafica.CAP);
                    command.Parameters.AddWithValue("@Cod_Fisc", anagrafica.Cod_Fisc);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Analogamente, aggiungi metodi per aggiornare e eliminare le righe.
    }
}
