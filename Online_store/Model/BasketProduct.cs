using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_store.Model
{
    class BasketProduct
    {
        public int Id { get; set; }
        public virtual CLIENT Client { get; set; }
        public int? ClientId { get; set; }
        public virtual Product Computers{get;set;}
        public int? ComputersId { get; set; }
    }
}
