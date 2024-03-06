using AppTv.Persistence;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AppTv.Views
{
	
	public partial class MoviesPage : ContentPage
	{
		public MoviesPage ()
		{
			InitializeComponent ();
		}

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private void MostrarResultado()
        {
            IDeviceInfo info = new DeviceInfo();
            string resultado = info.GetSerialNumber();
            etiquetaResultado.Text = resultado;
        }

        async void Movies_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new MoviesPage());



        }

        private async void Streaming_Clicked(object sender, EventArgs args)
        {
            
            await Navigation.PushAsync(new StreamingPage());

        }
    }
}

