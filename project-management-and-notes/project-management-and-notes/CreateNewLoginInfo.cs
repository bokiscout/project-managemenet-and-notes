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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            loginInfo = new LoginInfo();
            
            //loginInfo.SetUrl(tbUrl.Text);
            //loginInfo.SetUserName(tbUserName.Text);
            //loginInfo.SetPassword(tbPassword.Text);

            loginInfo.Username = tbUserName.Text;
            loginInfo.Password = tbPassword.Text;
            loginInfo.Url = tbUrl.Text;

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
