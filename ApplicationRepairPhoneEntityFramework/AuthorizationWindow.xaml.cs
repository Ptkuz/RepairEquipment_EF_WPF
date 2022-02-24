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

namespace ApplicationRepairPhoneEntityFramework
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private async void btn_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                Login = txbx_login.Text;
                Password = txbx_pawword.Text;


                string position = await DataOperations.Autorization(Login, Password);


                switch (position)
                {
                    case "Директор":
                        MessageBox.Show("Директор");
                        break;
                    case "Стажер":
                        MessageBox.Show("Стажер");
                        break;
                    case "Мастер":
                        MessageBox.Show("Мастер");
                        break;
                    case "Старший мастер":
                        MessageBox.Show("Старший мастер");
                        break;
                    case "Менеджер":
                        MessageBox.Show("Менеджер");
                        break;


                }


            }
            catch (Exception ex) 
            {
                MessageBox.Show("Неверный логин или пароль!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);
            
            }





        }
    }
}
