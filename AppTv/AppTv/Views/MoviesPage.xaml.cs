

using AppTv.Models;
using AppTv.Persistence;
using System;
using Xamarin.Forms;




namespace AppTv.Views
{
	
	public partial class MoviesPage : ContentPage
	{
        private MoviesService _moviesService = new MoviesService();
        public MoviesPage ()
		{
			InitializeComponent ();
            MostrarResultado();
            LoadMovies();
        }

        private void insertInfo()
        {

            

        }


        //private async void LoadMovies()
        //{

        //    List<Movie> movies = await _moviesService.GetMoviesAsync();

        //    if (movies != null)
        //    {
        //        Casilla.BindingContext = movies[0];
        //        Casilla1.Text = movies[0].Title;
        //    }
        //    else
        //    {

        //    }
        //}

        private void Frame_Clicked(object sender, EventArgs e)
        {
            // Redireccionar
        }



        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private void MostrarResultado()
        {
            IDeviceInfo info = new DeviceInfo();
            string resultado = info.GetSerialNumber();
            
            etiquetaResultado.Text = $"Usuario : {resultado}";
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

