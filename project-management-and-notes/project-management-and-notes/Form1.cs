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
    public partial class Form1 : Form
    {
        //private List<Project> projects { get; set; }
        //private List<Note> notes { get; set; }

        public Form1()
        {
            
            InitializeComponent();
            DateTime deadline = DateTime.Now;
            Project p1 = new Project("First Project", "Project for Mr. I", deadline);
            p1.SetClientName("For you");
            p1.SetName("Project one new name");
            
            Assignment a = new Assignment();
            a.SetIsDone(true);
            a.SetTodo("Do nothing, empty assignment");
            p1.AddAssignment(a);

            CssCode c = new CssCode();
            c.SetCode(@"<p>
</p>");
            c.SetDescription("paragraph");

            p1.AddCssCode(c);

            //Project p2 = new Project("Second Project", "Project for Mr. I", deadline);
            //Project p3 = new Project("Third Project", "Project for Mr. I", deadline);

            //lbProjects.Items.Add(p1);
            //lbProjects.Items.Add(p2);
            //lbProjects.Items.Add(p3);
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void lbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Project project = lbProjects.SelectedItem as Project;
            this.RefreshProjectDetail(project);
        }

        private void RefreshProjectDetail(Project p)
        {
            tbProjectName.Text = p.GetName();
            tbClientName.Text = p.GetClientName();
            tbStartDate.Text = p.GetDateCreatedAsString();
            tbDeadLine.Text = p.GetDateDeadlineAsString();

            
            tbLoginInfoPassword.Clear();
            tbLoginInfoUrl.Clear();
            tbLoginInfoUsername.Clear();
            cbLoginInfo.SelectedIndex = -1;
            cbLoginInfo.Items.Clear();
            List<LoginInfo> loginIformations = p.GetLoginInfo();
            foreach (LoginInfo l in loginIformations)
            {
                cbLoginInfo.Items.Add(l);
            }
            
            //lbAssignments.Items.Clear();
            clbAssignments.Items.Clear();

            List<Assignment> assignments = p.GetAssignments();
            foreach (Assignment a in assignments)
            {
                //lbAssignments.Items.Add(a);
                clbAssignments.Items.Add(a, a.GetIsDone());
            }

            lbCssCodes.Items.Clear();
            List<CssCode> cssCodes = p.GetCssCodes();
            foreach (CssCode c in cssCodes)
            {
                lbCssCodes.Items.Add(c);
            }
        }

        private void lbCssCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CssCode c = lbCssCodes.SelectedItem as CssCode;
            rtbCssCodeDetails.Text = c.GetCode();
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            CreateNewProject createProjectForm = new CreateNewProject();
            if (createProjectForm.ShowDialog() == DialogResult.OK)
            {
                Project p = createProjectForm.GetProjet();
                lbProjects.Items.Add(p);
            }
        }

        private void btnAddAssignment_Click(object sender, EventArgs e)
        {
            CreateNewAssignmentForm createNewAssignment = new CreateNewAssignmentForm();
            if (createNewAssignment.ShowDialog() == DialogResult.OK)
            {
                Assignment a = createNewAssignment.GetAssignment();
                clbAssignments.Items.Add(a);

                Project p = lbProjects.SelectedItem as Project;
                p.AddAssignment(a);
            }
        }

        private void clbAssignments_SelectedValueChanged(object sender, EventArgs e)
        {
            Assignment a = clbAssignments.SelectedItem as Assignment;
            a.SetIsDone(!a.GetIsDone());
        }

        private void btnEditAssignment_Click(object sender, EventArgs e)
        {
            // not implemented !!!
        }

        private void btnAddLoginInfo_Click(object sender, EventArgs e)
        {
            CreateNewLoginInfo createNewLoginInfo = new CreateNewLoginInfo();
            if (createNewLoginInfo.ShowDialog() == DialogResult.OK)
            {
                LoginInfo loginInfo = createNewLoginInfo.GetLoginInfo();
                cbLoginInfo.Items.Add(loginInfo);

                Project p = lbProjects.SelectedItem as Project;
                p.AddLoginInfo(loginInfo);
            }
        }

        private void cbLoginInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoginInfo l = cbLoginInfo.SelectedItem as LoginInfo;
            if (l != null)
            {
                tbLoginInfoPassword.Text = l.GetPassword();
                tbLoginInfoUrl.Text = l.GetUrl();
                tbLoginInfoUsername.Text = l.GetUsername();
            }
        }

        private void btnAddCssCode_Click(object sender, EventArgs e)
        {
            CreateNewCss newCssCodeForm = new CreateNewCss();
            if (newCssCodeForm.ShowDialog() == DialogResult.OK)
            {
                CssCode code = newCssCodeForm.GetCssCode();
                rtbCssCodeDetails.Text = code.GetCode();

                lbCssCodes.Items.Add(code);

                Project p = lbProjects.SelectedItem as Project;
                p.AddCssCode(code);
            }
        }


    }
}
