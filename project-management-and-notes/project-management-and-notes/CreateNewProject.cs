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
    public partial class CreateNewProject : Form
    {
        private Project project { get; set; }
        public CreateNewProject()
        {
            InitializeComponent();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            project = new Project();

            String clientName = tbClientName.Text;
            String projectName = tbProjectName.Text;
            DateTime deadline = dtpDeadLine.Value.Date;

            project.SetClientName(clientName);
            project.SetName(projectName);
            project.SetDeadline(deadline);

            DialogResult = DialogResult.OK;
        }

        public Project GetProjet()
        {
            return this.project;
        }
    }
}
