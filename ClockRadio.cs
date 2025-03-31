using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERadio
{
    public class ClockRadio : Radio
    {
        List<(string, DateTime)> alarms;
        bool hasCalendars;

        public List<(string, DateTime)> Alarms { get => alarms; set => alarms = value; }
        public bool HasCalendars { get => hasCalendars; set => hasCalendars = value; }

        public ClockRadio(EnumRadioBrand brand, bool hascal) : base(brand)
        {
            HasCalendars = hascal;
            Alarms = new List<(string, DateTime)>();
        }

        public override decimal GetRadioPrice()
        {
            if(HasCalendars)
            {
                return radioPrice * 1.5m;
            }
            else
            {
                return radioPrice;
            }
        }

        public void SetAlarms(string msg, DateTime date)
        {
            if(date.Year < DateTime.Now.Year || (date.Year == DateTime.Now.Year && date.Month < DateTime.Now.Month)
                || (date.Year == DateTime.Now.Year && date.Month == DateTime.Now.Month && date.Day < DateTime.Now.Day))
            {
                throw new ArgumentException("blad");
            }
            Alarms.Add((msg, date));
        }

        public int HowManyAlarms()
        {
            return Alarms.Count();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            foreach(var alarm in  Alarms)
            {
                sb.AppendLine($"{alarm.Item2.ToString("dd/MM/yyyy/hh/mm/ss")} {alarm.Item1}");
            }
            return $"{base.ToString()} with alarms: {sb.ToString()}";
        }
    }
}
