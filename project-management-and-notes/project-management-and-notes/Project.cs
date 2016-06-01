using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_management_and_notes
{
    public class Project
    {
        private String name { get; set; }       // name of the project
        private String clientName { get; set; } // name of the client this project is created for
        private DateTime date { get; set; }     // time, probably in gorgian calendar
        private DateTime deadline { get; set; } // project must be done before this date
        private List<Assignment> assignments { get; set; }  // list of jobst taht must be done
                                                            // for this project to become done
        private String details { get; set; }    // some details about the project
                                                // this is writen by the outhir of the project
        private List<LoginInfo> loginInfo { get; set; }     // login infomrations for current project
                                                            // server password, database passwords etc...
        private List<CssCode> cssCodes { get; set; }        // list of css codes created for this project

        public Project()
        {
            // default constructor
            this.name = "";
            this.clientName = "";
            this.date = DateTime.Now;
            this.deadline = DateTime.Now;
            this.assignments = new List<Assignment>();
            this.details = "";
            this.loginInfo = new List<LoginInfo>();
            this.cssCodes = new List<CssCode>();
        }

        public Project(String name, String clientName, DateTime deadline)
        {
            this.name = name;
            this.clientName = clientName;
            this.date = DateTime.Now;
            this.deadline = deadline;
            this.assignments = new List<Assignment>();
            this.details = "";    // pass it ass argument
            this.loginInfo = new List<LoginInfo>();     // create copy of login info
            this.cssCodes = new List<CssCode>();
        }

        public String GetName(){
            return this.name;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public String GetClientName()
        {
            return this.clientName;
        }

        public void SetClientName(String clientName)
        {
            this.clientName = clientName;
        }

        public String GetDateCreatedAsString()
        {
            return this.date.ToShortDateString();
        }

        public String GetDateDeadlineAsString()
        {
            return this.deadline.ToShortDateString();
        }

        public void SetDeadline(DateTime date)
        {
            this.deadline = date;
        }

        public DateTime GetDeadline()
        {
            return this.deadline;
        }

        public List<Assignment> GetAssignments()
        {
            return this.assignments;
        }

        public List<LoginInfo> GetLoginInfo()
        {
            return loginInfo;
        }

        public void AddLoginInfo(LoginInfo info)
        {
            this.loginInfo.Add(info);
        }

        public String GetDetails()
        {
            return details;
        }

        public void AddAssignment(Assignment a)
        {
            assignments.Add(a);
        }

        public void AddCssCode(CssCode n)
        {
            cssCodes.Add(n);
        }

        public List<CssCode> GetCssCodes()
        {
            return this.cssCodes;
        }

        public override string ToString()
        {
            // used only to display text in ListBox 'lbProjects'
            return this.GetName();
        }
    }
}
