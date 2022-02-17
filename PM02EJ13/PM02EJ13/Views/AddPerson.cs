using PM02EJ13.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PM02EJ13.Views
{
    public class AddPerson : ContentPage
    {
        private Entry nameEntry;
        private Entry lnameEntry;
        private Entry ageEntry;
        private Entry emailEntry;
        private Button saveButton;

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");

        public AddPerson()
        {
            this.Title = "Añadir Persona";
            StackLayout stackLayout = new StackLayout();
            
            // Name Entry
            nameEntry = new Entry();
            nameEntry.Keyboard = Keyboard.Text;
            nameEntry.Placeholder = "Nombre";
            stackLayout.Children.Add(nameEntry);

            // LName Entry
            lnameEntry = new Entry();
            lnameEntry.Keyboard = Keyboard.Text;
            lnameEntry.Placeholder = "Apellido";
            stackLayout.Children.Add(lnameEntry);

            // Age Entry
            ageEntry = new Entry();
            ageEntry.Keyboard = Keyboard.Numeric;
            ageEntry.Placeholder = "Edad";
            stackLayout.Children.Add(ageEntry);

            // Email Entry
            emailEntry = new Entry();
            emailEntry.Keyboard = Keyboard.Email;
            emailEntry.Placeholder = "Correo";
            stackLayout.Children.Add(emailEntry);

            //Add Btn
            saveButton = new Button();
            saveButton.Text = "Guardar";
            saveButton.Clicked += saveButton_Clicked;
            stackLayout.Children.Add(saveButton);

            Content = stackLayout;
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Persona>();

            var maxPK = db.Table<Persona>().OrderByDescending(c => c.Id).FirstOrDefault();

            if (!string.IsNullOrEmpty(nameEntry.Text) && !string.IsNullOrEmpty(lnameEntry.Text) && !string.IsNullOrEmpty(ageEntry.Text) && !string.IsNullOrEmpty(emailEntry.Text)) {
                Persona persona = new Persona()
                {
                    Id = (maxPK == null ? 1 : maxPK.Id + 1),
                    name = nameEntry.Text,
                    lname = lnameEntry.Text,
                    age = ageEntry.Text,
                    email = emailEntry.Text
                };

                db.Insert(persona);
                await DisplayAlert(null, persona.name + " Guardado", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Debe llenar todos los campos", "OK");
            }                
        }
    }
}