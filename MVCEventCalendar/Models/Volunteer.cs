using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEventCalendar.Models
{
    public abstract class Volunteer //My base abstract class
    {
        //My members
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string type { get; set; }

        //my constuctor

        public Volunteer(string _Name, string _Surname, int? _Age, string _Phone, string type, int id)
        {
            Name = _Name;
            Surname = _Surname;
            Age = (int)_Age;
            Phone = _Phone;
            this.type = type;
            this.id = id;
        }
        //default constructor 
        public Volunteer()
        {
            Name = " ";
            Surname = " ";
            Age = 0;
            Phone = "";

        }
        public abstract int getDOB(); //abstract class which returns date of birth

        public abstract void setVolunteertype(); //abstact class which sets volunteer type
        public virtual string display() //which displays the home message
        {
            return "";
        }
    }
}