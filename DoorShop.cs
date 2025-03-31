using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDoor
{
    interface IDoorPromotion
    {
        string CommunicateDoorPromotion();
    }
    internal class DoorShop : IDoorPromotion
    {
        private string name;
        private Dictionary<string, Door> assortment;

        public string Name { get => name; set => name = value; }
        public Dictionary<string, Door> Assortment { get => assortment; set => assortment = value; }

        public DoorShop(string name)
        {
            Name = name;
            Assortment = new Dictionary<string, Door>();
        }

        public void RegisterDoor(Door door)
        {
            if(!Assortment.ContainsKey(door.Cataloguenumber))
            {
                Assortment.Add(door.cataloguenumber, door);
            }
        }

        public decimal TotalDoorPrice()
        {
            decimal price = 0;
            foreach(Door door in Assortment.Values)
            {
                price += door.CalculatePrice();
            }
            return price;
        }

        public List<string> FindSpecial()
        {
            var list = Assortment.Values.OfType<SpecialDoor>().ToList();
            List<string> specials = new List<string>();
            foreach(Door door in list)
            {
                specials.Add(door.Cataloguenumber);
            }
            return specials;
        }

        public string CommunicateDoorPromotion()
        {
            DateTime dzis = DateTime.Now;
            Random rand = new Random();
            int days = rand.Next(1, 8);
            DateTime data = dzis.AddDays(days);
            return data.ToString("dd-MM-yyyy");
        }

        public int CountArtDeco()
        {
            var list = Assortment.Values.OfType<ArtDecoDoor>().ToList();    
            return list.Count();
        }

        public int CountSpecial()
        {
            var list = Assortment.Values.OfType<SpecialDoor>().ToList();
            return list.Count();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Name);
            stringBuilder.AppendLine($"Promotion until: {CommunicateDoorPromotion()}");
            stringBuilder.AppendLine($"ArtDeco: {CountArtDeco()}");
            stringBuilder.AppendLine($"Special: {CountSpecial()}");
            foreach (Door door in Assortment.Values)
            {
                stringBuilder.AppendLine(door.ToString());
            }
            stringBuilder.AppendLine($"Total door price: {TotalDoorPrice()}");
            return stringBuilder.ToString();
            
        }

    }
}
