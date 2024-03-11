
using System;
using Xamarin.Forms;
using AppTv.Persistence;
using AppTv.Views;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppTv;
using Android.Content;

namespace AppTv
{
    public partial class MainPage : ContentPage
    {
        
        
        
        public MainPage()
        {
            
            InitializeComponent();
            MostrarResultado();
            
           
        }

      


        //private async Task<bool> VerificarCuenta()
        //{
        //    IDeviceInfo info = new DeviceInfo();
        //    string serial = info.GetSerialNumber();

        //    bool cuentaExiste = await db.VerificarSerial(serial);

        //    if (cuentaExiste)
        //    {
        //        // verificar pago prox
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}



        private async void Movies_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay un pago válido
                //bool pagoValido = await VerificarPago();
                //bool cuentaVerificada = await VerificarCuenta();
                //await db.TestDatabaseConnection();
                //if (cuentaVerificada)
                //{
                //    //Si el pago es válido->navegar a la página de películas
                //    await DisplayAlert("Tienes una suscripcion activa", $"Disfruta de la app", "Aceptar");
                await Navigation.PopAsync();
                await Navigation.PushAsync(new MoviesPage());
                //}
                //else
                //{
                //    // Si el pago no es válido -> mostrar la pantalla de pago
                //    SuscripcionView.IsVisible = true;
                //}
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", $"Error al verificar el pago: {ex.Message}", "OK");
            }
        }

        async void Streaming_Clicked(object sender, EventArgs args)
        {
            try
            {

            //    bool pagoValido = VerificarPago();

            //    if (pagoValido)
            //    {
            // Si el pago es válido -> navegar a la página de streaming
                await Navigation.PopAsync();
                await Navigation.PushAsync(new StreamingPage());
            //    }
            //    else
            //    {
            //        // Si el pago no es válido -> mostrar la pantalla de pago
            //        SuscripcionView.IsVisible = true;
            //    }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", $"Error al verificar el pago: {ex.Message}", "OK");
            }
        }

        //private bool VerificarPago()
        //{
        //   


        //}


        private void MostrarResultado()
        {
            string usuario = "d1ae2cbc8615b719";
            //string persona = "Admin";
            IDeviceInfo info = new DeviceInfo();
            string resultado = info.GetSerialNumber();
            if (resultado == usuario)
            {
                etiquetaResultado.Text = $"Usuario : {usuario}";

            }
        }
        private void OnCancelarClicked(object sender, EventArgs e)
        {
            SuscripcionView.IsVisible = false; // Ocultar el formulario de suscripción
        }


    }
}
