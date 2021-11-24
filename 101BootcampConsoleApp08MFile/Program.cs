using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryFileExample;

namespace _101BootcampConsoleApp08MFile
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Grogery> gList = new List<Grogery>();
            gList.Add(new Grogery { Name = "Ham", Price = 10.99, Quantity = 1 });
            gList.Add(new Grogery { Name = "Egg", Price = 0.99, Quantity = 3 });
            gList.Add(new Grogery { Name = "Milk", Price = 1.99, Quantity = 2 });
            string filePath = @"c:\temp\grocery.txt";

            bool IsContinue = true;
            while (IsContinue) {
                Console.WriteLine("View list (v), Remove from list(r), Add to list(a), Write file (w), Clear file (c), Exit Program (x)");

                string _input = Console.ReadLine();
                if (_input.ToLower() == "v")
                {
                    Console.WriteLine("Key\t\t\t\t\t\tName\t\tPrice\t\tQuantity");
                    foreach (var item in gList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", item.Key, item.Name, item.Price, item.Quantity);
                    }
                }
                else if (_input.ToLower() == "w")
                {
                    // append to file
                    if (File.Exists(filePath))
                    {
                        foreach (var item in gList)
                        {
                            string s = "Name " + item.Name + ", Price " + item.Price + ", Quantity " + item.Quantity;
                            File.AppendAllText(filePath, s);
                        }
                    } // create
                    else {

                        StreamWriter sw = new StreamWriter(filePath);
                        foreach (var item in gList)
                        {
                            string s = "Name " + item.Name + ", Price " + item.Price + ", Quantity " + item.Quantity;
                            sw.WriteLine(s);
                        }
                        sw.Close();                    
                    }
                }
                else if (_input.ToLower() == "c")
                {
                    File.WriteAllText(filePath, String.Empty);
                    TextWriter tw = new StreamWriter(filePath, true);
                    tw.WriteLine("");
                    tw.Close();
                }
                else if (_input.ToLower() == "x")
                {
                    IsContinue = false;
                }
                else if (_input.ToLower() == "a")
                {
                    Console.WriteLine("Enter the name of the grocery item");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the price of the grocery item");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter the quantity of the grocery item");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    gList.Add(new Grogery { Name = name, Price = price, Quantity = quantity });
                }
                else if (_input.ToLower() == "r")
                {
                    Console.WriteLine("Enter Key for the grocery item to remove");
                    string key = Console.ReadLine();
                    gList.Remove(gList.Find(glist => glist.Key == key));
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");                
                }            
            }
        }
    }
}
