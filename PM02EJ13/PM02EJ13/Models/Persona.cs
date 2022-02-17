using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM02EJ13.Models
{
    public class Persona
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string name { get; set; }
        public string lname { get; set; }
        public string age { get; set; }
        public string email { get; set; }

        public override string ToString()
        {
            return this.name + " " + this.lname + " | " + this.age + " | " + this.email;
        }
    }
}
