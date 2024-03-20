using System;
using Xamarin.Forms;
using AppTv.Persistence;
using AppTv.Views;
using System.Threading.Tasks;
using AppTv.Models;
using System.Collections.Generic;
using Java.Util;
using System.Linq;


namespace AppTv
{
    public partial class MainPage : ContentPage
    {
        private CustomerService _customerService = new CustomerService();
        private PayService _payService = new PayService();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await VerificarCuenta();
        }


        private void OnSend(object sender, EventArgs e)
        {
            string serial = info();
            Header.Opacity = 1;
            UnfocusFooter.Opacity = 1;
            SuscripcionView.IsVisible = false;

            Grid parentGrid = (Grid)Main.Parent;
            Grid.SetRow(Main, 1);
            CrearCliente(serial);

        }

        private void OnCancel(object sender, EventArgs e)
        {
            Header.Opacity = 1;
            UnfocusFooter.Opacity = 1;
            SuscripcionView.IsVisible = false;

            Grid parentGrid = (Grid)Main.Parent;
            Grid.SetRow(Main, 1);
        }

        private async Task CrearCliente(string serial)
        {
            try
            {

                Customer customer = new Customer();
                customer.Name = NameCreate.Text;
                customer.Email = EmailCreate.Text;
                customer.Phone = TelephoneCreate.Text;
                customer.Serial = serial;

                Customer createdCustomer = await _customerService.CreateCustomer(customer);
                string IdStripe = await _payService.CreateUserStripe(customer);
                await _customerService.UpdateIdStripe(createdCustomer, IdStripe);
                // metodo para llevar al primer pago (pay intent)
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el cliente: " + ex.Message, ex);
            }
        }

        private async Task VerificarCuenta()
        {
            try
            {
                string serial = info();
                string usuario = await _customerService.VerificarSerial(serial);
                if (usuario != null)
                {
                    etiquetaResultado.Text = $"Bienvenido {usuario}";
                }
                else
                {
                    SuscripcionView.IsVisible = true;
                    etiquetaResultado.Text = "Cuenta no encontrada";
                    Header.Opacity = 0.2;
                    Grid parentGrid = (Grid)Main.Parent;
                    Grid.SetRow(Main, 0);
                    UnfocusFooter.Opacity = 0.2;
                    
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al verificar la cuenta: {ex.Message}", "OK");
            }
        }

        private async void Movies_Clicked(object sender, EventArgs e)
        {
            try
            {
                string serial = info();
                bool pay = await PayVerification(serial);
                if (pay)
                {
                    await Navigation.PopAsync();
                    await Navigation.PushAsync(new MoviesPage());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al navegar a la página de películas: {ex.Message}", "OK");
            }
        }

        private async void Streaming_Clicked(object sender, EventArgs e)
        {
            try
            {
                string serial = info();
                bool pay = await PayVerification(serial);
                if (pay)
                {
                    await Navigation.PopAsync();
                    await Navigation.PushAsync(new StreamingPage());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al navegar a la página de streaming: {ex.Message}", "OK");
            }
        }

        private string info()
        {
            IDeviceInfo info = new DeviceInfo();
            string resultado = info.GetSerialNumber();
            return resultado;
        }

        private async Task<bool> PayVerification(string serial)
        {
            try
            {
                bool pagos = await _payService.Suscription(serial, _customerService);
                if (pagos) {
                    return pagos;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error en la verificación de pago: {ex.Message}", "OK");
                return false;
            }
        }
    }
}
