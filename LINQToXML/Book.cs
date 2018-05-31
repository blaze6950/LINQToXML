using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToXML
{
    class Book
    {
        public Book()
        {
        }

        public Book(string id, Author author, string title, string genre, String price, string publishDate, string description)
        {
            Id = id;
            Author = author;
            Title = title;
            Genre = genre;
            Price = price;
            PublishDate = publishDate;
            Description = description;
        }

        public String Id { get; set; }
        public Author Author { get; set; }
        public String Title { get; set; }
        public String Genre { get; set; }
        public String Price { get; set; }
        public String PublishDate { get; set; }
        public String Description { get; set; }
    }
}
