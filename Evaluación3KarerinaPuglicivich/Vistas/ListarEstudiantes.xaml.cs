using Evaluación3KarerinaPuglicivich.Modelos;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Controls;

namespace Evaluación3KarerinaPuglicivich.Vistas
{
    public partial class ListarEstudiantes : ContentPage
    {
        private List<Estudiante> estudiantes = new List<Estudiante>();

        public ListarEstudiantes()
        {
            InitializeComponent();
            CargarEstudiantes();
            
        }
        private async void AgregarEstudianteBoton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarEstudiante());
        }

        private async void CargarEstudiantes()
        {
            try
            {
                var firebase = MauiProgram.FirebaseClient;
                var result = await firebase.Child("Estudiantes").OnceAsync<Estudiante>();
                                           

                
                estudiantes = result
                    .Where(item => item.Object != null && item.Object.Activo)
                    .Select(item => new Estudiante


            {
                    Id = item.Key,
                    Nombre = item.Object.Nombre,
                    Activo = item.Object.Activo
                })
                
                .ToList();

                
                collectionView.ItemsSource = estudiantes;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        
        private void filtroSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filtro = e.NewTextValue?.ToLower() ?? string.Empty;

            if (estudiantes != null)

            {

                collectionView.ItemsSource = string.IsNullOrWhiteSpace(filtro)
                    ? estudiantes : filtro;
                    estudiantes.Where(est => !string.IsNullOrEmpty(est.Nombre) && est.Nombre.ToLower().Contains(filtro)).ToList();

            }
        }



        
        private async void NuevoEstudianteBoton_Clicked(object sender, EventArgs e)
        {
            var nombre = await DisplayPromptAsync("Nuevo Estudiante", "Ingrese el nombre del estudiante:");

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                try
                {
                    var firebase = MauiProgram.FirebaseClient;
                    var nuevoEstudiante = new Estudiante
                    {
                        Nombre = nombre,
                        Activo = true
                    };

                    await firebase.Child("Estudiantes").PostAsync(nuevoEstudiante);
                    await DisplayAlert("Éxito", "Estudiante agregado correctamente", "OK");



                    
                    CargarEstudiantes();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
    }
}
