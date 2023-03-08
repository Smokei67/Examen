using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageData : ContentPage
    {
        public PageData()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    txtlatitud.Text = Convert.ToString(location.Latitude);
                    txtlongitud.Text = Convert.ToString(location.Longitude);

                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (Exception ex)
            {
            }

        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            var data = new Models.Data
            {
                nombres = txtnombres.Text,
                apellidos = txtapellidos.Text,
                edad = txtedad.Text,
                PAIS = cbpais.SelectedItem.ToString(),
                nota = txtnota.text,
                
            };


            if (await App.DBdata.Savedata(data) > 0)
                await DisplayAlert("Aviso", "Registrado", "OK");
            else
                await DisplayAlert("Aviso", "Error", "OK");

            var page = new Views.PageResul();
            page.BindingContext = data;
            await Navigation.PushAsync(page);

        }
    }
}