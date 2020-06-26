using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace QaR.Finder.Mobile.Views
{
    public class ListasDemo : ContentPage
    {
        public ListasDemo()
        {
            string[] nombres =  
            {
                "Hector",
                "Cristina",
                "Pedro",
                "Juan",
                "Marcos",
                "Rosana",
                "Lorena",
                "Augusto",
                "Luz",
                "Lisa"
            };

            var miListView = new ListView();
            miListView.ItemsSource =
                from nombre in nombres
                where nombre.StartsWith("L")
                select nombre;

            // EVENTO AL SELECCIONAR UN ITEM
            miListView.ItemSelected += (sender, e) =>
            {
                if(e.SelectedItem != null)
                {
                    Debug.WriteLine("Selected: " + e.SelectedItem);
                    miListView.SelectedItem = null; // FRENA LA SELECCION
                }
            };

            Content = miListView;
        }
    }
}