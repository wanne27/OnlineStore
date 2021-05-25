using Online_store.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Online_store.ViewModel
{
    class MainClientViewModel : BaseViewModel
    {
        public Сontext db = Сontext.GetСontext();
        
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");

            }
        }

       private string nameUser { set; get; }
       public string NameUser
        {
            get { return nameUser; }
            set
            {
                nameUser = value;
                OnPropertyChanged("NameUser");
            }
        } 

       

        public string Computer = "Computer";
        public string Laptop = "Laptop";
        public string Phone = "Phone";
        public string TV = "TV";
        public string Monitor = "Monitor";
        public string Audio = "Audio";
        public string PhotoVideo = "PhotoVideo";
        public string MouseKeyboard = " MouseKeyboard";

        public ICommand MainWindowButton { get; set; }
        public ICommand ComputerButton { get; set; }
        public ICommand LaptopButton { get; set; }
        public ICommand PhoneButton { get; set; }
        public ICommand TVButton { get; set; }
        public ICommand MonitorButton { get; set; }
        public ICommand AudioButton { get; set; }
        public ICommand PhotoVideoButton { get; set; }
        public ICommand PowerToolsButton { get; set; }
        public ICommand MouseKeyboardButton { get; set; }
        public ICommand Basket { get; set; }
        public ICommand MyProfile { get; set; }
        public ICommand ChangePassword { get; set; }
       

        public MainClientViewModel()
        {
            CurrentPage = new Pages.MainPage();
            MainWindowButton = new RelayCommand(() => { CurrentPage = new Pages.MainPage(); });
            ComputerButton = new RelayCommand(() => { CurrentPage = new Pages.ProductPage(Computer); });
            LaptopButton = new RelayCommand(() => { CurrentPage = new Pages.ProductPage(Laptop); });
            PhoneButton = new RelayCommand(() => { CurrentPage = new Pages.ProductPage(Phone); });
            TVButton = new RelayCommand(() => { CurrentPage = new Pages.ProductPage(TV); });
            MonitorButton = new RelayCommand(() => { CurrentPage = new Pages.ProductPage(Monitor); });
            AudioButton = new RelayCommand(() => { CurrentPage = new Pages.ProductPage(Audio); });
            PhotoVideoButton = new RelayCommand(() => { CurrentPage = new Pages.ProductPage(PhotoVideo); });
            MouseKeyboardButton = new RelayCommand(() => { CurrentPage = new Pages.ProductPage(MouseKeyboard); });
            Basket = new RelayCommand(() => { CurrentPage = new Pages.BasketPage(); });
            MyProfile = new RelayCommand(() => { CurrentPage = new Pages.MyProfilePage(); });
            ChangePassword = new RelayCommand(() => { CurrentPage = new Pages.ChangePasswordPage(); });
            NameUser = USER.CurrentUser.Client.Firstname;
        }

        public MainWindowClient MainWindowClient
        {
            get => default(MainWindowClient);
            set
            {
            }
        }
    }
}
