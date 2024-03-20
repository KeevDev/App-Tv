using System;
using Xamarin.Forms;

namespace AppTv.Views
{
    public partial class MoviePlayerPage : ContentPage
    {
        public MoviePlayerPage(string url)
        {
            InitializeComponent();

            Appearing += (sender, e) => CambiarURLIframe(url);
        }

        private async void CambiarURLIframe(string nuevaURL)
        {
            try
            {
                await MiWebView.EvaluateJavaScriptAsync($"document.getElementById('miIframe').src = '{nuevaURL}';");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cambiar la URL del iframe: " + ex.Message);
            }
        }
    }
}
