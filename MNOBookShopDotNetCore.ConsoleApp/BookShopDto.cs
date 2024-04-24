using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNOBookShopDotNetCore.ConsoleApp;

public class BookShopDto
{
    public int BookID { get; set; }
    public string BookAuthor { get; set; }
    public string BookTitle { get; set; }
    public int Price { get; set; }
    public string Distributed_Date {  get; set; }

}
