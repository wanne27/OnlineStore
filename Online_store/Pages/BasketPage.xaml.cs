using BespokeFusion;
using Online_store.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Online_store.Pages
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    /// public class CheckBoxViewModel {


    public partial class BasketPage : Page, INotifyPropertyChanged
    {
        private decimal sum = 0;
        public decimal Sum
        {
            get
            {
                return sum;

            }
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }

        private int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        Сontext db = Сontext.GetСontext();
        private ObservableCollection<object> items { get; set; }


        public string productName = string.Empty;

        private ObservableCollection<Order> preOrder { get; set; }

        private ObservableCollection<Order> PreOrder
        {
            get { return preOrder; }
            set
            {
                preOrder = value;
            }
        }

        private ObservableCollection<Order> order { get; set; }

        private ObservableCollection<Order> Order
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }
         private DatePicker picker { get; set; }

        public BasketPage()
        {
            InitializeComponent();
            this.DataContext = this;
           
          
            int a = (int)USER.CurrentUser.ClientId;

            items = new ObservableCollection<object>(db.products.Join(db.BasketProducts.Where(x => x.ClientId == a),
                p => p.Id,
                c => c.ComputersId,
                (p, c) => new
                {
                    p.Name,
                    p.Price,
                    p.Producer,
                    p.AvatarPath,
                    p.Type
                }));
           
            basketList.ItemsSource = items;
            PreOrder = new ObservableCollection<Order>();
            Order = new ObservableCollection<Order>(db.Orders.Where(x => x.ClientId == a && x.Sum != null));
            ItemOrder.ItemsSource = Order;
            datePicker.Language = XmlLanguage.GetLanguage("ru-RU");
        }

        private void Check_Order(object sender, RoutedEventArgs e)
        {
            string productName = string.Empty;
            CheckBox checkBox = (CheckBox)sender;
            StackPanel panel = (StackPanel)checkBox.Parent;
            foreach (UIElement uI in panel.Children)
            {
                if (uI is TextBlock)
                {
                    productName = (uI as TextBlock).Text;
                    break;
                }
            }

            Product productFind = db.products.First(prod => prod.Name == productName);

            Order orderProduct = new Order
            {
                Client = USER.CurrentUser.Client,
                ClientId = USER.CurrentUser.ClientId,
                Products = productFind,
                ProductsId = productFind.Id

            };
            PreOrder.Add(orderProduct);
            Sum += productFind.Price;
            Count += 1;
        }

        private void UnCheck_Order(object sender, RoutedEventArgs e)
        {
            string productName = string.Empty;
            CheckBox checkBox = (CheckBox)sender;
            StackPanel panel = (StackPanel)checkBox.Parent;
            foreach (UIElement uI in panel.Children)
            {
                if (uI is TextBlock)
                {
                    productName = (uI as TextBlock).Text;
                    break;
                }
            }

            Product productFind = db.products.First(prod => prod.Name == productName);

            Order orderProduct = new Order
            {
                Client = USER.CurrentUser.Client,
                ClientId = USER.CurrentUser.ClientId,
                Products = productFind,
                ProductsId = productFind.Id,

            };


            PreOrder.Remove(orderProduct);
            Sum -= productFind.Price;
            Count -= 1;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            int value = rand.Next(1, 1000);
            var now = DateTime.Now;
            
            try
            {

                var date = datePicker.SelectedDate.Value.Date;

                if (date >= now && preOrder.Count!=0)
                {
                    foreach (Order x in PreOrder)
                    {
                        x.OrderId = 2 + value;
                        x.Date = date;
                    }
                    Order orderProduct = new Order
                    {
                        Client = USER.CurrentUser.Client,
                        ClientId = USER.CurrentUser.ClientId,
                        OrderId = 2 + value,
                        Sum = sum,
                        IsReady = false,
                        Date = date,
                        Count = count,
                    };
                    PreOrder.Add(orderProduct);
                    foreach (Order x in preOrder)
                    {
                        if (x.ProductsId != null)
                        {
                            BasketProduct deletedProdut = db.BasketProducts.First(p => p.ComputersId == x.ProductsId);

                            db.BasketProducts.Remove(deletedProdut);
                        }
                    }
                    foreach (Order x in PreOrder)
                    {
                        db.Orders.Add(x);
                    }
                    db.SaveChanges();
                }
                else
                {
                    MaterialMessageBox.ShowError("Выберете другую дату поставки или добавьте товар!");
                    return;
                }
    
            }
            catch
            {
                MaterialMessageBox.ShowError("Выберете дату поставки или товар!");
                return;
            }
            items = new ObservableCollection<object>(db.products.Join(db.BasketProducts.Where(x => x.ClientId == USER.CurrentUser.ClientId),
             p => p.Id,
             c => c.ComputersId,
             (p, c) => new
             {
                 p.Name,
                 p.Price,
                 p.Producer,
                 p.AvatarPath,
                 p.Type
             }));
            datePicker.SelectedDate = null;
            basketList.ItemsSource = items;
            PreOrder.Clear();
            MessageBox.Show("Заказ добавлен, ожидайте потверждения статуса!");


        }

        private void DelBascket(object sender, RoutedEventArgs e)
        {
            try
            {
                string productName = string.Empty;
                Button button = (Button)sender;
                StackPanel panel = (StackPanel)button.Parent;
                foreach (UIElement uI in panel.Children)
                {
                    if (uI is TextBlock)
                    {
                        productName = (uI as TextBlock).Text;
                        break;
                    }
                }

                Product computerFind = db.products.First(prod => prod.Name == productName);

                BasketProduct basketProduct = new BasketProduct
                {
                    Client = USER.CurrentUser.Client,
                    ClientId = USER.CurrentUser.ClientId,
                    Computers = computerFind,
                    ComputersId = computerFind.Id
                };
                foreach (BasketProduct basket in db.BasketProducts.ToList())
                {
                    if (basket == db.BasketProducts.Where(x => x.ComputersId == basketProduct.ComputersId).FirstOrDefault())
                        db.BasketProducts.Remove(basket);
                }
                db.SaveChanges();
                items = new ObservableCollection<object>(db.products.Join(db.BasketProducts.Where(x => x.ClientId == USER.CurrentUser.ClientId),
                   p => p.Id,
                   c => c.ComputersId,
                   (p, c) => new
                   {
                       p.Name,
                       p.Price,
                       p.Producer,
                       p.AvatarPath,
                       p.Type
                   }));

                basketList.ItemsSource = items;
            }
            catch
            {
                MessageBox.Show("Повторите попытку!");
            }
        }
    }
}
