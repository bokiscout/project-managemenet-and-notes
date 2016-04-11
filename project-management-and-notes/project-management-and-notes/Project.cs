using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_management_and_notes
{
    public class Project
    {
        private String name { get; set; }
        private String date { get; set; }   //don't use string for dates
        private String details { get; set; }

        public Project(string name, string date)
        {
            // TODO: Complete member initialization
            this.name = name;
            this.date = date;
            this.details = name + " " + date + " " + name + " " + date + " " + name + " " + date;
        }

        public String GetDetails()
        {
            return details;
        }

        public override string ToString()
        {
            return name + " " + date;
        }
    }
}
