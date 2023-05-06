
using System.IO.Pipes;
using System.Reflection.Metadata;
using System.Text.Json;
public static class Increment{
  static  public int I { get; set; }

   static public int IncreasedNum()
    {
        return ++I;
    } 
}
public struct Article
{
    public Article(string? productName, float price)
    {
        ProductName = productName;
        Price = price;
        ProductCode=Increment.IncreasedNum();
    }
    public int ProductCode { get; set; }
    public string? ProductName { get; set; }
    public float Price { get; set; }
    public override string ToString()
    {
        return $"Code:{ProductCode}\nName:{ProductName}\nPrice:{Price}\n";
    }
}


public struct Client
{
    public Client( string? fullName, string? telephone, string? adress, int numberOfOrders)
    {
        ClientCode ++;
        FullName = fullName;
        Telephone = telephone;
        Adress = adress;
        NumberOfOrders = numberOfOrders;
    }

    public static int? ClientCode { get; set; } = 0;
    public string? FullName { get; set; }
    public string? Telephone { get; set; }
    public string? Adress { get; set; }
    public int? NumberOfOrders { get; set; }

    public override string ToString()
    {
        return $"\nClient code:{ClientCode}" +
               $"\nFull name:{FullName}" +
               $"\nTelephone number{Telephone}" +
               $"\nAdress{Adress}" +
               $"\nNumber of orders{NumberOfOrders}";
    }
}
public class PapaJohns
{
    public PapaJohns()
    {
        Articles = new List<Article> { };
        GenerateArticles();
    }
    public List<Article> Articles { get; set; }

    public void ShowProducts()
    {
        foreach (var item in Articles)
        {
            Console.WriteLine(item);
        }
    }
    public void AddArticles(Article newProduct)
    {
        Articles.Add(newProduct);
    }
    private void GenerateArticles()
    {
        Articles.Add(new Article("Margarita", 10));
        Articles.Add(new Article("Sasisqali", 7));
        Articles.Add(new Article("Mexican Fire", 14));
        Articles.Add(new Article("Pepperoni", 8));
        Articles.Add(new Article("full Bibeerli", 9));
        Articles.Add(new Article("Ananasli", 9));
    }
    public void Zakaz(Client client, int productCode)
    {
        Console.WriteLine($"Clients info:\n{client}\n\nOrdered:\n{Articles[productCode-1]}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        PapaJohns johns = new PapaJohns();
        johns.ShowProducts();
        johns.Zakaz(new Client("ELgun", "0504588595", "Nerimanov life center", 1), 1);
    }
}