using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        private static string connectionString = "Data Source=localhost;Initial Catalog=games;Integrated Security=True";

        public static bool InserisciVideogame(Videogame videogame)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (name) VALUES (@Name);";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Name", videogame.Name));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if(rowsAffected > 0)
                    {
                        return true;
                    }

                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public static Videogame GetVideogameById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                string query = "SELECT id, name FROM videogames WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Videogame(reader.GetInt32(0), reader.GetString(1));

                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static bool DeleteVideogame(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM Videogames WHERE id = @id", connection);
                
                command.Parameters.Add(new SqlParameter("@Id", id));
                int affectedRows = command.ExecuteNonQuery();
                
                if(affectedRows > 0)
                {
                    return true;
                }
                
            }

            return false;
        }

    }
}
