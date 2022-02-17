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
    public class GetPerson : ContentPage
    {
        private ListView listView;

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");
        public GetPerson()
        {
            this.Title = "Personas";

            var db = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            listView.ItemsSource = db.Table<Persona>().OrderBy(x => x.Id).ToList();
            stackLayout.Children.Add(listView);

            Content = stackLayout;
        }
    }
}