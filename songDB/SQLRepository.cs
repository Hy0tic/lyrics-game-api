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
        var sqlQuery = "";
        using (SqlConnection conn = new SqlConnection(ConnectionStrings))
        {
            conn.Open();

            var command = new SqlCommand(sqlQuery, conn);
            command.Parameters.AddWithValue("@name", "");
            command.Parameters.AddWithValue("@album", "");
            command.Parameters.AddWithValue("@mp3", "");
            command.Parameters.AddWithValue("@artist", "");
            command.Parameters.AddWithValue("@lyrics", "");

            command.ExecuteNonQuery();
        }

        return;
    }

    public void GetRandomSong()
    {
        var sqlQuery = "";

        using (var con = new SqlConnection(ConnectionStrings))
        {
            con.Open();
            
            var command = new SqlCommand(sqlQuery, con);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {

            }
        } 

        return;
    }
}
