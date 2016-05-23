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

            String projectName = tbProjectName.Text;
            String clientName = tbClientName.Text;
            DateTime deadline = dtpDeadLine.Value.Date;

            //project.SetClientName(clientName);
            //project.SetName(projectName);
            //project.SetDeadline(deadline);

            project.Name = projectName;
            project.Client = clientName;
            project.StartDate = DateTime.Now;
            project.DeadLine = deadline;

            DialogResult = DialogResult.OK;
        }

        public Project GetProjet()
        {
            return this.project;
        }
    }
}
