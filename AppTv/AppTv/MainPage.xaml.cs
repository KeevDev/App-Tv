
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTv
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        private void Peliculas_Clicked(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica para cambiar a la sección de películas
            // Por ejemplo, puedes navegar a una nueva página o cargar contenido dinámicamente.
            DisplayAlert("Mensaje", "Haz clic en la sección Películas", "OK");
        }

        private void Streaming_Clicked(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica para cambiar a la sección de streaming
            // Por ejemplo, puedes navegar a una nueva página o cargar contenido dinámicamente.
            DisplayAlert("Mensaje", "Haz clic en la sección Streaming", "OK");
        }
    }
}
