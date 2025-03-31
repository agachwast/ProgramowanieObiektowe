using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Borrow
    {
        public DateTime borrowDate;
        private int days;
        public int Days { get => days; }

        public Borrow(DateTime borrowDate, int days)
        {
            this.borrowDate = borrowDate;
            this.days = days;
        }

        public override string ToString()
        {
            DateTime dateTo = borrowDate.AddDays(days);
            return $"From :{borrowDate.ToString("yy/MM/dd")} to: {dateTo.ToString("yy/MM/dd")}";
        }

    }
}
