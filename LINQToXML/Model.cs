using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;


//С помощью LINQ to XML загрузить xml документ books.xml.
    //1. Вывести все книги в listview или datagrid
    //2. С помощью LINQ реализовать фильтры
    //a.Поиск всех книг по введенной категории
    //b. Поиск всех книг с ценой в указанном диапазоне
    //3. На форме показывать количество всех найденных книг, самую старую и самую новую
    //книги.



namespace LINQToXML
{
    class Model
    {
        private XDocument _doc;
        private IEnumerable<String> _categories;
        private IEnumerable<Book> _books;

        public Model()
        {
            try
            {
                _doc = XDocument.Load(@"E:\GoogleDrive\Программовня\ADONet\Examples\LINQ\LINQToXML\LINQToXML\books.xml");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ooops", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }

            LoadBooks();
            LoadCategories();
        }

        public IEnumerable<string> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        public IEnumerable<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }

        private void LoadCategories()
        {
            var res = (from b in _doc.Descendants("book")
                select b.Element("genre").Value).Distinct();
            Categories =  res;
        }

        private void LoadBooks()
        {
            var res = (from b in _doc.Descendants("book")
                select new Book(b.FirstAttribute.Value, new Author(b.Element("author").Value), b.Element("title").Value, b.Element("genre").Value, b.Element("price").Value, b.Element("publish_date").Value, b.Element("description").Value)).ToList();
            Books = res;
        }
    }
}
