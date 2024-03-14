

using AppTv.Models;
using AppTv.Persistence;
using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;



namespace AppTv.Views
{
	
	public partial class MoviesPage : ContentPage
	{
        private MoviesService _moviesService = new MoviesService();
        private CustomerService _customerService = new CustomerService();
        public MoviesPage ()
		{
			InitializeComponent ();
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

                imageButton.Clicked += Frame_Clicked; 


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
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al cargar las películas: " + ex.Message);
            }
        }


        private void Frame_Clicked(object sender, EventArgs e)
        {
            // Redireccionar
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

        //async void Movies_Clicked(object sender, EventArgs e)
        //{

        //}

        private async void Streaming_Clicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new StreamingPage());

        }


        //void ApplyFilters_Clicked(object sender, EventArgs e)
        //{
        //    // Obtener los valores de los filtros seleccionados por el usuario
        //    string selectedGenre = GenrePicker.SelectedItem as string;
        //    int selectedYear = 0;
        //    if (!string.IsNullOrEmpty(YearEntry.Text))
        //    {
        //        selectedYear = Convert.ToInt32(YearEntry.Text);
        //    }

        //    // Filtrar la lista de películas
        //   // var filteredMovies = FilterMovies(selectedGenre, selectedYear);

        //    // Actualizar la lista de películas en la interfaz de usuario
        //   // MoviesListView.ItemsSource = filteredMovies;
        //}

         //List<Movie> FilterMovies(string genre, int year)
         //   {
         //       // Implementa la lógica para filtrar las películas basadas en los filtros seleccionados
         //   }


    }
}

