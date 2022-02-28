using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;


namespace ApplicationRepairPhoneEntityFramework
{


    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {

        public bool Member { get; set; }
        bool flagLogin = false;
        public bool FlagLogin
        {
            get { return flagLogin; }
            set
            {
                flagLogin = value;
                if (flagLogin && flagPassword)
                {
                    btn_login.IsEnabled = true;
                    cxbx_Member.IsEnabled = true;
                }
                else
                {
                    btn_login.IsEnabled = false;
                    cxbx_Member.IsEnabled = true;
                }

            }
        }
        bool flagPassword = false;
        public bool FlagPassword
        {
            get { return flagPassword; }
            set { flagPassword = value;
                if (flagLogin && flagPassword)
                {
                    btn_login.IsEnabled = true;
                    cxbx_Member.IsEnabled = true;
                }
                else
                {
                    btn_login.IsEnabled = false;
                    cxbx_Member.IsEnabled = true;
                }
            }
        }

        public AuthorizationWindow()
        {
            InitializeComponent();




            using (FileStream fs = new FileStream("login.json", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    AutorezationClass autorezationClass = JsonSerializer.Deserialize<AutorezationClass>(fs);
                    txbx_login.Text = autorezationClass?.Login;
                    txbx_pawword.Password = autorezationClass?.Password;
                }
            }

        }


       
        private  void btn_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Member)
                {
                    using (FileStream fs = new FileStream("login.json", FileMode.OpenOrCreate))
                    {
                        AutorezationClass autorezationClass1 = new AutorezationClass(txbx_login.Text, txbx_pawword.Password);
                         JsonSerializer.Serialize<AutorezationClass>(fs, autorezationClass1);
                    }

                }



                AutorezationClass autorezationClass = new AutorezationClass(txbx_login.Text, txbx_pawword.Password);

                

                 
                string[] dataEmployee = DataOperations.Autorization(txbx_login.Text, txbx_pawword.Password);
               
                string position = dataEmployee[0];
                string fio  = dataEmployee[1];

                

                switch (position)
                {
                    case "Директор":
                        DirectorMenuWindow directorMenuWindow = new DirectorMenuWindow(autorezationClass.Login, fio, position);
                        bool? result = directorMenuWindow.ShowDialog();
                        break;
                    case "Стажер":
                        MasterMenuWindow masterMenuWindow1 = new MasterMenuWindow(autorezationClass.Login,fio, position);
                        masterMenuWindow1.ShowDialog();
                        break;
                    case "Мастер":
                        MasterMenuWindow masterMenuWindow2 = new MasterMenuWindow(autorezationClass.Login, fio, position);
                        masterMenuWindow2.ShowDialog();
                        break;
                    case "Старший мастер":
                        MasterMenuWindow masterMenuWindow3 = new MasterMenuWindow(autorezationClass.Login, fio, position);
                        masterMenuWindow3.ShowDialog();
                        break;
                    case "Менеджер":
                        ManagerMenuWindow managerMenuWindow = new ManagerMenuWindow(autorezationClass.Login, fio, position);
                        managerMenuWindow.ShowDialog();
                        break;
                    case "Уволен":
                        MessageBox.Show($"{fio} уволен!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;


                }


               

            }
            catch
            {
                connectionProgressBar.IsIndeterminate = false;
                connectionLabel.Content = "";
                MessageBox.Show("Неверный логин или пароль!", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Error);

            }





        }

        private void cxbx_Member_Checked(object sender, RoutedEventArgs e)
        {
            if (txbx_login.Text != String.Empty && txbx_pawword.Password != String.Empty)
                Member = true;
            else
                Member = false;

        }

        private void cxbx_Member_Unloaded(object sender, RoutedEventArgs e)
        {
            Member = false;
        }

        private void txbx_server_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void txbx_login_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txbx_login.Text != String.Empty)
                FlagLogin = true;
            else
                FlagLogin = false;
        }

        private void txbx_pawword_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(txbx_pawword.Password != String.Empty)
                FlagPassword = true;
            else
                FlagPassword = false;
        }

        private void txbx_pawword_PasswordChanged(object sender, RoutedEventArgs e)
        {
             if(txbx_pawword.Password != String.Empty)
                FlagPassword = true;
            else
                FlagPassword = false;
        }
    }
}
