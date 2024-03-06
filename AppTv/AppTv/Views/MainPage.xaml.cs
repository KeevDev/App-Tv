
using System;
using Xamarin.Forms;
using AppTv.Persistence;
using AppTv.Views;
using System.Threading.Tasks;
namespace AppTv
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MostrarResultado();
            //VerificarCuenta();
        }

        //private async void VerificarCuenta()
        //{
        //    //IDeviceInfo info = new DeviceInfo();
        //    //string serial = info.GetSerialNumber();

        //    //// Verificar en la base de datos si existe una cuenta asociada al serial del dispositivo
        //    //bool cuentaExiste = await ExisteCuentaEnBaseDeDatos(serial);

        //    //if (!cuentaExiste)
        //    //{
        //    //    // Si no existe una cuenta, redirigir a la página de registro o inicio de sesión
                
        //    //}
        //}
        //private async Task<bool> ExisteCuentaEnBaseDeDatos(string serial)
        //{
        //    // Aquí debes implementar la lógica para verificar si existe una cuenta asociada al serial en la base de datos
        //    // Puedes usar SQLite o cualquier otro mecanismo de almacenamiento de datos
        //    // Devuelve true si la cuenta existe y false si no existe
        //    return false; // Por ahora devuelve false para simular que no existe una cuenta
        //}


        private void MostrarResultado()
        {
            string usuario = "d1ae2cbc8615b719";
            string persona = "Admin";
            IDeviceInfo info = new DeviceInfo();
            string resultado = info.GetSerialNumber();
            if (resultado == usuario)
            {
                etiquetaResultado.Text = $"Usuario : {persona}";

            }
        }

        private async void Movies_Clicked(object sender, EventArgs e)
        {
            //try
            //{
            //    // Verificar si hay un pago válido
            //    bool pagoValido = await VerificarPago();

            //    if (pagoValido)
            //    {
                    // Si el pago es válido, navegar a la página de películas
                    await Navigation.PushAsync(new MoviesPage());
            //    }
            //    else
            //    {
            //        // Si el pago no es válido, mostrar la pantalla de pago
            //        SuscripcionView.IsVisible = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Manejar la excepción en caso de que ocurra durante la verificación de pago
            //    await DisplayAlert("Error", $"Error al verificar el pago: {ex.Message}", "OK");
            //}
        }

        async void Streaming_Clicked(object sender, EventArgs args)
        {
            //try
            //{
            //    // Verificar si hay un pago válido
            //    bool pagoValido = VerificarPago();

            //    if (pagoValido)
            //    {
                    // Si el pago es válido, navegar a la página de streaming
                    await Navigation.PushAsync(new StreamingPage());
            //    }
            //    else
            //    {
            //        // Si el pago no es válido, mostrar la pantalla de pago
            //        SuscripcionView.IsVisible = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Manejar la excepción en caso de que ocurra durante la verificación de pago
            //    await DisplayAlert("Error", $"Error al verificar el pago: {ex.Message}", "OK");
            //}
        }

        //private bool VerificarPago()
        //{
        //    // Aquí implementa la lógica para verificar si hay un pago válido
        //    // Puedes utilizar tus propios métodos o servicios para realizar esta verificación
        //    // Por ahora, devuelve true para simular que el pago está siempre válido

            
        //}

        private void OnCancelarClicked(object sender, EventArgs e)
        {
            SuscripcionView.IsVisible = false; // Ocultar el formulario de suscripción
        }


    }
}
