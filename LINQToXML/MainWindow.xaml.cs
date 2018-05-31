using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace LINQToXML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model _model;
        private IEnumerable<Book> _source;

        public MainWindow()
        {
            InitializeComponent();
            _model = new Model();
            InitializeData();
            GetCount();
            GetOldBook();
            GetNewBook();
        }

        private void GetNewBook()
        {
            NewTextBox.Text = _source.Max(b => Int32.Parse(b.PublishDate.Substring(0, 4))).ToString();
        }

        private void GetOldBook()
        {
            OldTextBox.Text = _source.Min(b => Int32.Parse(b.PublishDate.Substring(0, 4))).ToString();
        }

        private void GetCount()
        {
            CountTextBox.Text = _source.Count().ToString();
        }

        private void InitializeData()
        {
            CategoriesComboBox.ItemsSource = _model.Categories;
            _source =  _model.Books;
            DataGrid.ItemsSource = _source;
        }

        private void ButtonAccept_OnClick(object sender, RoutedEventArgs e)
        {
            if (CategoriesComboBox.SelectedItem != null || !PriceFrom.Text.Equals("") || !PriceTo.Text.Equals(""))
            {
                _source = _model.Books;
                if (CategoriesComboBox.SelectedItem != null)
                {
                    _source = _source.Where(b => b.Genre.Equals(CategoriesComboBox.SelectedItem));
                }
                if (!PriceFrom.Text.Equals(""))
                {
                    _source = _source.Where(
                        b => Double.Parse(b.Price, NumberStyles.Any) >= Double.Parse(PriceFrom.Text));
                }
                if (!PriceTo.Text.Equals(""))
                {
                    _source = _source.Where(
                        b => Double.Parse(b.Price, NumberStyles.Any) <= Double.Parse(PriceTo.Text));
                }
                //_source = from b in _model.Books
                //    where b.Genre.Equals(CategoriesComboBox.SelectedItem)
                //    where Double.Parse(b.Price, NumberStyles.Any) >= Double.Parse(PriceFrom.Text)
                //    where Double.Parse(b.Price, NumberStyles.Any) <= Double.Parse(PriceTo.Text)
                //    select b;
                GetCount();
                GetOldBook();
                GetNewBook();
                DataGrid.ItemsSource = _source;
            }
            else
            {
                MessageBox.Show("Fill all fields!", "Fill..", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

