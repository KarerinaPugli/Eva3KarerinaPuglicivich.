using Evaluación3KarerinaPuglicivich.Modelos;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Controls;

namespace Evaluación3KarerinaPuglicivich.Vistas
{
    public partial class AgregarEstudiante : ContentPage
    {
        public AgregarEstudiante()
        {
            InitializeComponent();
        }


        private async void GuardarEstudiante_Clicked(object sender, EventArgs e)
        {
            string nombre = nombreEntry.Text;
            string estadoSeleccionado = estadoPicker.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrEmpty(estadoSeleccionado))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            bool activo = estadoSeleccionado == "Activo";

            try
            {
                var firebase = MauiProgram.FirebaseClient;
                var nuevoEstudiante = new Estudiante
                {
                    Nombre = "Pepe Perez",
                    Activo = true
                };

                await firebase.Child("Estudiantes").PostAsync(nuevoEstudiante);
                await DisplayAlert("Éxito", "Estudiante agregado correctamente", "OK");

                
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
