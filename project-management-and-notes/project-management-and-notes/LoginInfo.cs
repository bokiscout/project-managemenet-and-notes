using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project_management_and_notes
{
    public class LoginInfo
    {
        private String url { get; set; }        // where to login
        private String userName { get; set; }   // username for login
        private String password { get; set; }   // password used for the login
        private String otherInfo { get; set; }  // some other info
                                                // could be added later by the user

        public LoginInfo()
        {
            // default constructor
            this.url = "";
            this.userName = "";
            this.password = "";
            this.password = "";
        }

        public String GetUrl()
        {
            return this.url;
        }

        public void SetUrl(String url)
        {
            this.url = url;
        }

        public String GetPassword()
        {
            return this.password;
        }

        public void SetPassword(String password)
        {
            this.password = password;
        }

        public String GetOtherInfo()
        {
            return this.otherInfo;
        }

        public void SetOtherInfo(String otherInfo)
        {
            this.otherInfo = otherInfo;
        }

        public String GetUsername()
        {
            return this.userName;
        }

        public void SetUserName(String userName)
        {
            this.userName = userName;
        }

        public override string ToString()
        {
            // not properly implemented!!!
            // should add name variable for each login info,
            // or return details,
            // or something...
            return this.url;
        }
    }
}
