
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using System.Numerics;

List<Product> products = new List<Product>()
{
    new Product()
    {
    Name = "french horn",
    Price = 12.00M,
    ProductTypeId = 2,
    },
    new Product()
    {
    Name = "Frosted Road",
    Price = 22.00M,
    ProductTypeId = 1,
    },
    new Product()
    {
    Name = "saxaphone",
    Price = 42.00M,
    ProductTypeId = 2,
    },
    new Product()
    {
    Name = "Flowery Road",
    Price = 52.00M,
    ProductTypeId = 1,
    },
    new Product()
    {
    Name = "trumpet",
    Price = 32.00M,
    ProductTypeId = 2,
    }
};

List<ProductType> productTypes = new List<ProductType>()
    {
    new ProductType ()
    {
        Title = "Poems",
        Id = 1
    },
     new ProductType ()
    {
        Title = "Brass Instruments",
        Id = 2
    }
};

string greeting = @"Welcome to Brass and Poems Books! This is where you will find high quality poetry books and brass musical instruments to purchase and add to the list!";
Console.WriteLine(greeting);

DisplayMenu();

void DisplayMenu()
{
    string choice = null;
    while (choice == null)
    {
        Console.WriteLine(@"Choose an option:
                                1. Display All Products
                                2. Delete Product
                                3. Add Product
                                4. Update Product
                                5. Exit ");
        choice = Console.ReadLine();
        if (choice == "1")
        {
            DisplayAllProducts();
            Console.WriteLine("\n");
            DisplayMenu();
        }
        else if (choice == "2")
        {
            DeleteProduct();
        }
        else if (choice == "3")
        {
            AddProduct();
        }
        else if (choice == "4")
        {
            UpdateProduct();
        }
        else if (choice == "5")
        {
            Console.WriteLine("GoodBye!");
        }
    }

};

void DisplayAllProducts()
{
    string typeName (int productId)
    {
        ProductType filteredId = productTypes.FirstOrDefault(t => t.Id == productId);
        return filteredId.Title;
    }
  
        Console.WriteLine("List of Products:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].Name} with a price of {products[i].Price} and a title of {typeName(products[i].ProductTypeId)}");
        }
}

void DeleteProduct()
{
    DisplayAllProducts();
    string answer = "";
    Product chosen = null;
        while (chosen == null)
        {
        Console.WriteLine("\n");
        Console.WriteLine("Please enter a product number to delete: ");
            try
            {
                int response = int.Parse(Console.ReadLine().Trim());
                chosen = products[response - 1];
                Console.WriteLine(@$"Are you sure you want to delete {chosen.Name}?
                                            1. Yes
                                            2. No");
                answer = Console.ReadLine();

                if (answer == "1")
                {
                    products.RemoveAt(response - 1);
                    Console.WriteLine($"You have successfully deleted {chosen.Name}");
                DisplayMenu();
                }
                else if (answer == "2")
                {
                DisplayMenu();
                }
                else
                {
                    Console.WriteLine("Sorry, you have entered an invalid entry.");
                DisplayMenu();
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Please type only integers!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please choose an existing item only!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Do Better!");
            }
        }
}

void AddProduct()
{
    Product addedProduct = new Product()
    {
        Name = "",
        Price = 0M,
        ProductTypeId = 0
    };

    string response = "";
    bool validNumber = false;
    decimal value = 0;
    Console.WriteLine("What is the name of your product?");
    while (response == "")
    {
        response = Console.ReadLine().Trim();
        addedProduct.Name = response;
    };
    Console.WriteLine("What is the price of your product?");
    response = Console.ReadLine();
    validNumber = decimal.TryParse(response, out value);
    if (validNumber == true)
    {
        addedProduct.Price = value;
    }
    Console.WriteLine(@$"Please enter the product type title number for {addedProduct.Name}:
                        1. Poems
                        2. Brass Instruments");
    response = Console.ReadLine();
    if (response == "1")
    {
        addedProduct.ProductTypeId = 1;
    }
    else if (response == "2")
    {
        addedProduct.ProductTypeId = 2;
    }
    string typeName(int productId)
    {
        ProductType filteredId = productTypes.FirstOrDefault(t => t.Id == productId);
        return filteredId.Title;
    }
    Console.WriteLine($"Thank you for your new added product! Your product's name is {addedProduct.Name}, the price is {addedProduct.Price}, and the product type is {typeName(addedProduct.ProductTypeId)}.");
    products.Add(addedProduct);
    DisplayMenu();
}

void UpdateProduct()
{
    DisplayAllProducts();

    string answer = "";
    Product chosen = null;
    while (chosen == null)
    {
        Console.WriteLine("\n");
        Console.WriteLine("Please enter a product number to update: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim() );
            chosen = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }
        Console.WriteLine($@"Select what you would like to update: 
                            1. Name: {chosen.Name};
                            2. Price: {chosen.Price};
                            3. Product Type: {chosen.ProductTypeId}");
    answer= Console.ReadLine();
    bool thisPrice = false;
    decimal value = 0M;

    if (answer == "1")
    {
        Console.WriteLine("Please enter the name of the product: ");
        answer= Console.ReadLine().Trim();
        chosen.Name = answer;
        Console.WriteLine($"Your product has been updated to {answer}.");
        DisplayMenu();
    }
    else if (answer == "2")
    {
        Console.WriteLine($"Please enter the price of the product {chosen.Name}.");
        answer= Console.ReadLine().Trim();
        thisPrice = decimal.TryParse(answer, out value);
        if (thisPrice == true)
        {
            chosen.Price = value;
            Console.WriteLine($"Your product price has been updated to {value}.");
            DisplayMenu();
        }
        else
        {
            Console.WriteLine("You have entered an invalid entry. Please try again!");
        }
    }
    else if (answer == "3")
    {
        Console.WriteLine($@"Please choose your product type for {chosen.Name}:
                            1. Poems
                            2. Brass Instruments");
        answer = Console.ReadLine().Trim();
        if (answer == "1")
        {
            chosen.ProductTypeId = 1;
        }
        else if (answer=="2")
        {
            chosen.ProductTypeId = 2;
        }
        string typeName(int productId)
        {
            ProductType filteredId = productTypes.FirstOrDefault(t => t.Id == productId);
            return filteredId.Title;
        }
        Console.WriteLine($"You have updated your product's product type to {typeName(chosen.ProductTypeId)}");
        DisplayMenu();
    }
}

// don't move or change this!
public partial class Program { }