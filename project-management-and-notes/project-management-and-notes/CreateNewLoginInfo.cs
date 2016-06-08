using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_management_and_notes
{
    public partial class CreateNewLoginInfo : Form
    {
        private LoginInfo loginInfo { get; set; }

        public CreateNewLoginInfo()
        {
            InitializeComponent();
        }

        public CreateNewLoginInfo(string url, string username, string password)
        {
            InitializeComponent();

            tbUrl.Text = url;
            tbUserName.Text = username;
            tbPassword.Text = password;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            loginInfo = new LoginInfo();
            
            //loginInfo.SetUrl(tbUrl.Text);
            //loginInfo.SetUserName(tbUserName.Text);
            //loginInfo.SetPassword(tbPassword.Text);

            loginInfo.Username = tbUserName.Text.Trim();
            loginInfo.Password = tbPassword.Text.Trim();
            loginInfo.Url = tbUrl.Text.Trim();

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        internal LoginInfo GetLoginInfo()
        {
            return this.loginInfo;
        }
    }
}
