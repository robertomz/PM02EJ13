using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PM02EJ13.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Selecciona una opcion";

            StackLayout stackLayout = new StackLayout();

            // Button Save
            Button button = new Button();
            button.Text = "Añadir Persona";
            button.Clicked += Button_Añadir;
            stackLayout.Children.Add(button);

            //Button Get
            button = new Button();
            button.Text = "Registros";
            button.Clicked += Button_Registros;
            stackLayout.Children.Add(button);

            //Button Edit
            button = new Button();
            button.Text = "Editar";
            button.Clicked += Button_Editar;
            stackLayout.Children.Add(button);

            //Button Delete
            button = new Button();
            button.Text = "Eliminar";
            button.Clicked += Button_Eliminar;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }        

        private async void Button_Añadir(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPerson());
        }

        private async void Button_Registros(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetPerson());
        }

        private async void Button_Editar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPerson());
        }

        private async void Button_Eliminar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeletePerson());
        }
    }
}