
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppTv.Persistence;
//using AppTv.Views;
namespace AppTv
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MostrarResultado();
            mySearchBar.Focused += MySearchBar_Focused;
        }

        private void MySearchBar_Focused(object sender, FocusEventArgs e)
        {
            // Obtener el campo de entrada de texto dentro del SearchBar
            SearchBar searchBar = (SearchBar)sender;
            searchBar.IsVisible = false; // Esto es opcional para ocultar el SearchBar
            Entry searchEntry = FindSearchEntry(searchBar);

            // Enfocar el campo de entrada de texto
            searchEntry.Focus();
        }

        private Entry FindSearchEntry(SearchBar searchBar)
        {
            // Recorrer los elementos hijos del SearchBar para encontrar el campo de entrada de texto
            foreach (var child in searchBar.Descendants())
            {
                if (child is Entry entry)
                {
                    return entry;
                }
            }
            return null;
        }

        private void MostrarResultado()
        {
            IDeviceInfo info = new DeviceInfo();
            string resultado = info.GetSerialNumber();
            etiquetaResultado.Text = resultado;
        }

        private async void Movies_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Título", "Mensaje de la alerta", "Aceptar");
        }

        private async void Streaming_Clicked(object sender, EventArgs args)
        {
            await DisplayAlert("Título", "Mensaje de la alerta", "Aceptar");
        }

    }
}
