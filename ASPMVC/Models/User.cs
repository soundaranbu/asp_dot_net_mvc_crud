using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVC.Models
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }

        public long TimeCreated { get; set; }

        public long TimeModified { get; set; }

        public String TimeCreatedString {
            get {
                    DateTime date = new DateTime(1970,1,1,0,0,0,0, System.DateTimeKind.Utc);
                    date = date.AddSeconds(this.TimeCreated).ToLocalTime();
                    return date.ToString("ddd, dd MMM yyyy  hh:mm:ss tt");
                }
        }

        public String TimeModifiedString
        {
            get
            {
                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                date = date.AddSeconds(this.TimeModified).ToLocalTime();
                return date.ToString("ddd, dd MMM yyyy  hh:mm:ss tt");
            }
        }
    }
}