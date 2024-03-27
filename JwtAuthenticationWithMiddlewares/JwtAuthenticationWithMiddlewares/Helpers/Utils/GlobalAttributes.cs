namespace JwtAuthenticationWithMiddlewares.Helpers.Utils
{
    public static class GlobalAttributes
    {
        public static MySQLConfiguration mysqlConfiguration = new MySQLConfiguration();
    }

    public class MySQLConfiguration
    {
        public string connectionString { get; set; }
    }
}
