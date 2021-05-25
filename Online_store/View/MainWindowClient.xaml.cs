using Online_store.Pages;
using Online_store.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Online_store
{
    /// <summary>
    /// Логика взаимодействия для MainWindowClient.xaml
    /// </summary>
    public partial class MainWindowClient : Window, INotifyPropertyChanged
    {
        
        public MainWindowClient()
        {
            InitializeComponent();
            DataContext = new MainClientViewModel();
        }

        public void basket_shop(object sender, RoutedEventArgs e)
        {

        }
       
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }
    }

}
