using System;
using OOP;

class MainProgram
{
    public static void Main()
    {
        // Pagkuha ng user input
        Console.WriteLine("Enter product name: ");
        string productName = Console.ReadLine();  // Kukunin ang pangalan ng produkto

        Console.WriteLine("Enter product price:");
        int productPrice = int.Parse(Console.ReadLine());  // Kukunin ang presyo ng produkto

        Console.WriteLine("Enter product description:");
        string productDescription = Console.ReadLine();  // Kukunin ang description ng produkto

        // Pag-create ng instance ng InsertNewProduct
        OOP.ManageProduct.InsertNewProduct insertNewProduct = new OOP.ManageProduct.InsertNewProduct();

        // Pag-insert ng data sa database gamit ang user input
        insertNewProduct.InsertData(productName, productPrice, productDescription);

    }
}
