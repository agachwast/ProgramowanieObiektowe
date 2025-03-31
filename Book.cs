using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Books
{
    public enum EnumCover
    {
        hard,
        soft
    }
    public class Book: IComparable<Book>
    {
        public string title;
        private string isbn;
        public EnumCover cover;
        public List<string> authors;
        private List<Borrow> borrows;
        public static long index;
        public static decimal dailyPrice;
        public DateTime dataWydania;


        public string Isbn { get => isbn; }
        public List<Borrow> Borrows { get => borrows; }

        static Book()
        {
            dailyPrice = 4.99m;
            index = 100;
          
        }

        public Book(DateTime datWyd ,EnumCover c, string title, string[] authorsStr)
        {
            this.title = title;
            index++;
            authors = new List<string>();
            foreach(string author in authorsStr)
            {
                if(!Regex.IsMatch(author, @"[A-Z][a-z]+ [A-Z][a-z]+"))
                {
                    throw new ArgumentException("bledny format imienia i nazwiska");

                }
                authors.Add(author);
            }

            isbn = $"ISBN-{dataWydania.Day.ToString("dd")}-{dataWydania.Month.ToString("MM")}-" +
                $"{dataWydania.Year.ToString("yy")}-{index}";
            borrows = new List<Borrow>();
            this.cover = c;
            this.dataWydania = datWyd;
        }

        public void AddBorrow(DateTime d, int n)
        {
            borrows.Add(new Borrow(d, n));
        }
        public virtual decimal Cost()
        {
            return borrows.Sum(b => b.Days * dailyPrice);
        }

        public int CompareTo(Book other)
        {
            return other.isbn.CompareTo(isbn);
        }

        public string WriteBorrows()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Borrow b in borrows )
            {
                sb.Append(b.ToString());
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return $"{this.title} authors:{this.authors.Count()} ({this.cover}) [{isbn}]";
        }
    }
}
