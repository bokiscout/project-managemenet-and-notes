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
//            DateTime deadline = DateTime.Now;
//            Project p1 = new Project("First Project", "Project for Mr. I", deadline);
//            p1.SetClientName("For you");
//            p1.SetName("Project one new name");
            
//            Assignment a = new Assignment();
//            a.SetIsDone(true);
//            a.SetTodo("Do nothing, empty assignment");
//            p1.AddAssignment(a);

//            CssCode c = new CssCode();
//            c.SetCode(@"<p>
//</p>");
//            c.SetDescription("paragraph");

//            p1.AddCssCode(c);

//            //Project p2 = new Project("Second Project", "Project for Mr. I", deadline);
//            //Project p3 = new Project("Third Project", "Project for Mr. I", deadline);

//            //lbProjects.Items.Add(p1);
//            //lbProjects.Items.Add(p2);
//            //lbProjects.Items.Add(p3);

            refreshFromDatabase();
        }

        private void refreshFromDatabase()
        {
            lbProjects.Items.Clear();

            using (ProjectsDbEntities entitties = new ProjectsDbEntities())
            {
                List<Project> projects = new List<Project>();
                projects = entitties.Projects.ToList();

                foreach (Project p in projects)
                {
                    lbProjects.Items.Add(p);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void lbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Project project = lbProjects.SelectedItem as Project;
            //this.RefreshProjectDetail(project);

            this.RefreshProjectDetail();
            this.refreshLoginInfo();
            this.refreshAssignments();

            this.refreshCssCodes();
        }

        private void refreshCssCodes()
        {
            lbCssCodes.SelectedIndex = -1;
            lbCssCodes.Items.Clear();

            Project p = lbProjects.SelectedItem as Project;
            if (p == null)
            {
                return;
            }
            int projectId = p.Id;

            using (ProjectsDbEntities entities = new ProjectsDbEntities())
            {
                List<CSSCode> cssCodes = entities.CSSCodes.ToList();

                foreach (CSSCode c in cssCodes)
                {
                    if (c.ProjectId == projectId)
                    {
                        lbCssCodes.Items.Add(c);
                    }
                }

                if (lbCssCodes.Items.Count > 0)
                {
                    lbCssCodes.SelectedIndex = 0;
                }
            }
        }

        private void refreshAssignments()
        {
            clbAssignments.SelectedIndex = -1;
            clbAssignments.Items.Clear();

            Project p = lbProjects.SelectedItem as Project;
            if (p == null)
            {
                return;
            }
            int projectId = p.Id;

            using (ProjectsDbEntities entities = new ProjectsDbEntities())
            {
                List<Assignment> assignments = entities.Assignments.ToList();

                foreach (Assignment a in assignments)
                {
                    if (a.ProjectId == projectId)
                    {
                        bool isDone = (bool) a.Done;
                        clbAssignments.Items.Add(a, isDone);
                    }
                }

                if (clbAssignments.Items.Count > 0)
                {
                    clbAssignments.SelectedIndex = 0;
                }
            }
        }

        private void refreshLoginInfo()
        {
            cbLoginInfo.SelectedIndex = -1;
            cbLoginInfo.Items.Clear();

            tbLoginInfoUsername.Clear();
            tbLoginInfoPassword.Clear();
            tbLoginInfoUrl.Clear();

            Project p = lbProjects.SelectedItem as Project;
            if (p == null)
            {
                return;
            }

            int projectId = p.Id;

            using (ProjectsDbEntities entities = new ProjectsDbEntities())
            {
                List<LoginInfo> logins = entities.LoginInfoes.ToList();

                foreach (LoginInfo l in logins)
                {
                    if (l.ProjectId == projectId)
                    {
                        cbLoginInfo.Items.Add(l);
                    }
                }

                if (cbLoginInfo.Items.Count > 0)
                {
                    cbLoginInfo.SelectedIndex = 0;
                }
            }
        }

        private void RefreshProjectDetail()
        {
            //tbProjectName.Text = p.GetName();
            //tbClientName.Text = p.GetClientName();
            //tbStartDate.Text = p.GetDateCreatedAsString();
            //tbDeadLine.Text = p.GetDateDeadlineAsString();

            
            //tbLoginInfoPassword.Clear();
            //tbLoginInfoUrl.Clear();
            //tbLoginInfoUsername.Clear();
            //cbLoginInfo.SelectedIndex = -1;
            //cbLoginInfo.Items.Clear();
            //List<LoginInfo> loginIformations = p.GetLoginInfo();
            //foreach (LoginInfo l in loginIformations)
            //{
            //    cbLoginInfo.Items.Add(l);
            //}
            
            ////lbAssignments.Items.Clear();
            //clbAssignments.Items.Clear();

            //List<Assignment> assignments = p.GetAssignments();
            //foreach (Assignment a in assignments)
            //{
            //    //lbAssignments.Items.Add(a);
            //    clbAssignments.Items.Add(a, a.GetIsDone());
            //}

            //lbCssCodes.Items.Clear();
            //List<CssCode> cssCodes = p.GetCssCodes();
            //foreach (CssCode c in cssCodes)
            //{
            //    lbCssCodes.Items.Add(c);
            //}

            Project p = lbProjects.SelectedItem as Project;

            if (p != null)
            {
                tbProjectName.Text = p.Name;
                tbClientName.Text = p.Client;

                tbStartDate.Text = p.StartDate.ToString();
                tbDeadLine.Text = p.DeadLine.ToString();
            }
            else
            {
                tbProjectName.Clear();
                tbClientName.Clear();

                tbStartDate.Clear();
                tbDeadLine.Clear();
            }
        }

        private void lbCssCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CssCode c = lbCssCodes.SelectedItem as CssCode;
            //rtbCssCodeDetails.Text = c.GetCode();

            CSSCode c = lbCssCodes.SelectedItem as CSSCode;
            if (c != null)
            {
                rtbCssCodeDetails.Text = c.Code;
            }
            else
            {
                rtbCssCodeDetails.Clear();
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            CreateNewProject createProjectForm = new CreateNewProject();
            if (createProjectForm.ShowDialog() == DialogResult.OK)
            {
                Project p = createProjectForm.GetProjet();

                using (ProjectsDbEntities entitties = new ProjectsDbEntities())
                {
                    entitties.Projects.Add(p);
                    entitties.SaveChanges();
                }

                this.refreshFromDatabase();
            }
        }

        private void btnAddAssignment_Click(object sender, EventArgs e)
        {
            //CreateNewAssignmentForm createNewAssignment = new CreateNewAssignmentForm();
            //if (createNewAssignment.ShowDialog() == DialogResult.OK)
            //{
            //    Assignment a = createNewAssignment.GetAssignment();
            //    clbAssignments.Items.Add(a);

            //    Project p = lbProjects.SelectedItem as Project;
            //    p.AddAssignment(a);
            //}

            CreateNewAssignmentForm createNewAssignment = new CreateNewAssignmentForm();

            if (createNewAssignment.ShowDialog() == DialogResult.OK)
            {
                Project p = lbProjects.SelectedItem as Project;
                int projectId = p.Id;

                Assignment a = createNewAssignment.GetAssignment();
                a.ProjectId = projectId;

                using (ProjectsDbEntities entitties = new ProjectsDbEntities())
                {
                    entitties.Assignments.Add(a);
                    entitties.SaveChanges();
                }

                this.refreshAssignments();
            }
        }

        private void clbAssignments_SelectedValueChanged(object sender, EventArgs e)
        {
            //Assignment a = clbAssignments.SelectedItem as Assignment;
            //a.SetIsDone(!a.GetIsDone());
        }

        private void btnEditAssignment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void btnAddLoginInfo_Click(object sender, EventArgs e)
        {
            //CreateNewLoginInfo createNewLoginInfo = new CreateNewLoginInfo();
            //if (createNewLoginInfo.ShowDialog() == DialogResult.OK)
            //{
            //    LoginInfo loginInfo = createNewLoginInfo.GetLoginInfo();
            //    cbLoginInfo.Items.Add(loginInfo);

            //    Project p = lbProjects.SelectedItem as Project;
            //    p.AddLoginInfo(loginInfo);
            //}

            Project p = lbProjects.SelectedItem as Project;
            int projectId = p.Id;

            CreateNewLoginInfo createNewLoginInfo = new CreateNewLoginInfo();
            if (createNewLoginInfo.ShowDialog() == DialogResult.OK)
            {
                //LoginInfo loginInfo = createNewLoginInfo.GetLoginInfo();
                //cbLoginInfo.Items.Add(loginInfo);

                //Project p = lbProjects.SelectedItem as Project;
                //p.AddLoginInfo(loginInfo);

                LoginInfo l = createNewLoginInfo.GetLoginInfo();
                l.ProjectId = projectId;

                using (ProjectsDbEntities entitties = new ProjectsDbEntities())
                {
                    entitties.LoginInfoes.Add(l);
                    entitties.SaveChanges();
                }

                this.refreshLoginInfo();
            }
        }

        private void cbLoginInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoginInfo l = cbLoginInfo.SelectedItem as LoginInfo;
            //if (l != null)
            //{
            //    tbLoginInfoPassword.Text = l.GetPassword();
            //    tbLoginInfoUrl.Text = l.GetUrl();
            //    tbLoginInfoUsername.Text = l.GetUsername();
            //}

            LoginInfo l = cbLoginInfo.SelectedItem as LoginInfo;
            if (l != null)
            {
                tbLoginInfoUsername.Text = l.Username;
                tbLoginInfoPassword.Text = l.Password;
                tbLoginInfoUrl.Text = l.Url;
            }
        }

        private void btnAddCssCode_Click(object sender, EventArgs e)
        {
            //CreateNewCss newCssCodeForm = new CreateNewCss();
            //if (newCssCodeForm.ShowDialog() == DialogResult.OK)
            //{
            //    CssCode code = newCssCodeForm.GetCssCode();
            //    rtbCssCodeDetails.Text = code.GetCode();

            //    lbCssCodes.Items.Add(code);

            //    Project p = lbProjects.SelectedItem as Project;
            //    p.AddCssCode(code);
            //}

            Project p = lbProjects.SelectedItem as Project;
            if (p == null)
            {
                MessageBox.Show("Select project first, than you can add .css");
                return;
            }

            int projectId = p.Id;

            CreateNewCss newCssCodeForm = new CreateNewCss();

            if (newCssCodeForm.ShowDialog() == DialogResult.OK)
            {
                CSSCode code = newCssCodeForm.GetCssCode();
                code.ProjectId = projectId;

                using (ProjectsDbEntities entitties = new ProjectsDbEntities())
                {
                    entitties.CSSCodes.Add(code);
                    entitties.SaveChanges();
                }

                this.refreshCssCodes();
            }
        }

        private void btnDeleteLoginInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void btnEdiLoginInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void btnEditCss_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }


    }
}
