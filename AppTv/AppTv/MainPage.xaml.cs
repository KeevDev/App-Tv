
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppTv.Persistence;
namespace AppTv
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MostrarResultado();
            //Movies_Clicked();
            //Streaming_Clicked();
            
        }

        private void MostrarResultado()
        {
            IDeviceInfo info = new DeviceInfo();
            string resultado = info.GetSerialNumber();
            etiquetaResultado.Text = resultado;
        }

        private async void Movies_Clicked(object sender, EventArgs e)
        {

            //await btnMovies.DisplayAlert("Mensaje", "Haz clic en la sección Películas", "OK");
            // Aquí puedes agregar la lógica para cambiar a la sección de películas
            // Por ejemplo, puedes navegar a una nueva página o cargar contenido dinámicamente.
            DisplayAlert("Mensaje", "Haz clic en la sección Streaming", "OK");
        }

        private void Streaming_Clicked(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica para cambiar a la sección de streaming
            // Por ejemplo, puedes navegar a una nueva página o cargar contenido dinámicamente.
            DisplayAlert("Mensaje", "Haz clic en la sección Streaming", "OK");
        }

    }
}
