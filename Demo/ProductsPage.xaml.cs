using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        DemoEntities db;
        Пользователи user;
        public List<Продукты> plist;
        ProductsWindow pw;
        CollectionView view;
        public ProductsPage(Пользователи u, ProductsWindow window)
        {
            InitializeComponent();
            user = u;
            pw=window;
            db = new DemoEntities();
            ProductsList.ItemsSource = db.Продукты.ToList();
            CurrentTextBlock.DataContext = ProductsList.ItemsSource;
            CurrentTextBlock.Text = ProductsList.Items.Count + "/" + db.Продукты.Count().ToString();
            plist = new List<Продукты>();
            if (user != null)
            {
                if (user.FK_id_Роль == 1)
                {
                    AddProductButton.Visibility = Visibility.Collapsed;
                    EditProductButton.Visibility= Visibility.Collapsed;
                    DeleteProductButton.Visibility= Visibility.Collapsed;
                }
            }
            else {
                AddProductButton.Visibility = Visibility.Collapsed;
                EditProductButton.Visibility = Visibility.Collapsed;
                DeleteProductButton.Visibility = Visibility.Collapsed;
            }
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentOrderWindow currentOrderWindow = new CurrentOrderWindow(plist, user);
            currentOrderWindow.Show();
        }
        

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SearchTextBox.Text!="")
            ProductsList.ItemsSource = db.Продукты.Where(p => p.Наименование.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            else
            {
                ProductsList.ItemsSource = db.Продукты.ToList();
            }
            CurrentTextBlock.Text = ProductsList.Items.Count+"/"+db.Продукты.Count().ToString();
        }

        private void MinRadio_Checked(object sender, RoutedEventArgs e)
        {
            view = (CollectionView)CollectionViewSource.GetDefaultView(ProductsList.ItemsSource);
            view.SortDescriptions.Insert(0,new System.ComponentModel.SortDescription("Стоимость", ListSortDirection.Ascending));
            ProductsList.ItemsSource = view;
        }

        private void MaxRadio_Checked(object sender, RoutedEventArgs e)
        {
            view = (CollectionView)CollectionViewSource.GetDefaultView(ProductsList.ItemsSource);
            view.SortDescriptions.Insert(0,new System.ComponentModel.SortDescription("Стоимость", ListSortDirection.Descending));
            ProductsList.ItemsSource = view;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow(null,this);
            addProductWindow.Show();
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.SelectedItem != null)
            {
                var prod = ProductsList.SelectedItem as Продукты;
                db.Продукты.Remove(db.Продукты.Where(p=>p.PK_id_Продукт==prod.PK_id_Продукт).First());
                db.SaveChanges();
                ProductsList.ItemsSource = db.Продукты.ToList();
            }
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow(ProductsList.SelectedItem as Продукты,this);
            addProductWindow.Show();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = (Продукты)((Button)sender).DataContext;
            plist.Add(data);
            CurrentOrderButton.Visibility = Visibility.Visible;
        }
    }
}
