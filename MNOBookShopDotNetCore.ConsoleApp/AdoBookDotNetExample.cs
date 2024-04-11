using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNOBookShopDotNetCore.ConsoleApp
{
    internal class AdoBookDotNetExample
    {
        // CRUD methods including you can search with ID.
        private readonly SqlConnectionStringBuilder _sqlStringBuilder = new SqlConnectionStringBuilder()
        { 
            DataSource = "DESKTOP-35JA3AU\\SQLEXPRESS",
            InitialCatalog = "BookShop",
            UserID = "sa",
            Password = "sasa@123"

        };

        public void Create(int id, string author, string title, int price, string date)
        {
            SqlConnection bookConnection = new SqlConnection(_sqlStringBuilder.ConnectionString);
            bookConnection.Open();
            Console.WriteLine("Hi, Welcome to create booksheft.");
            string query = @"
INSERT INTO [dbo].[Book_Product]
           ([BookID]
           ,[BookAuthor]
           ,[BookTitle]
           ,[Price]
           ,[Distributed_Date])
     VALUES
           (@BookID
           ,@BookAuthor
           ,@BookTitle
           ,@Price
           ,@Distributed_Date)";

            SqlCommand cmd = new SqlCommand(query, bookConnection);

            cmd.Parameters.AddWithValue("@BookID", id);
            cmd.Parameters.AddWithValue("@BookAuthor", author);
            cmd.Parameters.AddWithValue("@BookTitle", title);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Distributed_Date", date);
            int outcome = cmd.ExecuteNonQuery();
            string message = outcome > 0 ? "Creating success." : "Creating fail.";
            Console.WriteLine(message);


            bookConnection.Close();
            Console.WriteLine("Thank you for today.");
        }


        public void Read()
        {
            SqlConnection bookConnection = new SqlConnection(_sqlStringBuilder.ConnectionString);
            bookConnection.Open();
            Console.WriteLine("Hi, Welcome to booksheft.");
            Console.WriteLine();

            string query = "SELECT * FROM Book_Product";

            SqlCommand cmd= new SqlCommand(query, bookConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                Console.WriteLine("BookID: " + dr[0]);
                Console.WriteLine("BookAuthor: " + dr[1]);
                Console.WriteLine("BookTitle: " + dr[2]);
                Console.WriteLine("Price: " + dr[3]);
                Console.WriteLine("Distributed Date: " + dr[4]);
                Console.WriteLine("-------------------------------------------");
            }

            bookConnection.Close();
            Console.WriteLine("Thank you for today.");

        }

        public void Update(int id ,string author, string title, int price, string date) 
        {
            SqlConnection bookConnection = new SqlConnection(_sqlStringBuilder.ConnectionString);
            bookConnection.Open();
            Console.WriteLine("Hi, you can update in this here.");

            string query = @"UPDATE [dbo].[Book_Product]
   SET [BookID] = @BookID
      ,[BookAuthor] = @BookAuthor
      ,[BookTitle] = @BookTitle
      ,[Price] = @Price
      ,[Distributed_Date] = @Distributed_Date
 WHERE BookID = @BookID";
            SqlCommand cmd = new SqlCommand(query, bookConnection);
            cmd.Parameters.AddWithValue("@BookID", id);
            cmd.Parameters.AddWithValue("@BookAuthor", author);
            cmd.Parameters.AddWithValue("@BookTitle", title);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Distributed_Date", date);
            int outcome = cmd.ExecuteNonQuery();
            string message = outcome > 0 ? "Updating success." : "Updating fail.";
            Console.WriteLine(message);


            bookConnection.Close();
            Console.WriteLine("Thank you for today.");
        }
        
        public void Delete(int id)
        {
            SqlConnection bookConnection = new SqlConnection( _sqlStringBuilder.ConnectionString);  
            bookConnection.Open();
            Console.WriteLine("Hi, you can delete in this here.");

            string query = @"DELETE FROM Book_Product WHERE BookID = @BookID";

            SqlCommand cmd = new SqlCommand(query, bookConnection);
            cmd.Parameters.AddWithValue("BookID", id);
            int outcome = cmd.ExecuteNonQuery();
            string message = outcome > 0 ? "Deleting success." : "Deleting fail.";
            Console.WriteLine(message);

            bookConnection.Close();
            Console.WriteLine("Thank you for today");
        }
        public void Search(int id)
        {
            SqlConnection bookConnection = new SqlConnection(_sqlStringBuilder.ConnectionString);
            bookConnection.Open();
            Console.WriteLine("Hi, Welcome to booksheft. Let's find with ID.");
            Console.WriteLine();

            string query = "SELECT * FROM Book_Product WHERE BookID = @BookID";
            SqlCommand cmd = new SqlCommand(query, bookConnection);
            cmd.Parameters.AddWithValue("@BookID",id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data was found.");
                return;
            }

            DataRow dr = dt.Rows[0];
            
             Console.WriteLine("BookID: " + dr[0]);
             Console.WriteLine("BookAuthor: " + dr[1]);
             Console.WriteLine("BookTitle: " + dr[2]);
             Console.WriteLine("Price: " + dr[3]);
             Console.WriteLine("Distributed Date: " + dr[4]);
             Console.WriteLine("-------------------------------------------");
            

            bookConnection.Close();
            Console.WriteLine("Thank you for today.");

        }
    }
}
