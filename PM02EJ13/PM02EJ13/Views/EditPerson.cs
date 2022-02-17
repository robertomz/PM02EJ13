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
    public class EditPerson : ContentPage
    {
        private ListView listView;

        private Entry idEntry;
        private Entry nameEntry;
        private Entry lnameEntry;
        private Entry ageEntry;
        private Entry emailEntry;

        private Button editButton;

        Persona persona = new Persona();

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");

        public EditPerson()
        {
            this.Title = "Editar Persona";

            var db = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db.Table<Persona>().OrderBy(x => x.Id).ToList();
            listView.ItemSelected += listViewItem;
            stackLayout.Children.Add(listView);

            // ID Entry
            idEntry = new Entry();
            idEntry.Placeholder = "ID";
            idEntry.IsVisible = false;
            stackLayout.Children.Add(idEntry);

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

            //Edit Btn
            editButton = new Button();
            editButton.Text = "Editar";
            editButton.Clicked += editButton_Clicked;
            stackLayout.Children.Add(editButton);

            Content = stackLayout;
        }
        
        private void listViewItem(object sender, SelectedItemChangedEventArgs e)
        {
            persona = (Persona)e.SelectedItem;
            idEntry.Text = persona.Id.ToString();
            nameEntry.Text = persona.name.ToString();
            lnameEntry.Text = persona.lname.ToString();
            ageEntry.Text = persona.age.ToString();
            emailEntry.Text = persona.email.ToString();
        }

        private async void editButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);

            if (!string.IsNullOrEmpty(nameEntry.Text) && !string.IsNullOrEmpty(lnameEntry.Text) && !string.IsNullOrEmpty(ageEntry.Text) && !string.IsNullOrEmpty(emailEntry.Text))
            {
                Persona persona = new Persona()
                {
                    Id = Convert.ToInt32(idEntry.Text),
                    name = nameEntry.Text,
                    lname = lnameEntry.Text,
                    age = ageEntry.Text,
                    email = emailEntry.Text
                };

                db.Update(persona);
                await DisplayAlert(null, persona.name + " Editado", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Debe llenar todos los campos", "OK");
            }
        }
    }
}