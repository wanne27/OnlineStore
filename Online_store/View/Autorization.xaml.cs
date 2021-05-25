using BespokeFusion;
using Online_store.Model;
using Online_store.View;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }


        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
        public void entryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Сontext db = Сontext.GetСontext();
                if (PassBox.Password != String.Empty && LogiBox.Text != String.Empty)
                {

                    string password = PassBox.Password.GetHashCode().ToString();
                    string login = LogiBox.Text;
                    var admin = db.USERs.FirstOrDefault(x => x.Login == login && x.Password == PassBox.Password && x.Role == "Admin");
                    var user = db.USERs.FirstOrDefault(x => x.Login == login && x.Password == password && x.Role == "Client");

                    if (user != null && admin == null)
                    {
                        USER.CurrentUser = user;
                        MainWindowClient clientWin = new MainWindowClient();
                        clientWin.Show();
                        Close();
                    }
                    if (user == null && admin != null)
                    {
                        AdminWindow adminWin = new AdminWindow();
                        USER.CurrentUser = admin;
                        adminWin.Show();
                        Close();
                    }
                    if (user == null && admin == null)
                    {
                        MaterialMessageBox.ShowError("Проверьте введенные данные!");
                    }

                }
                else
                {
                    MaterialMessageBox.ShowError("Введите данные!");
                }
            }
            catch
            {
                MaterialMessageBox.ShowError("Такого аккаунта не существует!");
            }

        }
    }
}
