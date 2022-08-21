using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEventCalendar.Models
{
    public class Event //My event class which store my callendar data
    {
        public int EventID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime? End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
    }
}