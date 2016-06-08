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
    public partial class CreateNewAssignmentForm : Form
    {
        private Assignment assignment { get; set; }
        public CreateNewAssignmentForm()
        {
            InitializeComponent();
        }

        public CreateNewAssignmentForm(string toDo)
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
            assignment = new Assignment();
            //assignment.SetTodo(tbAssignment.Text);

            assignment.ToDo = tbAssignment.Text.Trim();
            assignment.Done = false;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
