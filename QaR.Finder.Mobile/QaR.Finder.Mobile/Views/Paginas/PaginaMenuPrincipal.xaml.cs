using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QaR.Finder.Mobile.Views.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaMenuPrincipal : ContentPage
    {
        public PaginaMenuPrincipal()
        {
            
            InitializeComponent();

            //btnVolver.Clicked += (sender, e) =>
            //{
            //    Navigation.PushAsync(new PaginaInicioDeSesion());
            //    Navigation.RemovePage(this);
            //};

            // SI PRESIONAMOS EL BOTON (HARDWARE) VOLVER..
            //if (OnBackButtonPressed())
            //{
            //    Navigation.PopAsync();
            //}
        }
    }
}