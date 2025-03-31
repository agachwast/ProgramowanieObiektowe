using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public enum EnumLanguage
    {
        english,
        german,
        polish,
        spanish
    }
    public class SpecialBook : Book
    {
        public EnumLanguage language;
        public static decimal specialPrice;

        static SpecialBook()
        {
            specialPrice = 20.99m;
        }

        public SpecialBook(DateTime datw, EnumCover c, string title, string[] authorsStr, EnumLanguage lang) : base(datw, c, title, authorsStr)
        {
            this.language = lang;
        }

        public override decimal Cost()
        {
            return base.Cost() + specialPrice;
        }

        public override string ToString()
        {
            return $"{base.ToString()}-{this.language}";
        }
    }
}
