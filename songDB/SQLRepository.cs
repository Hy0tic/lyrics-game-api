 using System.Data.SqlClient;

namespace songDB;
public class SQLRepository
{
    private readonly string ConnectionStrings;
    public SQLRepository(string connectionStrings)
    {
        ConnectionStrings = connectionStrings;
    }

    public void AddSong()
    {
        string sqlQuery = "";
        using (SqlConnection conn = new SqlConnection(ConnectionStrings))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@name", "");
            command.Parameters.AddWithValue("@album", "");

            command.ExecuteNonQuery();
        }

        return;
    }

    public void GetRandomSong()
    {
        string sqlQuery = "";

        using (SqlConnection con = new SqlConnection(ConnectionStrings))
        {
            con.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

            }

        } 

        return;
    }
}
