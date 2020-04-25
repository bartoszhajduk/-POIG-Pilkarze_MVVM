using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVM_Pilkarze.ModelView
{
    using Model.Dane;
    using BaseClass;

    internal class Listing: ViewModel
    {
        static Dane dane = new Dane();

        public string imie { get; set; }
        public string nazwisko { get; set; }
        public uint wiek { get; set; } = 30;
        public uint waga { get; set; } = 70;
        public Pilkarz biezacy { get; set; }
   
 
        public ObservableCollection<Pilkarz> Log { get; } = new ObservableCollection<Pilkarz>(dane.listaPilkarzy);

        private void update()
        {
            Log.Clear();
            foreach (var item in dane.listaPilkarzy)
            {
                Log.Add(item);
            }
        }

        private void clear()
        {
            imie = "";
            nazwisko = "";
            wiek = 30;
            waga = 70;
            onPropertyChanged(nameof(imie), nameof(nazwisko), nameof(waga), nameof(wiek));
        }
        private void zmiana()
        {
            imie = biezacy.Imie;
            nazwisko = biezacy.Nazwisko;
            waga = biezacy.Waga;
            wiek = biezacy.Wiek;
            onPropertyChanged(nameof(imie), nameof(nazwisko), nameof(waga), nameof(wiek));
        }

        private ICommand _wczytaj = null;
        public ICommand Wczytaj
        {
            get
            {
                if (_wczytaj == null)
                {
                    _wczytaj = new RelayCommand(
                        arg => { zmiana(); },
                        arg => (biezacy!=null)
                     );
                }
                return _wczytaj;
            }
        }

        private ICommand _dodaj=null;
        public ICommand Dodaj
        {
            get
            {
                if (_dodaj == null)
                {
                    _dodaj = new RelayCommand(
                        arg => { dane.dodaj(imie, nazwisko, wiek, waga); update(); },
                        arg => (!string.IsNullOrEmpty(imie) && (!string.IsNullOrEmpty(nazwisko)))
                     );
                }
                return _dodaj;
            }

        }

        private ICommand _edit = null;
        public ICommand Edytuj
        {
            get
            {
                if (_edit == null)
                {
                        _edit = new RelayCommand(
                        arg => { dane.edytuj(imie, nazwisko, wiek, waga,biezacy); update(); },
                        arg => (!string.IsNullOrEmpty(imie) && (!string.IsNullOrEmpty(nazwisko)) && biezacy!=null)
                     );
                }

                return _edit;
            }

        }

        private ICommand _usun=null;
        public ICommand Usun
        {
            get
            {
                if (_usun == null)
                {
                    _usun = new RelayCommand(
                        arg => { dane.usun(biezacy); update();clear(); },
                        arg => (biezacy != null && biezacy != null)
                     );
                }

                return _usun;
            }
        }

        private ICommand _zaladuj = null;
        public ICommand Zaladuj
        {
            get
            {
                if (_zaladuj == null)
                {
                    _zaladuj = new RelayCommand(
                        arg => { dane.zaladuj();update(); },
                        arg => true
                     );
                }

                return _zaladuj;
            }
        }

        private ICommand _archiwizuj = null;
        public ICommand Archiwizuj
        {
            get
            {
                if (_archiwizuj == null)
                {
                    _archiwizuj = new RelayCommand(
                        arg => { dane.archiwizuj(); },
                        arg => true
                     );
                }

                return _archiwizuj;
            }
        }
    }
}
