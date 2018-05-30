using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private IEnumerable<XElement> _books;

        public Model()
        {
            try
            {
                _doc = XDocument.Load("books.xml");
            }
            catch (Exception e)
            {
                //error
            }

            LoadBooks();
            LoadCategories();
        }

        private void LoadCategories()
        {
            var res = from b in _doc.Descendants("book")
                select b.Descendants("genre").ToString();
            _categories =  res;
        }

        private void LoadBooks()
        {
            var res = from b in _doc.Descendants("book")
                select b;
            _books = res;
        }
    }
}
