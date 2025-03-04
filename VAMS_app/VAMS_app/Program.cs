using VAMS_app;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        CarLinkedList carList = new CarLinkedList();

        Console.Write("\n\t\t\t\t\t\t------SL Auction------");
        Console.WriteLine("\nChoose an operation:\n");
        Console.Write("Admin : "); Console.WriteLine("\t\t\t\tCustomers :\n");
        Console.Write("1. Add a Vehicle "); Console.WriteLine("\t\t\t5. Search(In detail)");
        Console.Write("2. Auction"); Console.WriteLine("\t\t\t\t6. Place bids");
        Console.Write("3. Display Vehicle list"); Console.WriteLine("\t\t\t7. Exit");
        Console.WriteLine("4. Delete a Vehicle");
        Console.WriteLine("7. Exit");

        while (true)
        {
            Console.WriteLine();
            Console.Write("Enter your response : ");
            string x = Console.ReadLine();
            Console.WriteLine();

            switch (x)
            {
                case "1":
                    Console.WriteLine("----Adding Vehicle----");
                    Console.Write("Vehicle Brand : ");
                    string brand = Console.ReadLine();

                    Console.Write("Vehicle Model : ");
                    string model = Console.ReadLine();

                    Console.Write("Vehicle Year : ");
                    int year = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Mileage(km) : ");
                    int mileage = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Reserve Price for the vehicle : $");
                    int reservePrice = Convert.ToInt32(Console.ReadLine());

                    carList.Insert(brand, model, year, mileage, reservePrice);
                    Console.WriteLine("Vehicle is added.");
                    break;

                case "2":
                    Console.Write("Enter Vehicle ID to start auction: ");
                    int auctionCarId = int.Parse(Console.ReadLine());
                    carList.Auction(auctionCarId);
                    break;



                case "3":
                    Console.WriteLine("Filter : \n d - current list \n a - Alphebetic  \n p - Price \n y- year");
                    Console.Write("\nEnter your response : ");
                    string y = Console.ReadLine()?.ToLower();
                    switch (y)
                    {

                        case "d":
                            Console.WriteLine("\n-----Current Vehicle List-----");
                            carList.Display();
                            break;
                        case "a":
                            Console.WriteLine("\n-----Current Vehicle List(Alphebetic)-----");
                            carList.DisplaySortedByBrandAndModel();
                            break;
                        case "p":
                            Console.WriteLine("\n-----Current Vehicle List(Price)-----");
                            carList.SortByPrice();
                            carList.Display();
                            break;
                        case "y":
                            Console.WriteLine("\n-----Current Vehicle List(Year)-----");
                            carList.DisplaySortedByYear();
                            break;
                    }
                    break;

                case "4":
                    Console.WriteLine("Enter the ID of the car to delete:");
                    int deleteId = int.Parse(Console.ReadLine());
                    if (carList.Delete(deleteId))
                    {
                        Console.WriteLine("Car deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Car not found.");
                    }
                    break;

                case "5":
                    carList.Find();
                    break;

                case "6":
                    Console.Write("Enter Vehicle ID to bid on: ");
                    int carId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Your Name: ");
                    string bidderName = Console.ReadLine();
                    Console.Write("Enter Bid Amount: ");
                    int bidAmount = int.Parse(Console.ReadLine());

                    carList.PlaceBid(carId, bidderName, bidAmount);
                    break;

                case "7":
                    Console.WriteLine("Exiting From the Auction");
                    return;

                default:
                    Console.WriteLine("Invalid Response!!!");
                    break;
            }

        }
    }
}
