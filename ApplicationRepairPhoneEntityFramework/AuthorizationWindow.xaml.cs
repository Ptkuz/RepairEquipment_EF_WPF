using System;
using System.Windows;

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
                        DirectorMenuWindow directorMenuWindow = new DirectorMenuWindow(Login);
                        directorMenuWindow.Show();
                        break;
                    case "Стажер":
                        MasterMenuWindow masterMenuWindow1 = new MasterMenuWindow(Login);
                        masterMenuWindow1.Show();
                        break;
                    case "Мастер":
                        MasterMenuWindow masterMenuWindow2 = new MasterMenuWindow(Login);
                        masterMenuWindow2.Show();
                        break;
                    case "Старший мастер":
                        MasterMenuWindow masterMenuWindow3 = new MasterMenuWindow(Login);
                        masterMenuWindow3.Show();
                        break;
                    case "Менеджер":
                        ManagerMenuWindow managerMenuWindow = new ManagerMenuWindow();
                        managerMenuWindow.Show();
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
