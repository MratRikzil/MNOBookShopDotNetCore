using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNOBookShopDotNetCore.ConsoleApp
{
    internal static class ConnectionString
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-35JA3AU\\SQLEXPRESS", 
            InitialCatalog = "BookShop", // Database
            UserID = "sa",
            Password = "sasa@123"
        };

    }
}
