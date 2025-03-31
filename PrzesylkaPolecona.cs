using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPaczka;

namespace EPaczka
{
    public enum EnumSpecjalnaKoszt
    {
        szklo = 10,
        poufna = 9,
        lot = 13
    }
    public class PrzesylkaPolecona : Przesylka
    {
        public EnumSpecjalnaKoszt specjalnyKoszt;

        public EnumSpecjalnaKoszt SpecjalnyKoszt { get => specjalnyKoszt; set => specjalnyKoszt = value; }

        public PrzesylkaPolecona(EnumMiasto nadawca, EnumMiasto odbiorca, float waga, EnumSpecjalnaKoszt specjalna) : base(nadawca, odbiorca, waga)
        {
            SpecjalnyKoszt = specjalna;
        }

        public override decimal ObliczKosztPrzesylki()
        {
            return base.ObliczKosztPrzesylki() + (decimal)SpecjalnyKoszt;
        }

        public override string ToString()
        {
            return $"{base.ToString()} /{SpecjalnyKoszt}";
        }







    }




}
