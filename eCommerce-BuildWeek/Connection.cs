using System.Configuration;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public static class Connection
    {
        public static SqlConnection ConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["eCommerce"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;

        }
    }
}