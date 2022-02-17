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
    public class DeletePerson : ContentPage
    {
        private ListView listView;
        private Button deleteButton;

        Persona persona = new Persona();

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");

        public DeletePerson()
        {
            this.Title = "Eliminar Persona";

            var db = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db.Table<Persona>().OrderBy(x => x.Id).ToList();
            listView.ItemSelected += listViewItem;
            stackLayout.Children.Add(listView);

            //Delete Btn
            deleteButton = new Button();
            deleteButton.Text = "Eliminar";
            deleteButton.Clicked += deleteButton_Clicked;
            stackLayout.Children.Add(deleteButton);

            Content = stackLayout;
        }        

        private void listViewItem(object sender, SelectedItemChangedEventArgs e)
        {
            persona = (Persona)e.SelectedItem;
        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            db.Table<Persona>().Delete(x => x.Id == persona.Id);
            await DisplayAlert(null, persona.name + " Eliminado", "OK");
            await Navigation.PopAsync();
        }
    }
}