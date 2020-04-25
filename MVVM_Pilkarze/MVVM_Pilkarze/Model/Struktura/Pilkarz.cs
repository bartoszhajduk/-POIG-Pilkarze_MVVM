using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Pilkarze.Model.Dane
{
    public class Pilkarz

    {

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public uint Wiek { get; set; }
        public uint Waga { get; set; }



        public Pilkarz(string imie, string nazwisko, uint wiek, uint waga)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;
        }
        public Pilkarz() { }
        public Pilkarz(string imie, string nazwisko) : this(imie, nazwisko, 30, 75) { }

        public override string ToString()
        {
            return $"{Nazwisko} {Imie} lat: {Wiek} waga: {Waga} kg";
        }

    }
}
