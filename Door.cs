using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDoor
{
    public abstract class Door
    {
        private string producer;
        private decimal doorPrice;
        public string cataloguenumber;
        private static int counter;

        public string Producer
        {
            get => producer;
            set
            {
                if(value.Length < 5 || char.IsLower(value[0]))
                {
                    throw new ArgumentException("blad");
                }
                producer = value;
            }
        }
        public decimal DoorPrice { get => doorPrice; set => doorPrice = value; }
        public string Cataloguenumber { get => cataloguenumber; set => cataloguenumber = value; }
        public static int Counter { get => counter; set => counter = value; }

        static Door()
        {
            Counter = 100;
        }

        public Door(string producer, decimal price)
        {
            Producer = producer;
            DoorPrice = price;
            Counter++;
            string formattedCounter = Counter.ToString("D9");
            Cataloguenumber = $"{Producer}-{formattedCounter}";
        }

        public abstract decimal CalculatePrice();

        public override string ToString()
        {
            return $"{Cataloguenumber}, {CalculatePrice():C}";
        }
    }
}
