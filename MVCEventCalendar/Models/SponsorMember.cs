using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEventCalendar.Models
{
    public class SponsorMember : Volunteer //Inherits  the volunteer class
    {
        public string ComponyName { get; set; }

        public string Location { get; set; }

        public DateTime founded { get; set; }

        public double amountSponsored { get; set; }

        public SponsorMember(string ComponyName, string Location, DateTime founded, double amountSponsored, string _Name, string _Surname, int? _Age, string _Phone, string type, int id) : base(_Name, _Surname, _Age, _Phone, type, id)
        {
            this.ComponyName = ComponyName;
            this.Location = Location;
            this.founded = founded;
            this.amountSponsored = amountSponsored;
        }

        public override int getDOB()//overrides the one in volunteer class
        {
            return ((int)(DateTime.Now.Year - Age));
        }
        public override string display()//overrides the one in volunteer class
        {
            return "Sponsor member:" + Name + " " + Surname + ", Funding the event";
        }
        public override void setVolunteertype()//overrides the one in volunteer class
        {
            type = "Sponsor Member";
        }
    }
}