using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ColorMVVM
{
    public class ZamknięcieOknaPrzyciskiem : Behavior<Window> // Dodaje nowe zachowanie do okna 
    {
        public Key Klawisz { get; set; }

        protected override void OnAttached()
        {
            Window window = this.AssociatedObject; //odczytuję referencję do okna z AssociatedObject
            if (window != null)
            {
                window.PreviewKeyDown += window_PreviewKeyDown; // zapisuję sie na zdarznie w oknie
            }
        }

        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            if (e.Key == Klawisz) window.Close();
        }
    }

    public class PrzyciskZamykającyOkno : Behavior<Window> // Dodaje nowe zachowanie do przycisku
    {
       
        public static readonly DependencyProperty PrzyciskProperty =  //rejestruję nową właściwość zależności - sposób dostępu w magazynie
            DependencyProperty.Register(
                "Przycisk",
                typeof(Button),
                typeof(PrzyciskZamykającyOkno), // typ, który będzie miał tę właściwość, typ zachowania 
                new PropertyMetadata(null, przyciskZmieniny));

        public Button Przycisk
        {
            get { return (Button)GetValue(PrzyciskProperty); } // odczytuję wartość właściwości z Magazynu
            set
            {
                SetValue(PrzyciskProperty, value);      // ustawiam wartość właściwości w Magazynie
            }
        }


        private static void przyciskZmieniny(DependencyObject d, DependencyPropertyChangedEventArgs e)

        {
            Window window = (d as PrzyciskZamykającyOkno).AssociatedObject;
            RoutedEventHandler button_Click = (object sender, RoutedEventArgs _e) => { window.Close();  };
            if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click; // odpinam zdarzenie
            if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click; // przypinam zdarzenie
         
        }

    }


}



