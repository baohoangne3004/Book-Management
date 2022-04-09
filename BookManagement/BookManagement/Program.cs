using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ArrayList books = new ArrayList();
            books.Add(new Book("0-2587-2888-4", "Book title 1", 1000, 10));
            books.Add(new Book("0-9900-5119-6", "Book title 2", 1000, 10));
            books.Add(new Book("0-8927-5687-X", "Book title 3", 1000, 10));
            books.Add(new Book("0-2282-6753-6", "Book title 4", 1000, 10));
            books.Add(new Book("0-1690-9739-0", "Book title 5", 1000, 10));

            foreach (Book book in books)
            {
                DAO.AddBook(book);
            }*/

            DataTable booksData = DAO.GetBookOrderByTitle();
            Console.WriteLine("Get books ordered by title and print to browser (or console)");
            WriteListBook(GetBooksList(booksData));

            booksData = DAO.GetBookMaxPrice();  
            Console.WriteLine("Find book with max unit price.");
            WriteListBook(GetBooksList(booksData));

            booksData = DAO.GetBook3MinPrice();
            Console.WriteLine("Find summary of 3 chipest books.");
            WriteListBook(GetBooksList(booksData));
            Console.ReadLine();
        }

        static ArrayList GetBooksList(DataTable booksdata)
        {
            ArrayList books = new ArrayList();
            for (int i = 0; i < booksdata.Rows.Count; i ++)
            {
                Book book = new Book(
                    booksdata.Rows[i].ItemArray[0].ToString()
                    , booksdata.Rows[i].ItemArray[1].ToString()
                    , Convert.ToDouble(booksdata.Rows[i].ItemArray[2])
                    , Convert.ToInt32(booksdata.Rows[i].ItemArray[3]));
                books.Add(book);
            }
            return books;
        }

        static void WriteListBook(ArrayList books)
        {
            Console.WriteLine("Id\tTitle\tUnit Price\tQuantity");
            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
