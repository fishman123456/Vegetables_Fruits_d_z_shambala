using ComputerGamesCrudApp_AttachedMode.Model;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Vegetables_Fruits_d_z_shambala
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // private MainViewModel MainViewModel { get; } = new MainViewModel();
        // поле клиента работы с БД
        private DbVegetablesAndFruitsClient dbClient;
        public MainWindow()
        {
            InitializeComponent();
            dbClient = new DbVegetablesAndFruitsClient(new DbConnectionProvider());
            updateVegetablesAndFruitsList();
            //   DataContext = MainViewModel;
        }

        // обновляем список фрукты овощи
        private void updateVegetablesAndFruitsList()
        {
            try
            {
                // обновление списка объектов (можно придумать рациональный способ)
                List<VegetablesAndFruits> vegasfruit = dbClient.SelectAll();
                VegFruListBox.Items.Clear();
                vegasfruit.ForEach(v => {VegFruListBox.Items.Add(v);});
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during select object list: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void usersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { }
            private void updateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QveryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void testDbConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // проверка соединения с БД
                DbConnectionProvider provider = new DbConnectionProvider();
                using (SqlConnection connection = provider.OpenDbConnection())
                {
                    MessageBox.Show("Connection is ok", "Connected", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
