using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNOBookShopDotNetCore.ConsoleApp
{
    internal class DapperBookShop
    {
        public void Run()
        {
            // Read();
            //int input = Convert.ToInt32(Console.ReadLine());
            //Search(input);
            //Create(8, "Mgmg", "Hello", 280, "2010-06-25");
            Delete(8);

        }
        private void Read()
        {
            Console.WriteLine("Hi, Welcome to booksheft.");
            Console.WriteLine();
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            List<BookShopDto>  bookList= db.Query<BookShopDto>("SELECT * FROM Book_Product").ToList();

            foreach (BookShopDto item in bookList)
            {
                Console.WriteLine("BookID: " + item.BookID);
                Console.WriteLine("BookAuthor: " + item.BookAuthor);
                Console.WriteLine("BookTitle: " + item.BookTitle);
                Console.WriteLine("Price: " + item.Price+"$");
                Console.WriteLine("Distributed Date: " + item.Distributed_Date);
                Console.WriteLine("-------------------------------------------");
            }
        }
        
        private void Create(int id, string author, string title, int price, string date)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
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
           int outcome = db.Execute(query, new BookShopDto { BookID = id, BookAuthor = author, BookTitle = title, Price = price ,Distributed_Date = date}  );
           string message = outcome > 0 ? "Creating success." : "Creating fail.";
           Console.WriteLine(message);
        }
        private void Delete(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Hi, you can delete in this here.");
            var item = new BookShopDto
            {
                BookID = id
            };
            string query = @"DELETE FROM Book_Product WHERE BookID = @BookID";
            int outcome = db.Execute(query, item);
            string message = outcome > 0 ? "Deleting success." : "Deleting fail.";
            Console.WriteLine(message);

        }
        private void Search(int id)
        {
            Console.WriteLine("Hi, Welcome to booksheft. Let's find with ID.");
            Console.WriteLine();
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BookShopDto>("SELECT * FROM Book_Product WHERE BookID = @BookID", new BookShopDto { BookID = id}).FirstOrDefault();
            // same -> if (item == null)
            if(item is null)
            {
                Console.WriteLine("No data was found.");
            }

            Console.WriteLine("BookID: " + item.BookID);
            Console.WriteLine("BookAuthor: " + item.BookAuthor);
            Console.WriteLine("BookTitle: " + item.BookTitle);
            Console.WriteLine("Price: " + item.Price + "$");
            Console.WriteLine("Distributed Date: " + item.Distributed_Date);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Thank you for today.");
        }
        private void Update(int id, string author, string title, int price, string date)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Hi, you can update in this here.");
            var item = new BookShopDto
            {
                BookID = id,
                BookAuthor = author,
                BookTitle = title,
                Price = price,
                Distributed_Date = date
            };
            string query = @"UPDATE [dbo].[Book_Product]
   SET [BookID] = @BookID
      ,[BookAuthor] = @BookAuthor
      ,[BookTitle] = @BookTitle
      ,[Price] = @Price
      ,[Distributed_Date] = @Distributed_Date
 WHERE BookID = @BookID";
            int outcome = db.Execute(query, item);
            string message = outcome > 0 ? "Updating success." : "Updating fail.";
            Console.WriteLine(message);
        }
        
    }
}
