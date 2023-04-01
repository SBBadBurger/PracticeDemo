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

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        DemoEntities db = new DemoEntities();
        Продукты p;
        ProductsPage pp;
        public AddProductWindow(Продукты p, ProductsPage page)
        {
            InitializeComponent();
            this.pp = page;
            this.p = p;
            ComboBoxProizvod.ItemsSource = db.Поставщики.ToList();
            ComboBoxCategory.ItemsSource = db.Категории_Продуктов.ToList();
            if (p != null)
            {
                TextBoxArticle.Text = p.Артикул;
                TextBoxName.Text = p.Наименование;
                TextBoxPrice.Text = p.Стоимость.ToString();
                TextBoxMaxDiscount.Text = p.Размер_максимально_возможной_скидки.ToString();
                TextBoxPostav.Text = p.Производитель;
                TextBoxCurrDiscount.Text = p.Действующая_скидка.ToString();
                TextBoxDiscription.Text = p.Описание;
                ComboBoxCategory.SelectedIndex = p.Категории_Продуктов.PK_id_Категория_Продукта - 1;
                ComboBoxProizvod.SelectedIndex = p.Поставщики.PK_id_Поставщик - 1;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (p == null)
            {
                try
                {
                    Продукты newproduct = new Продукты
                    {
                        Артикул = TextBoxArticle.Text,
                        Наименование = TextBoxName.Text,
                        Единица_измерения = "шт",
                        Стоимость = Convert.ToInt32(TextBoxPrice.Text),
                        Размер_максимально_возможной_скидки = Convert.ToInt32(TextBoxMaxDiscount.Text),
                        FK_id_Поставщик = (ComboBoxProizvod.SelectedItem as Поставщики).PK_id_Поставщик,
                        Производитель = TextBoxPostav.Text,
                        FK_id_Категория_Продукта = (ComboBoxCategory.SelectedItem as Категории_Продуктов).PK_id_Категория_Продукта,
                        Действующая_скидка = Convert.ToInt32(TextBoxCurrDiscount.Text),
                        Описание = TextBoxDiscription.Text
                    };
                    db.Продукты.Add(newproduct);
                    db.SaveChanges();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Не все поля заполнены");
                }
            }
            else
            {
                try
                {
                    var editproduct = db.Продукты.Find(p.PK_id_Продукт);
                    editproduct.Артикул = TextBoxArticle.Text;
                    editproduct.Наименование = TextBoxName.Text;
                    editproduct.Стоимость = Convert.ToInt32(TextBoxPrice.Text);
                    editproduct.Размер_максимально_возможной_скидки = Convert.ToInt32(TextBoxMaxDiscount.Text);
                    editproduct.FK_id_Поставщик = (ComboBoxProizvod.SelectedItem as Поставщики).PK_id_Поставщик;
                    editproduct.Производитель = TextBoxPostav.Text;
                    editproduct.FK_id_Категория_Продукта = (ComboBoxCategory.SelectedItem as Категории_Продуктов).PK_id_Категория_Продукта;
                    editproduct.Действующая_скидка = Convert.ToInt32(TextBoxCurrDiscount.Text);
                    editproduct.Описание = TextBoxDiscription.Text;
                    db.SaveChanges();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Не все поля заполнены");
                }
            }
            pp.ProductsList.ItemsSource = db.Продукты.ToList();
        }
    }
}
