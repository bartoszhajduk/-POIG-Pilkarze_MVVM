using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace MVVM_Pilkarze.Model.Dane
{

    using System.Collections.ObjectModel;
    using System.Windows;

    public class Dane
    {
        protected List<Pilkarz> lista { get; set; } = new List<Pilkarz>();

        public bool isTheSame(Pilkarz pilkarz, string imie, string nazwisko, uint wiek, uint waga)
        {
            if (pilkarz.Nazwisko != nazwisko) return false;
            if (pilkarz.Imie != imie) return false;
            if (pilkarz.Wiek != wiek) return false;
            if (pilkarz.Waga != waga) return false;
            return true;
        }

        public ObservableCollection<Pilkarz> listaPilkarzy
        {
            get
            {
                ObservableCollection<Pilkarz> tmp = new ObservableCollection<Pilkarz>(lista);

                return tmp;
            }
        }


        public void dodaj(string imie, string nazwisko, uint wiek, uint waga)
        {
            foreach (var p in lista)
            {
                if (isTheSame(p, imie, nazwisko, wiek, waga))
                {
                    var dialogResult = MessageBox.Show("Pilkarz jest już na liście", "Błąd", MessageBoxButton.OK);
                    return;
                }
            }
            lista.Add(new Pilkarz(imie, nazwisko, wiek, waga));

        }
        public void edytuj(string imie, string nazwisko, uint wiek, uint waga, Pilkarz biezacy)
        {
            foreach (var p in lista)
            {

                if (isTheSame(p, imie, nazwisko, wiek, waga))
                {
                    var dialogResult1 = MessageBox.Show("Pilkarz jest już na liście", "Błąd", MessageBoxButton.OK);
                    return;
                }
            }
            var dialogResult = MessageBox.Show($"Czy na pewno chcesz zmienić dane  {Environment.NewLine} {biezacy.ToString()}?", "Edycja", MessageBoxButton.YesNo);

            if (dialogResult == MessageBoxResult.Yes)
            {
                biezacy.Imie = imie;
                biezacy.Nazwisko = nazwisko;
                biezacy.Waga = waga;
                biezacy.Wiek = wiek;
            } 
        }
      
        public void usun(Pilkarz biezacy)
        {
            var dialogResult = MessageBox.Show($"Czy na pewno chcesz usunąć dane {Environment.NewLine} {biezacy.ToString()}?", "Usuń", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                lista.Remove(biezacy);
            }
        }

        public void archiwizuj()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pilkarz>));

            TextWriter filestream = new StreamWriter(@"D:\dane.xml");

    
            serializer.Serialize(filestream, lista);
            filestream.Close();
        }

        public void zaladuj()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pilkarz>));

            TextReader filestream = new StreamReader(@"D:\dane.xml");


            lista = (List<Pilkarz>)serializer.Deserialize(filestream);
            filestream.Close();
        }
    }
}
