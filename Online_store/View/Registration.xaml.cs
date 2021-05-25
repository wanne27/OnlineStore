using System;
using Online_store.Model;
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
using BespokeFusion;

namespace Online_store
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
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

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Сontext db = Сontext.GetСontext();
            Validation check = new Validation();

            CLIENT newClient = new CLIENT()
            {
                Surname = mySurname.Text,
                Firstname = myFirstname.Text,
                Region = myRegion.Text,
                City = myCity.Text,
                Street = myStreet.Text,
                House = myHouse.Text,
                Flat = myFlat.Text,
                E_mail = myEmail.Text,
                Card = myCardID.Text,
                Phone = myPhone.Text
            };
            USER newuser = new USER()
            {
                Login = myLogin.Text,
                Client = newClient,
                Role = "Client"
            };
            if (mypass.Password != string.Empty)
            {
                newuser.Password = mypass.Password.GetHashCode().ToString();
            }
            if (check.CheckValid(newuser) && check.CheckValid(newClient))
            {
                var someUser = db.USERs.FirstOrDefault(u => u.Login == myLogin.Text);

                if (someUser == null)
                {
                    var phoneNumClient = db.CLIENTs.FirstOrDefault(u => u.Phone == myPhone.Text);

                    if (phoneNumClient == null)
                    {
                        db.USERs.Add(newuser);
                        db.SaveChanges();
                        Autorization autorization = new Autorization();
                        Close();
                        autorization.Show();
                    }
                    else
                    {
                        MaterialMessageBox.ShowError("Введенный номер телефона уже привязан к другому профилю. Попробуйте снова!");
                    }
                }
                else
                {
                    MaterialMessageBox.ShowError("Пользователь с таким логином уже существует. Попробуйте снова!");
                }

            }
        }
    }
}
