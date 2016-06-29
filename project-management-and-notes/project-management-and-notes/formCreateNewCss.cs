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
    public partial class formCreateNewCss : Form
    {
        private CssCode cssCode { get; set; }

        public formCreateNewCss()
        {
            InitializeComponent();
        }

        public formCreateNewCss(string function, string code)
        {
            InitializeComponent();

            tbFunction.Text = function;
            rbCode.Text = code;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public CssCode GetCssCode()
        {
            return this.cssCode;
        }

        private void formCreateNewCss_Resize(object sender, EventArgs e)
        {
            rbCode.Width = this.Width - 50;
            rbCode.Height = this.Height - 170;
            
            tbFunction.Width = rbCode.Width;

            btnAdd.Location = new Point(btnAdd.Location.X, this.Height - 80);
            btnCancel.Location = new Point(btnCancel.Location.X, btnAdd.Location.Y);
        }

        private void tbFunction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void rbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                e.Handled = true;
                this.Close();
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                addForm();
            }
        }

        private void addForm()
        {
            cssCode = new CssCode();
            //cssCode.SetCode(rbCode.Text);
            //cssCode.SetDescription(tbFunction.Text);

            cssCode.Function = tbFunction.Text.Trim();
            cssCode.Code = rbCode.Text;

            DialogResult = DialogResult.OK;
        }

    }
}
