//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using ApiAppTv.Models;
//using Newtonsoft.Json;

//namespace AppTv.Persistence {

//    public class MoviesService
//    {
//        private HttpClient _httpClient = new HttpClient();
//        private string _baseUrl = "https://localhost:44359/api/Movies";

//        public async Task<List<Movie>> GetMoviesAsync()
//        {
//            try
//            {
//                var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl);
//                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                var response = await _httpClient.SendAsync(request);
//                response.EnsureSuccessStatusCode();
//                var content = await response.Content.ReadAsStringAsync();
//                return JsonConvert.DeserializeObject<List<Movie>>(content);
//            }
//            catch (Exception ex)
//            {
//                // Manejar la excepción
//                return null;
//            }
//        }
//    }


//}

