using QaR.Finder.Mobile.Models;
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
    public partial class PaginaInicioDeSesion : ContentPage
    {
        
        public Usuario usuario { get; set; }
        
        public PaginaInicioDeSesion()
        {
            usuario = new Usuario();
            usuario.nombre = "Augusto";
            usuario.apellido = "Coda";
            usuario.email = "augusto.coda@live.com";
            usuario.password = "XXXXXXXXXXXXXX";
            BindingContext = usuario;

            PaginaMenuPrincipal _menuPrincipal = new PaginaMenuPrincipal();          

            InitializeComponent();

            // AL HACER CLIK..
            btnIniciarSesion.Clicked += (sender, e) =>
            {
                // IR AL MENU PRINCIPAL
                Navigation.PushAsync(_menuPrincipal);
            };
        }
    }
}