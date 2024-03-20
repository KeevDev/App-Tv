using AppTv.Models;
using AppTv.Persistence;
using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;





namespace AppTv.Views
{

    public partial class MoviesPage : ContentPage
    {
        private MoviesService _moviesService = new MoviesService();
        private CustomerService _customerService = new CustomerService();
        private List<Movie> _movies = new List<Movie>();
        public MoviesPage()
        {
            InitializeComponent();
            Info();
            LoadMovies();
        }

        private void insertInfo(List<Movie> movies)
        {
            moviesGrid.Children.Clear();

            int numRows = movies.Count / 4;
            if (movies.Count % 4 != 0)
                numRows++;

            moviesGrid.RowDefinitions.Clear();

            for (int i = 0; i < numRows; i++)
            {
                moviesGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            }


            for (int i = 0; i < movies.Count; i++)
            {
                int row = i / 4;
                int column = i % 4;

                ImageButton imageButton = new ImageButton
                {
                    Source = movies[i].Cover,
                    Opacity = 0.7,
                    Aspect = Aspect.AspectFill,
                    Margin = new Thickness(0, 0, 0, 20),

                };

                imageButton.Clicked += ImageButton_Clicked;


                Label label = new Label
                {
                    Text = movies[i].Title,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.EndAndExpand
                };

                // Agregar los controles al Grid
                moviesGrid.Children.Add(imageButton, column, row);
                Grid.SetColumnSpan(label, 2);
                moviesGrid.Children.Add(label, column, row); // Añadir la etiqueta en la misma columna y fila
            }
        }

        private async void LoadMovies()
        {
            try
            {
                List<Movie> movies = await _moviesService.GetMoviesAsync();
                insertInfo(movies);
                _movies = movies;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al cargar las películas: " + ex.Message);
            }
        }


        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                ImageButton clickedImageButton = (ImageButton)sender;
                Movie selectedMovie = null;

                foreach (var movie in _movies)
                {
                    string cover = clickedImageButton.Source.ToString();
                    // Verificar si la cadena de la URL contiene el prefijo "Uri: "
                    if (cover.Contains("Uri: "))
                    {
                        // Eliminar el prefijo "Uri: " de la URL
                        cover = cover.Replace("Uri: ", "");
                    }
                    if (cover == movie.Cover)
                    {
                        selectedMovie = movie;
                        break;
                    }
                }

                if (selectedMovie != null)
                {
                    // Aquí puedes navegar a la página de detalles de la película, pasando la película seleccionada
                    await Navigation.PushAsync(new MoviePlayerPage(selectedMovie.MovieVideo));
                }
                else
                {
                    // No se encontró la película correspondiente a la imagen clickeada
                    await DisplayAlert("Error", "No se pudo encontrar la película seleccionada", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al manejar la selección de película: {ex.Message}", "OK");
            }
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



        private async void Streaming_Clicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new StreamingPage());

        }


    }
}
