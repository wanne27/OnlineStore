using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_store.Model
{
    class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual CLIENT Client { get; set; }
        public int? ClientId { get; set; }
        public virtual Product Products { get; set; }
        public int? ProductsId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Sum { get; set; }
        public int? Count { get; set; }
        public bool? IsReady { get; set; }
    }
}
