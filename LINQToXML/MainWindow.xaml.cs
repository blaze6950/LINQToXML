using System;
using System.Collections.Generic;
using System.Data;
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
            NewTextBox.Text = _model.Books.Max(b => Int32.Parse(b.PublishDate.Substring(0, 4))).ToString();
        }

        private void GetOldBook()
        {
            OldTextBox.Text = _model.Books.Min(b => Int32.Parse(b.PublishDate.Substring(0, 4))).ToString();
        }

        private void GetCount()
        {
            CountTextBox.Text = _model.Books.Count().ToString();
        }

        private void InitializeData()
        {
            CategoriesComboBox.ItemsSource = _model.Categories;
            DataGrid.ItemsSource = _model.Books;
        }

        private void ButtonAccept_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

