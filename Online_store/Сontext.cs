using Online_store.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_store
{
    class Сontext : DbContext
    {
        private Сontext()
            :base("DbConnection")
        { }
        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<CLIENT> CLIENTs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> products { get; set; }
  
        public virtual DbSet<BasketProduct> BasketProducts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { }

        private static Сontext сontext;

        public static Сontext GetСontext()
        {
            if(сontext == null)
            {
                сontext = new Сontext();
            }
            return сontext;
        }

        internal BasketProduct BasketProduct
        {
            get => default(BasketProduct);
            set
            {
            }
        }

        public CLIENT CLIENT
        {
            get => default(CLIENT);
            set
            {
            }
        }

        internal Order Order
        {
            get => default(Order);
            set
            {
            }
        }

        internal Product Product
        {
            get => default(Product);
            set
            {
            }
        }

        public USER USER
        {
            get => default(USER);
            set
            {
            }
        }
    }
}
