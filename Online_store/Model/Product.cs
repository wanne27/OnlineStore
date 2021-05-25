using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_store.Model
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; }
        public int QuantityInStock { get; set; }
        public string AvatarPath { get; set; }
        public string Type { get; set; }
       public Product()
       {
            Name = "name";
            Price = 0;
            Producer = "produser";
            QuantityInStock = 0;   
       }

    }
}
