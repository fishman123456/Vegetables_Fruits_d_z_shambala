using ComputerGamesCrudApp_AttachedMode.Model;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

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
            UpdateVGList();
            //   DataContext = MainViewModel;
        }

        // обновляем список фрукты овощи
        private void UpdateVGList()
        {
            try
            {
                // обновление списка объектов (можно придумать рациональный способ)
                List<VegetablesAndFruits> vegasfruit = dbClient.SelectAll();
                VegFruListBox.Items.Clear();
                vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during select object list: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // меню удалить, изменить выбранный элемент
        private void usersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<VegetablesAndFruits> vegetablesAndFruits1 = dbClient.SelectAll();

            if (VegFruListBox.SelectedItem is VegetablesAndFruits)
            {

                string selectrow = VegFruListBox.SelectedItem.ToString().Split().First();
                int id_VegFru_t = Convert.ToInt32(selectrow);
                MessageBoxResult resdelete = MessageBox.Show($"Удалить выбранный элемент?", "Error", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                if (resdelete == MessageBoxResult.Yes)
                {
                    //do something
                    dbClient.Delete(id_VegFru_t);
                    UpdateVGList();

                }
                else if (resdelete == MessageBoxResult.No)
                {
                    //do something else
                    MessageBoxResult resupgrade = MessageBox.Show("Изменяем строку?", " ", MessageBoxButton.YesNo, MessageBoxImage.Information);

                    if (resupgrade == MessageBoxResult.Yes)
                    {
                        // считываем выбранную запись как строку 
                        List<string> strings = new List<string>();
                        string selectrowid = VegFruListBox.SelectedItem.ToString();
                        char[] splitchar = { ' ' };
                        foreach (string sel in selectrowid.Split(splitchar))
                        {
                            strings.Add(sel);
                        }
                        //  добавляем её в обьект c индексом
                        int id = Convert.ToInt32(strings[0]);
                        string name = strings[1];
                        string type = strings[2];
                        string color = strings[3];
                        int calories = Convert.ToInt32(strings[4]);
                        VegetablesAndFruits newVG = new VegetablesAndFruits() { Id = id, Name = name, Type = type, Color = color, Calories = calories };
                        // вписываем обьект по полям в textbox для изменения
                        Upid_f.Text = id.ToString();
                        Upname_f.Text = name;
                        Uptype_f.Text = type.ToString();
                        Upcolor_f.Text = color;
                        Upcalories_f.Text = calories.ToString();

                    }
                    else if (resupgrade == MessageBoxResult.No)
                    {
                        //do something else
                    }
                }
            }
        }



        // 
        private void QveryBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        // проверка соединения
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
        // обновление таблицфы из базы данных
        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateVGList();
        }
        // добавление записи базу данных
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //int id = Convert.ToInt32(Upid_f.Text);
            string name = name_f.Text.ToString();
            string type = type_f.Text.ToString();
            string color = color_f.Text.ToString();
            int calories = Convert.ToInt32(calories_f.Text);
            VegetablesAndFruits newVegetablesAndFruits = new VegetablesAndFruits() { Name = name, Type = type, Color = color, Calories = calories };

            dbClient.Insert(newVegetablesAndFruits);

            UpdateVGList();
        }
        // изменение записи
        private void Update_Click(object sender, RoutedEventArgs e)
        {

            int id = Convert.ToInt32(Upid_f.Text);
            string name = Upname_f.Text.ToString();
            string type = Uptype_f.Text.ToString();
            string color = Upcolor_f.Text.ToString();
            int calories = Convert.ToInt32(Upcalories_f.Text);
            VegetablesAndFruits newVegetablesAndFruits = new VegetablesAndFruits() { Id = id, Name = name, Type = type, Color = color, Calories = calories };

            dbClient.Update(newVegetablesAndFruits);

            UpdateVGList();
        }

        // 1.2 получить  записи названий овощей и фруктов
        private void Qvery1_Click(object sender, RoutedEventArgs e)
        {
            // обновление списка объектов (можно придумать рациональный способ)
            List<VegetablesAndFruits> vegasfruit = dbClient.SelectName();
            VegFruListBox.Items.Clear();
            vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            dbClient.SelectName();
            // UpdateVGList();
        }
        // 1.3 получить  цвет овощей и фруктов
        private void Qvery2_Click(object sender, RoutedEventArgs e)
        {
            // обновление списка объектов (можно придумать рациональный способ)
            List<VegetablesAndFruits> vegasfruit = dbClient.SelectColor();
            VegFruListBox.Items.Clear();
            vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            dbClient.SelectColor();
        }
        // 1.4 Вывести максимальную калорийность овощей и фруктов
        private void Qvery3_Click(object sender, RoutedEventArgs e)
        {
            List<VegetablesAndFruits> vegasfruit = dbClient.SelectMaxCalories();
            VegFruListBox.Items.Clear();
            vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            dbClient.SelectMaxCalories();
        }
        // 1.5 Вывести минимальную калорийность овощей и фруктов
        private void Qvery4_Click(object sender, RoutedEventArgs e)
        {
            List<VegetablesAndFruits> vegasfruit = dbClient.SelectMinCalories();
            VegFruListBox.Items.Clear();
            vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            dbClient.SelectMinCalories();
        }
        // 1.6 Вывести среднюю калорийность овощей и фруктов победа+++++ 10-10-2023
        private void Qvery5_Click(object sender, RoutedEventArgs e)
        {
            List<string> vegasfruit = dbClient.SelectAVGCalories();
            VegFruListBox.Items.Clear();
            vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            dbClient.SelectAVGCalories();
        }
//-------------------------------------------------------------------------//
        //2.1  показать кол-во овощей 10-10-2023
        private void Qvery6_Click(object sender, RoutedEventArgs e)
        {
            List<string> vegasfruit = dbClient.SelectCountVeg();
            VegFruListBox.Items.Clear();
            vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            dbClient.SelectCountVeg();
        }
        //2.1  показать кол-во фруктов 10-10-2023
        private void Qvery7_Click(object sender, RoutedEventArgs e)
        {
            List<string> vegasfruit = dbClient.SelectCountFru();
            VegFruListBox.Items.Clear();
            vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            dbClient.SelectCountFru();
        }
        // 2.3 Показать количество овощей и фруктов заданного цвета;
        private void Qvery8_Click(object sender, RoutedEventArgs e)
        {
            string strings = "красн%";   //------- заплатка пока 10-10-2023_14-26
            List<string> vegasfruit = dbClient.SelectCountColor(strings);
            VegFruListBox.Items.Clear();
            vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            dbClient.SelectCountFru();

        }

        // 2.4 Показать количество овощей и фруктов каждого цвета;
        private void Qvery9_Click(object sender, RoutedEventArgs e)
        {
           
            List<string> vegasfruit = dbClient.SelectCountAllColor();
            VegFruListBox.Items.Clear();
            vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            dbClient.SelectCountAllColor();

        }
        private void Qvery10_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Qvery11_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Qvery12_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Qvery13_Click(object sender, RoutedEventArgs e)
        {
            List<string> vegasfruit = dbClient.SelectCountRedYel();
            VegFruListBox.Items.Clear();
            vegasfruit.ForEach(v => { VegFruListBox.Items.Add(v); });
            dbClient.SelectCountRedYel();
        }
        private void MenuItemQvery_Click(object sender, RoutedEventArgs e)
        {
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void InputColor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
