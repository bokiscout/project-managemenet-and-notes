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
    public partial class formCreateNewLoginInfo : Form
    {
        private LoginInfo loginInfo { get; set; }

        public formCreateNewLoginInfo()
        {
            InitializeComponent();
        }

        public formCreateNewLoginInfo(string url, string username, string password)
        {
            InitializeComponent();

            tbUrl.Text = url;
            tbUserName.Text = username;
            tbPassword.Text = password;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addLogin();  
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

        private void tbUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void tbUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                e.Handled = true;
                this.Close();
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                addLogin();
            }
        }

        private void addLogin()
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
    }
}
