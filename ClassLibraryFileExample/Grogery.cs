using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFileExample
{

    public class Grogery
    {

        public string Key { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Grogery() 
        {            
            Key = Guid.NewGuid().ToString();
        
        }
    }

}
