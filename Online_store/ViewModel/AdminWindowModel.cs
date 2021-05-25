using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Online_store.Model;
using System.Collections.ObjectModel;

using System.Runtime.Remoting.Contexts;
using System.ComponentModel;
using Microsoft.Win32;
using BespokeFusion;

namespace Online_store.ViewModel
{


    class AdminWindowModel : BaseViewModel
    {
        public string Computer = "Computer";
        public string Laptop = "Laptop";
        public string Phone = "Phone";
        public string TV = "TV";
        public string Monitor = "Monitor";
        public string Audio = "Audio";
        public string PhotoVideo = "PhotoVideo";
        public string MouseKeyboard = " MouseKeyboard";

        public ObservableCollection<object> dataProducts { get; set; }

        public ObservableCollection<object> DataProducts
        {
            get { return dataProducts; }
            set
            {
                dataProducts = value;
                OnPropertyChanged("DataProducts");
            }
        }

        public ObservableCollection<object> dataUsers { get; set; }

        public ObservableCollection<object> DataUsers
        {
            get { return dataUsers; }
            set
            {
                dataUsers = value;
                OnPropertyChanged("DataUsers");
            }
        }

        private int selectedTabItem;

        public int SelectedTabItem
        {
            get { return selectedTabItem; }
            set
            {
                selectedTabItem = value;
                OnPropertyChanged("SelectedTabItem");
                if (selectedTabItem == 0)
                    ShowProduct(Computer);

                if (selectedTabItem == 1)
                    ShowUsers();
            }
        }

        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
                if (selectedIndex == 0)
                    ShowProduct(Computer);
                if (selectedIndex == 1)
                    ShowProduct(Laptop);
                if (selectedIndex == 2)
                    ShowProduct(Phone);
                if (selectedIndex == 3)
                    ShowProduct(TV);
                if (selectedIndex == 4)
                    ShowProduct(Monitor);
                if (selectedIndex == 5)
                    ShowProduct(Audio);
                if (selectedIndex == 6)
                    ShowProduct(PhotoVideo);
                if (selectedIndex == 7)
                    ShowProduct(MouseKeyboard);
            }

        }

        private object selectedProducts;

        public object SelectedProductes
        {
            get { return selectedProducts; }
            set
            {
                selectedProducts = value;
                OnPropertyChanged("SelectedProductes");
            }
        }
        private object selectedOrder;

        public object SelecterOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelecterOrder");
            }
        }
        public ObservableCollection<object> dataOrder { get; set; }

        public ObservableCollection<object> DataOrder
        {
            get { return dataOrder; }
            set
            {
                dataOrder = value;
                OnPropertyChanged("DataOrder");
            }
        }
        public ObservableCollection<Product> сoncreteOrder { get; set; }
        public ObservableCollection<object> Neutral { get; set; }
        public ObservableCollection<Product> СoncreteOrder
        {
            get { return сoncreteOrder; }
            set
            {
                сoncreteOrder = value;
                OnPropertyChanged("СoncreteOrder");
            }
        }
        public Сontext db = Сontext.GetСontext();

        public AdminWindowModel()
        {

            ShowProduct(Computer);
            SaveProduct = new RelayCommand(Save_Product);
            AddProduct = new RelayCommand(Add_Product);
            DeleteProduct = new RelayCommand(Delete_Product);
            ShowOrder = new RelayCommand(Show_Order);
            DataOrder = new ObservableCollection<object>(db.Orders.Where(x => x.Sum != null).ToList());
            SaveOrder = new RelayCommand(Save_Order);
            СoncreteOrder = new ObservableCollection<Product>();
        }

        public void Show_Order()
        {
            try
            {
                СoncreteOrder.Clear();
                Order order = (Order)SelecterOrder;
                Neutral = new ObservableCollection<object>(db.Orders.Where(x => x.OrderId == order.OrderId && x.Sum == null));

                foreach (Product x in db.products.ToList())
                {
                    foreach (Order n in Neutral)
                    {
                        if(x.Id == n.ProductsId)
                            СoncreteOrder.Add(x);
                    }

                }
            }
            catch
            {
                MaterialMessageBox.ShowError("Выделите объект для поиска");
                return;
            }
        }

        public void ShowProduct(string type)
        {

            DataProducts = new ObservableCollection<object>(db.products.Where(x => x.Type == type).ToList());

        }

        public void ShowUsers()
        {

            DataUsers = new ObservableCollection<object>(db.CLIENTs.ToList());

        }

        public void Save_Order()
        {
            db.SaveChanges();
        }

        public void Save_Product()
        {
            foreach (Product x in dataProducts)
            {
                if (x.Name == "name" && x.Price == 0 && x.Producer == "produser" && x.QuantityInStock == 0)
                {
                    MaterialMessageBox.ShowError("Заполните  данные о товаре!");
                    return;
                }
            }

            db.SaveChanges();
        }

        public void Add_Product()
        {

            if (selectedIndex == 0)
            {
                string productImage = OpenFileDialog();
                if (productImage == string.Empty)
                {
                    return;
                }
                Product product = new Product();
                product.AvatarPath = productImage;
                product.Type = Computer;
                DataProducts.Add(product);

                db.products.Add(product);

            }

            if (selectedIndex == 1)
            {
                string productImage = OpenFileDialog();
                if (productImage == string.Empty)
                {
                    return;
                }
                Product product = new Product();
                product.AvatarPath = productImage;
                product.Type = Laptop;
                DataProducts.Add(product);

                db.products.Add(product);

            }

            if (selectedIndex == 2)
            {
                string productImage = OpenFileDialog();
                if (productImage == string.Empty)
                {
                    return;
                }
                Product product = new Product();
                product.AvatarPath = productImage;
                product.Type = Phone;
                DataProducts.Add(product);

                db.products.Add(product);

            }

            if (selectedIndex == 3)
            {
                string productImage = OpenFileDialog();
                if (productImage == string.Empty)
                {
                    return;
                }
                Product product = new Product();
                product.AvatarPath = productImage;
                product.Type = TV;
                DataProducts.Add(product);

                db.products.Add(product);

            }

            if (selectedIndex == 4)
            {
                string productImage = OpenFileDialog();
                if (productImage == string.Empty)
                {
                    return;
                }
                Product product = new Product();
                product.AvatarPath = productImage;
                product.Type = Monitor;
                DataProducts.Add(product);

                db.products.Add(product);

            }

            if (selectedIndex == 5)
            {
                string productImage = OpenFileDialog();
                if (productImage == string.Empty)
                {
                    return;
                }
                Product product = new Product();
                product.AvatarPath = productImage;
                product.Type = Audio;
                DataProducts.Add(product);

                db.products.Add(product);

            }

            if (selectedIndex == 6)
            {
                string productImage = OpenFileDialog();
                if (productImage == string.Empty)
                {
                    return;
                }
                Product product = new Product();
                product.AvatarPath = productImage;
                product.Type = PhotoVideo;
                DataProducts.Add(product);

                db.products.Add(product);

            }

            if (selectedIndex == 7)
            {
                string productImage = OpenFileDialog();
                if (productImage == string.Empty)
                {
                    return;
                }
                Product product = new Product();
                product.AvatarPath = productImage;
                product.Type = MouseKeyboard;
                DataProducts.Add(product);

                db.products.Add(product);

            }

        }
        public string OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg;*.jfif";

            if (openFileDialog.ShowDialog() == true)
            {

                return openFileDialog.FileName;
            }
            return string.Empty;
        }


        public void Delete_Product()
        {

            try
            {
                Product product = (Product)SelectedProductes;

                Product deletedProdut = (Product)DataProducts.First(p =>
                {
                    return ((Product)p).Id == product.Id;
                });


                DataProducts.Remove(deletedProdut);
              
                foreach(Order order in db.Orders.ToList())
                {
                   if(order == db.Orders.Where(x => x.ProductsId == deletedProdut.Id).FirstOrDefault())
                    db.Orders.Remove(order);
                }

                foreach (BasketProduct basket in db.BasketProducts.ToList())
                {
                    if (basket == db.BasketProducts.Where(x => x.ComputersId == deletedProdut.Id).FirstOrDefault())
                        db.BasketProducts.Remove(basket);
                }

                
               
                db.products.Remove(deletedProdut);
            }
            catch
            {
                MaterialMessageBox.ShowError("Выделите товар!");
                return;
            }

        }

        public ICommand AddProduct { get; set; }
        public ICommand SaveProduct { get; set; }
        public ICommand DeleteProduct { get; set; }
        public ICommand ShowOrder { get; set; }
        public ICommand SaveOrder { get; set; }

        public View.AdminWindow AdminWindow
        {
            get => default(View.AdminWindow);
            set
            {
            }
        }
    }
}
