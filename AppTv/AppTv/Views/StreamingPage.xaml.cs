using AppTv.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTv.Views
{
    
    public partial class StreamingPage : ContentPage
    {
        public StreamingPage()
        {
            InitializeComponent();
            MostrarResultado();
        }

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private void MostrarResultado()
        {
            IDeviceInfo info = new DeviceInfo();
            string resultado = info.GetSerialNumber();

            etiquetaResultado.Text = $"Usuario : {resultado}";
        }

        async void Movies_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new MoviesPage());



        }

        private async void Streaming_Clicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new StreamingPage());

        }


        private void Frame_Clicked(object sender, EventArgs e)
        {
            // Redireccionar
        }


    }
 }