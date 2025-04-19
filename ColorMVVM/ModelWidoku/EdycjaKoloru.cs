using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ColorMVVM.Model;
using Kolory_WPF.ModelWidoku;

namespace ColorMVVM.ModelWidoku
{

    public class EdycjaKoloru : ObservedObject
    {
        private Kolor model = Ustawienia.Czytaj(); // Removed 'readonly' to allow reassignment

        public byte R
        {
            get
            {
                return model.R;
            }
            set
            {
                model.R = value;
                onPropertyChanged(nameof(R), nameof(Kolor));
            }
        }

        public byte G
        {
            get
            {
                return model.G;
            }
            set
            {
                model.G = value;
                onPropertyChanged(nameof(G), nameof(Kolor));
            }
        }

        public byte B
        {
            get
            {
                return model.B;
            }
            set
            {
                model.B = value;
                onPropertyChanged(nameof(B), nameof(Kolor));
            }
        }

        

        public Color Kolor
        {
            get
            {
                return Color.FromRgb(model.R, model.G, model.B);
            }
        }

        public ICommand resetuj = null;

        public ICommand Resetuj
        {
            get
            {
                if (resetuj == null) resetuj = new RelayCommand(
                    (object p) =>
                    {
                        model.Resetuj();
                        onPropertyChanged(nameof(B), nameof(G), nameof(R), nameof(Kolor));
                    }, (object p) => true);

                return resetuj;
            }
        }

        public ICommand zapisuj = null;
        public ICommand Zapisuj
        {
            get
            {
                if (zapisuj == null) zapisuj = new RelayCommand(
                    (object p) =>
                    {
                        Ustawienia.Zapisz(model);
                        onPropertyChanged(nameof(B), nameof(G), nameof(R), nameof(Kolor));
                    }, (object p) => true);
                return zapisuj;
            }
        }

        public ICommand zaczytaj = null;  // leniwe wywołanie
        public ICommand Zaczytaj
        {
            get
            {
                if (zaczytaj == null) zaczytaj = new RelayCommand(
                    (object p) =>
                    {
                        model = Ustawienia.Czytaj();
                        onPropertyChanged(nameof(B), nameof(G), nameof(R), nameof(Kolor));
                    }, (object p) => true);
                return zaczytaj;
            }
        }



        public void _Zapisz()     // normalne wywołanie
        {
            Ustawienia.Zapisz(model);

        }

        public ICommand Zapisz
        {

            get
            {
                return new RelayCommand((object p) => { _Zapisz(); });

            }

        }

    }
}
