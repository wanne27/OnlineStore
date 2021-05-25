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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Online_store.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {


        Сontext db = Сontext.GetСontext();
        private ObservableCollection<Product> products;

        public MainPage()
        {
            InitializeComponent();

            db.products.Load();
            products = new ObservableCollection<Product>(db.products.ToList());
            productList.ItemsSource = products;

        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filtertext = this.TextBoxSearch.Text;
            if (filtertext != null)
            {
               Filter(filtertext);
            }
        }

        public virtual void Filter(string query)
        {                   //Динамическая фильтрация списка
            var itemView = CollectionViewSource.GetDefaultView(productList.ItemsSource);

            if (query == string.Empty)
            {
                itemView.Filter = null;
            }
            else
            {
                var queryToLower = query.ToLower();

                itemView.Filter = (item) =>
                {
                    var currentItem = item as Product;

                    if (currentItem == null)
                    {
                        return false;
                    }

                    return currentItem.Name.ToLower().Contains(queryToLower) ||
                           currentItem.Producer.ToLower().Contains(queryToLower);
                };
            }
        }

        private void AddBasket(object sender, RoutedEventArgs e)
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
              
                db.BasketProducts.Add(basketProduct);
                db.SaveChanges();
            }
            catch
            {
                MaterialMessageBox.ShowError("Товар не добавлен в корзину!");
            }
        }

        private void SortByInc(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Product> sorted = new ObservableCollection<Product>();
            sorted = new ObservableCollection<Product>(this.products.OrderBy(task => task.Price));

            productList.ItemsSource = sorted;
        }

        private void SortByDec(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Product> sorted = new ObservableCollection<Product>();
            sorted = new ObservableCollection<Product>(this.products.OrderByDescending(task => task.Price));

            productList.ItemsSource = sorted;
        }
    }
}
