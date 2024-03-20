using System;
using System.Threading.Tasks;
using Stripe;
using AppTv.Models;

namespace AppTv.Persistence
{
    public class PayService
    {
        private readonly string _stripeApiKey = "sk_test_51OrBwQCFyAy8V6EbRogNUphe3cj8OZJCf9HNDngYDKMk40gUoIcL5HVoumsYZwrTqhMNsVgZSOXVtl3cSAbuBLt000sBGo2McQ";

        public async Task<bool> Suscription(string serial, CustomerService customerService)
        {
            try
            {
                StripeConfiguration.ApiKey = _stripeApiKey;
                AppTv.Models.Customer customer = await customerService.GetInfoUser(serial);
                var options = new SubscriptionListOptions
                {
                    Customer = customer.IdStripe,
                    Limit = 1 
                };

                var service = new SubscriptionService();
                var subscriptions = await service.ListAsync(options);

                if (subscriptions.Data.Count > 0)
                {
                    var subscription = subscriptions.Data[0];
                    return subscription.Status == "active";
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la suscripción: " + ex.Message, ex);
            }
        }
        public async Task<string> CreateUserStripe(AppTv.Models.Customer customer)
        {
            try
            {
                StripeConfiguration.ApiKey = _stripeApiKey;

                var options = new CustomerCreateOptions
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone
                };

                var service = new Stripe.CustomerService();
                var createdCustomer = await service.CreateAsync(options);

                return createdCustomer.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario en Stripe: " + ex.Message, ex);
            }
        }

    }
}
