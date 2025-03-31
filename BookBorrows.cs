using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class BookBorrows
    {
        public List<Book> borrowedBooks;

        public List<Book> BorrowedBooks { get => borrowedBooks;  }
        public BookBorrows()
        {
            borrowedBooks = new List<Book>();
        }
        public void AddBorrow(Book b)
        {
            borrowedBooks.Add(b);
        }

        public void Sort()
        {
            borrowedBooks.Sort();
        }

        public override string ToString()
        {
            StringBuilder sbl = new StringBuilder();
            foreach (Book b in borrowedBooks)
            {
                sbl.Append(b.ToString());
            }
            return sbl.ToString();
        }
    }
}
