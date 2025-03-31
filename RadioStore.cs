using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERadio
{
    internal class RadioStore : ICloneable
    {
        string name;
        Queue<Radio> radia;

        public string Name { get => name; set => name = value; }
        public Queue<Radio> Radia { get => radia; set => radia = value; }

        public RadioStore(string name)
        {
            Radia = new Queue<Radio>();
        }

        public void RegisterRadio(Radio radio)
        {
            Radia.Enqueue(radio);
        }

        public ClockRadio FindClockRadio()
        {
            int quantity = 0;
            ClockRadio r = null;
            foreach (ClockRadio radio in Radia)
            {
                if(radio.HowManyAlarms() > quantity)
                {
                    quantity = radio.HowManyAlarms();
                    r = radio;
                } 
            }
            return r;

        }

        public object Clone()
        {
            RadioStore clone = new RadioStore(Name);
            foreach(var  radio in Radia)
            {
                clone.Radia.Enqueue((Radio)radio.Clone());
            }
            return clone;
        }
    }
}
