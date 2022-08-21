using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEventCalendar.Models
{

    public class StaffMember : Volunteer  //inherited class 
    {
        public string department { get; set; }

        public string job { get; set; }

        public DateTime enrolldate { get; set; }

        public int servicehours { get; set; }

        public StaffMember(string department, string job, DateTime enrolldate, int servicehours, string _Name, string _Surname, int? _Age, string _Phone, string type, int id) : base(_Name, _Surname, _Age, _Phone, type, id)
        {
            this.department = department;
            this.job = job;
            this.enrolldate = enrolldate;
            this.servicehours = servicehours;
        }
        public override int getDOB() //overrides the one in volunteer class
        {
            return ((int)(DateTime.Now.Year - Age));
        }
        public override string display() //overrides the one in volunteer class
        {
            return "Staff member:" + Name + " " + Surname + ", Available to serve";
        }
        public override void setVolunteertype() //overrides setvolunteer in base class
        {
            type = "Staff Member";
        }

    }

}