using System;
using Xamarin.Forms;

namespace AppTv.Views
{
    public partial class MoviePlayerPage : ContentPage
    {
        public MoviePlayerPage(string url)
        {
            InitializeComponent();

            // Suscribe el método CambiarURLIframe al evento Appearing de la página
            Appearing += (sender, e) => CambiarURLIframe(url);
        }

        private async void CambiarURLIframe(string nuevaURL)
        {
            try
            {
                // Usamos JavaScript para cambiar la URL del iframe
                await MiWebView.EvaluateJavaScriptAsync($"document.getElementById('miIframe').src = '{nuevaURL}';");
            }
            catch (Exception ex)
            {
                // Maneja cualquier error
                Console.WriteLine("Error al cambiar la URL del iframe: " + ex.Message);
            }
        }
    }
}
