namespace songDB;
public class SQLRepository
{
    private readonly string ConnectionStrings;
    public SQLRepository(string connectionStrings)
    {
        ConnectionStrings = connectionStrings;
    }
}
