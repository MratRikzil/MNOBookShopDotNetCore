using MNOBookShopDotNetCore.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {

        AdoBookDotNetExample adoBookDotNetExample = new AdoBookDotNetExample();
        // adoBookDotNetExample.Update(7, "Patrick King", "Real People Like a Book", 400, "06 / 10 / 2020");
        //adoBookDotNetExample.Delete(7);
        //adoBookDotNetExample.Read();
         //adoBookDotNetExample.Create(7, "Patrick King", "Real People Like a Book", 400, "06/10/2020");
        // adoBookDotNetExample.Search(7);
        //int input = Convert.ToInt32(Console.ReadLine());
        //adoBookDotNetExample.Search(input);

      //  adoBookDotNetExample.Read();
        
        DapperBookShop dapperBookShop = new DapperBookShop();
        dapperBookShop.Run();

        Console.ReadKey();

    }
}