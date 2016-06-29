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
    public partial class formCreateNewAssignment : Form
    {
        private Assignment assignment { get; set; }
        public formCreateNewAssignment()
        {
            InitializeComponent();
        }

        public formCreateNewAssignment(string toDo)
        {
            InitializeComponent();
            tbAssignment.Text = toDo;
        }

        public Assignment GetAssignment()
        {
            return this.assignment;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addAsignment();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbAssignment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                addAsignment();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void addAsignment()
        {
            assignment = new Assignment();
            //assignment.SetTodo(tbAssignment.Text);

            assignment.ToDo = tbAssignment.Text.Trim();
            assignment.IsDone = false;

            DialogResult = DialogResult.OK;
        }
    }
}
