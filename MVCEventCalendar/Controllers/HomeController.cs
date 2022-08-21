using MVCEventCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventCalendar.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public static List<Event> events = new List<Event>(); //List of events 

        public static List<Volunteer> volunteers = new List<Volunteer>(); //List of volunteers
        public ActionResult Index()
        {
            
            return View();
        }
     
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //This is create volunteer function
        public ActionResult Create(string _Name, string _Surname, int? _Age, string _Phone, string type, int? id, string department, string job, DateTime? enrolldate, int? servicehours, string ComponyName, string Location, DateTime? founded, double? amountSponsored, string communityName, string Contribution, DateTime? joinDate)
        {
            Random random = new Random();
            //Depending on type we will create the corresponding object
            if (type == "Community")
            {  //Create a volunteer object of type communitymember 
               //Implement encapsulation
               //Constuctor was also implemented
               //Polymorphim
                Volunteer volunteer = new CommunityMember(communityName, Contribution, DateTime.Now, servicehours, _Name, _Surname, _Age, _Phone, type, random.Next(999, 10000)); //Polymorphism


                volunteers.Add(volunteer);
            }
            if (type == "Staff")
            {//Example of polymorphism
             //Create a volunteer object of type StaffMember 
             //Implement encapsulation
             //Constuctor was also implemented
             //Polymorphim
                Volunteer volunteer = new StaffMember(department, job, DateTime.Now, (int)servicehours, _Name, _Surname, _Age, _Phone, type, random.Next(999, 10000)); //Polymorphism
                volunteers.Add(volunteer);
            }
            if (type == "Sponsor")
            {//Create a volunteer object of type communitymember 
             //Implement encapsulation by means of Constuctor being also implemented
             //Polymorphim
                Volunteer volunteer = new SponsorMember(ComponyName, Location, (DateTime)founded, (int)amountSponsored, _Name, _Surname, _Age, _Phone, type, random.Next(999, 10000)); //Polymorphism
                volunteers.Add(volunteer);
            }
           
            return View("Members",volunteers);
        }
        public static int temp = 0;
        public ActionResult Add(int id) //displays add page
        {
            temp = id;
            ViewBag.user = volunteers.FirstOrDefault(x => x.id == id).display();
            return View(events);
        }

        [HttpPost]
        public ActionResult Adds(int joined) // Add member to an event
        {
            Volunteer v =  volunteers.FirstOrDefault(x => x.id == temp);

            foreach(var item in events)
            {
                if(item.EventID == joined)
                {
                    item.Description = v.display();
                }
            }
            return View("Index");

        }
        
        public ActionResult Members() //returns the list of members to the view 
        {
            return View(volunteers);
        }

        public JsonResult GetEvents() //read the events to the callendar
        {
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SaveEvent(Event e) //Update and Add
        {
            var status = false;
            Random rand = new Random();
            var dc = events;

            try
            {
                //Update the event
                var x = events.Where(a => a.EventID == e.EventID).First().EventID;
                var v = events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                if (v != null)
                {
                    v.EventID = rand.Next(9999, 10000);
                    v.Subject = e.Subject;
                    v.Start = e.Start;
                    v.End = e.End;
                    v.Description = e.Description;
                    v.IsFullDay = e.IsFullDay;
                    v.ThemeColor = e.ThemeColor;
                }
            }
            catch
            {//Add event
                events.Add(e);
            }


            status = true;


            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;

            var v = events.Where(a => a.EventID == eventID).FirstOrDefault();
            if (v != null)
            {
                events.Remove(v);

                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
    
}