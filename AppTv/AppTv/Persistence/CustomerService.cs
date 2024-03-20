using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppTv.Models;
using Newtonsoft.Json;


namespace AppTv.Persistence
{
    public class CustomerService
    {
        private readonly string _baseUrl = "http://192.168.1.2:45455/api/";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> VerificarSerial(string serial)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + "Customers/" + serial);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Customer customer = JsonConvert.DeserializeObject<Customer>(responseBody);
                    return customer.Name;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    
                    return null;
                }
                else
                {
                    
                    throw new HttpRequestException("Error en la solicitud HTTP: " + response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                
                throw new HttpRequestException("Error de red: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
               
                throw new Exception("Error inesperado: " + ex.Message, ex);
            }
        }

        public async Task<Customer> GetInfoUser(string serial)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + "Customers/" + serial);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Customer customer = JsonConvert.DeserializeObject<Customer>(responseBody);
                    return customer;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new HttpRequestException("Error en la solicitud HTTP: " + response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("Error de red: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado: " + ex.Message, ex);
            }
        }

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            try
            {
                string jsonCustomer = JsonConvert.SerializeObject(newCustomer);
                StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_baseUrl + "Customers", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Customer createdCustomer = JsonConvert.DeserializeObject<Customer>(responseBody);
                    return createdCustomer;
                }
                else
                {
                    throw new HttpRequestException("Error al crear el cliente: " + response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("Error de red: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado: " + ex.Message, ex);
            }
        }

        public async Task UpdateIdStripe(Customer customer,string IdStripe)
        {
            try
            {
                var customerData = new Dictionary<string, string>
                {
                    { "IdStripe", IdStripe }
                };

                
                string jsonCustomerData = JsonConvert.SerializeObject(customerData);
                StringContent content = new StringContent(jsonCustomerData, Encoding.UTF8, "application/json");

                
                HttpResponseMessage response = await _httpClient.PutAsync(_baseUrl + "Customers/IdStripe/" + customer.Id, content);

                if (response.IsSuccessStatusCode)
                {
                    
                    return;
                }
                else
                {
                    
                    throw new HttpRequestException("Error al actualizar el IdStripe del cliente: " + response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                
                throw new HttpRequestException("Error de red: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error inesperado: " + ex.Message, ex);
            }
        }


    }
}
