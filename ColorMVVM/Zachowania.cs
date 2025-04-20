using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ColorMVVM
{
    public class ZachowaniaPrzyciskZamykającyOkno : Behavior<Window> // Dodaje nowe zachowanie do okna 
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
}
