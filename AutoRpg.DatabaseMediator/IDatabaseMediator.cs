namespace AutoRpg.DatabaseMediator
{
    public interface IDatabaseMediator
    {
        T ExecuteScalar<T>(string query, object parameters = null);
        void Execute(string query, object parameters = null);
    }
}
