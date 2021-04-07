using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("View list (v), Write file (w), Clear file (c), Exit Program (x)");

                string _input = Console.ReadLine();
                if (_input.ToLower() == "v")
                {
                    foreach (var item in gList)
                    {
                        Console.WriteLine("Name {0}, Price {1}, Quantity {2}", item.Name, item.Price, item.Quantity);
                    }
                }
                else if (_input.ToLower() == "w")
                {
                    // create or append to file
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
                else
                {
                    Console.WriteLine("Invalid input. Try again.");                
                }
            
            }

        }
    }
}
