using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppTv.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppTv.Persistence
{
    public class MoviesService
    {
        private readonly string _baseUrl = "http://192.168.1.2:45455/api/";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Movie>> GetMoviesAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + "Movies");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(responseBody);
                    return movies;
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
            catch (JsonException ex)
            {
                throw new JsonException("Error al deserializar la respuesta JSON: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado: " + ex.Message, ex);
            }
        }

        public async Task<List<Movie>> GetMoviesByGenreAsync(string genre)
        {
            try
            {
                string url = $"{_baseUrl}?genre={genre}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(responseBody);
                    return movies;
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
            catch (JsonException ex)
            {
                throw new JsonException("Error al deserializar la respuesta JSON: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado: " + ex.Message, ex);
            }
        }
    }
}

