using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEventCalendar.Models
{
    public class CommunityMember : Volunteer // //inherited class 
    {
        public string communityName { get; set; }

        public string Contribution { get; set; }

        public DateTime joinDate { get; set; }

        public int? servicehours { get; set; }

        public CommunityMember(string communityName, string Contribution, DateTime joinDate, int? servicehours, string _Name, string _Surname, int? _Age, string _Phone, string type, int id) : base(_Name, _Surname, _Age, _Phone, type, id)
        {
            this.communityName = communityName;
            this.Contribution = Contribution;
            this.joinDate = joinDate;
            this.servicehours = servicehours;
        }
        public override int getDOB() //overrides the one in volunteer class
        {
            return ((int)(DateTime.Now.Year - Age));
        }
        public override string display() //overrides the one in volunteer class
        {
            return "Community member:" + Name + " " + Surname + ", Available to serve";
        }
        public override void setVolunteertype() //overrides the one in volunteer class
        {
            type = "Community Member";
        }
    }

}