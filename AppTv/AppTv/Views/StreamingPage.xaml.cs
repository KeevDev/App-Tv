using AppTv.Persistence;
using System;
using Xamarin.Forms;


namespace AppTv.Views
{
    
    public partial class StreamingPage : ContentPage
    {
        private MoviesService _moviesService = new MoviesService();
        private CustomerService _customerService = new CustomerService();
        public StreamingPage()
        {
            InitializeComponent();
            Info();
        }

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private async void Info()
        {
            IDeviceInfo info = new DeviceInfo();
            string serial = info.GetSerialNumber();
            string usuario = await _customerService.VerificarSerial(serial);
            etiquetaResultado.Text = $"Bienvenido {usuario}";
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