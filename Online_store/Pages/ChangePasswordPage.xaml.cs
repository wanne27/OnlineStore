using BespokeFusion;
using Online_store.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Online_store.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordPage.xaml
    /// </summary>
    public partial class ChangePasswordPage : Page
    {
        Сontext db = Сontext.GetСontext();
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyOldPassword.Password != String.Empty && MyNewPassword.Password != String.Empty)
            {
                string OldPassword = MyOldPassword.Password.GetHashCode().ToString();
                string NewPassword = MyNewPassword.Password.GetHashCode().ToString();
                var result = db.USERs.SingleOrDefault(b => b.Id == USER.CurrentUser.ClientId);
                if (result != null && result.Password == OldPassword)
                {
                    result.Password = NewPassword;
                    db.SaveChanges();
                    MyNewPassword.Password = "";
                    MyOldPassword.Password = "";
                    MessageBox.Show("Пароль успешно изменён!", "Изменение пароля");
                }
                else
                {
                    MyNewPassword.Password = "";
                    MyOldPassword.Password = "";
                    MaterialMessageBox.ShowError("Неправильно введён старый пароль!");
                }

            }
            else
                MaterialMessageBox.ShowError("Заполните поля!");
        }
    }
}


