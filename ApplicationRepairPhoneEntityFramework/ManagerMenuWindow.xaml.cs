﻿using System;
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
    /// Логика взаимодействия для ManagerMenuWindow.xaml
    /// </summary>
    public partial class ManagerMenuWindow : Window
    {
        public ManagerMenuWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateOrderWindow createOrderWindow = new CreateOrderWindow();
            bool? result = createOrderWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                MessageBox.Show("Заказ создан", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Заказ не создан", "Приложение СЕРВИСНЫЙ ЦЕНТР: Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PerformanceWindow performanceWindow = new PerformanceWindow();
            bool? result = performanceWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                MessageBox.Show("Заказ закрыт", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Заказ не закрыт", "Приложение СЕРВИСНЫЙ ЦЕНТР: Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            bool? result = addClientWindow.ShowDialog();
            if (result.HasValue && result.Value)
                MessageBox.Show("Новый клиент успешно добавлен", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Клиент не добавлен", "Приложение СЕРВИСНЫЙ ЦЕНТР: Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddDeviceWindow addDeviceWindow = new AddDeviceWindow();
            bool? result = addDeviceWindow.ShowDialog();
            if (result.HasValue && result.Value)
                MessageBox.Show("Новое оборудование успешно добавлено", "Приложение СЕРВИСНЫЙ ЦЕНТР", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Оборудование не добавлено", "Приложение СЕРВИСНЫЙ ЦЕНТР: Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ViewAllOrdersManagerWindow viewAllOrdersManagerWindow = new ViewAllOrdersManagerWindow();
            viewAllOrdersManagerWindow.ShowDialog();
        }
    }
}
