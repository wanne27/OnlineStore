using BespokeFusion;
using Online_store.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Online_store.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyProfilePage.xaml
    /// </summary>
    public partial class MyProfilePage : Page
    {
        Сontext db = Сontext.GetСontext();
        private ObservableCollection<CLIENT> user;
        public MyProfilePage()
        {
            InitializeComponent();
        }

        private void MyProf_Loaded(object sender, RoutedEventArgs e)
        {

            user = new ObservableCollection<CLIENT>(db.CLIENTs.Where(p => p.Id == (int)USER.CurrentUser.ClientId));
            foreach (CLIENT p in user)
            {
                MySurname.Text = p.Surname;
                MyFirstname.Text = p.Firstname;
                MyPhone.Text = p.Phone;
                MyCardNumber.Text = p.Card;
                MyEmail.Text = p.E_mail;
                MyRegion.Text = p.Region;
                MyCity.Text = p.City;
                MyStreet.Text = p.Street;
                MyHouse.Text = p.House;
                MyFlat.Text = p.Flat;

            }
        }
        private void MyProfile_SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MyProfile_SaveButton.IsEnabled = false;
            MyProfile_changeButton.IsEnabled = true;

            MySurname.IsReadOnly = true;
            MyFirstname.IsReadOnly = true;
            MyPhone.IsReadOnly = true;
            MyCardNumber.IsReadOnly = true;
            MyEmail.IsReadOnly = true;
            MyRegion.IsReadOnly = true;
            MyCity.IsReadOnly = true;
            MyStreet.IsReadOnly = true;
            MyHouse.IsReadOnly = true;
            MyFlat.IsReadOnly = true;

            if(MyFirstname.Text != String.Empty && MySurname.Text != String.Empty && MyPhone.Text != String.Empty && MyCardNumber.Text != String.Empty && MyEmail.Text != String.Empty && MyRegion.Text != String.Empty && MyStreet.Text != String.Empty && MyCity.Text != String.Empty && MyHouse.Text != String.Empty && MyFlat.Text != String.Empty)
            {
                try
                {
                    if (user != null)
                    {
                        foreach (CLIENT p in user)
                        {
                            p.Surname = MySurname.Text;
                            p.Firstname = MyFirstname.Text;
                            p.Phone = MyPhone.Text;
                            p.Card = MyCardNumber.Text ;
                            p.E_mail=MyEmail.Text;
                            p.Region = MyRegion.Text;
                            p.City = MyCity.Text;
                            p.Street = MyStreet.Text;
                            p.House = MyHouse.Text;
                            p.Flat = MyFlat.Text;
                            db.SaveChanges();
                            MessageBox.Show("Профиль изменён успешно!");
                        }
                    }
                }
                catch
                {
                    MaterialMessageBox.ShowError("Изменения не сохранены.Проверьте введенные данные!");
                }
            }
            else
            {
                MaterialMessageBox.ShowError("Поля не заполнены. Введите данные!");
            }
        }
        private void MyProfile_changeButton_Click(object sender, RoutedEventArgs e)
        {

            MyProfile_changeButton.IsEnabled = false;
            MyProfile_SaveButton.IsEnabled = true;

            MySurname.IsReadOnly = false;
            MyFirstname.IsReadOnly = false;
            MyPhone.IsReadOnly = false;
            MyCardNumber.IsReadOnly = false;
            MyEmail.IsReadOnly = false;
            MyRegion.IsReadOnly = false;
            MyCity.IsReadOnly = false;
            MyStreet.IsReadOnly = false;
            MyHouse.IsReadOnly = false;
            MyFlat.IsReadOnly = false;
        }
    }
}
