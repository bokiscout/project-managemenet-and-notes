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
            refreshFromDatabase();
        }

        private void refreshFromDatabase()
        {
            lbProjects.Items.Clear();

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("refreshFromDatabase\n\n" + ex.ToString());
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void lbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("refreshCssCodes\n\n" + ex.ToString());
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

            try
            {
                using (ProjectsDbEntities entities = new ProjectsDbEntities())
                {
                    List<Assignment> assignments = entities.Assignments.ToList();

                    foreach (Assignment a in assignments)
                    {
                        if (a.ProjectId == projectId)
                        {
                            bool isDone = (bool)a.Done;
                            clbAssignments.Items.Add(a, isDone);
                        }
                    }

                    if (clbAssignments.Items.Count > 0)
                    {
                        clbAssignments.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("refreshAssignments\n\n" + ex.ToString());
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

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("refreshLoginInfo\n\n" + ex.ToString());
            }
        }

        private void RefreshProjectDetail()
        {
            // ********************************************************
            // to do
            //
            // read from database instead of object in the list box!
            //********************************************************
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
                try
                {
                    using (ProjectsDbEntities entitties = new ProjectsDbEntities())
                    {
                        entitties.Projects.Add(p);
                        entitties.SaveChanges();
                    }

                    this.refreshFromDatabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("btnAddProject_click\n\n" + ex.ToString());
                }
                
            }
        }

        private void btnAddAssignment_Click(object sender, EventArgs e)
        {
            CreateNewAssignmentForm createNewAssignment = new CreateNewAssignmentForm();

            if (createNewAssignment.ShowDialog() == DialogResult.OK)
            {
                Project p = lbProjects.SelectedItem as Project;
                int projectId = p.Id;

                Assignment a = createNewAssignment.GetAssignment();
                a.ProjectId = projectId;
                
                try
                {
                    using (ProjectsDbEntities entitties = new ProjectsDbEntities())
                    {
                        entitties.Assignments.Add(a);
                        entitties.SaveChanges();
                    }

                    this.refreshAssignments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("btnAddAssignment_click\n\n" + ex.ToString());
                }
            }
        }

        private void clbAssignments_SelectedValueChanged(object sender, EventArgs e)
        {
            //Assignment a = clbAssignments.SelectedItem as Assignment;
            //a.SetIsDone(!a.GetIsDone());
        }

        private void btnEditAssignment_Click(object sender, EventArgs e)
        {
            Assignment current = clbAssignments.SelectedItem as Assignment;

            CreateNewAssignmentForm assignmentForm = new CreateNewAssignmentForm(current.ToDo);
            if (assignmentForm.ShowDialog() == DialogResult.OK)
            {
                Assignment modifiedAssignment = assignmentForm.GetAssignment();
                try
                {
                    using (ProjectsDbEntities entitties = new ProjectsDbEntities())
                    {
                        List<Assignment> assignments = entitties.Assignments.ToList();
                        foreach (Assignment a in assignments)
                        {
                            if (a.Id == current.Id)
                            {
                                a.ToDo = modifiedAssignment.ToDo;
                                entitties.SaveChanges();
                                refreshAssignments();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("clbAssignments_SelectedValueChanged\n\n" + ex.ToString());
                }
            } 
        }

        private void btnAddLoginInfo_Click(object sender, EventArgs e)
        {
            Project p = lbProjects.SelectedItem as Project;
            int projectId = p.Id;

            CreateNewLoginInfo createNewLoginInfo = new CreateNewLoginInfo();
            if (createNewLoginInfo.ShowDialog() == DialogResult.OK)
            {
                LoginInfo l = createNewLoginInfo.GetLoginInfo();
                l.ProjectId = projectId;

                try
                {
                    using (ProjectsDbEntities entitties = new ProjectsDbEntities())
                    {
                        entitties.LoginInfoes.Add(l);
                        entitties.SaveChanges();
                    }

                    this.refreshLoginInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("btnAddloginInfo_click\n\n" + ex.ToString());
                }
                
            }
        }

        private void cbLoginInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            LoginInfo current = cbLoginInfo.SelectedItem as LoginInfo;

            if (current == null)
            {
                MessageBox.Show("Can't delete null object");
                return;
            }
            else
            {
                using (ProjectsDbEntities context = new ProjectsDbEntities())
                {
                    try
                    {
                        var login = (from o in context.LoginInfoes where o.Id == current.Id select o).First();
                        context.LoginInfoes.Remove(login);
                        context.SaveChanges();
                        this.refreshLoginInfo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void btnEdiLoginInfo_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Not implemented");
            LoginInfo current = cbLoginInfo.SelectedItem as LoginInfo;

            CreateNewLoginInfo loginForm = new CreateNewLoginInfo(current.Url, current.Username, current.Password);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                LoginInfo modifiedInfo = loginForm.GetLoginInfo();
                using (ProjectsDbEntities context = new ProjectsDbEntities())
                {
                    try
                    {
                        var login = (from o in context.LoginInfoes where o.Id == current.Id select o).First();
                        login.Username = modifiedInfo.Username;
                        login.Url = modifiedInfo.Url;
                        login.Password = modifiedInfo.Password;
                        context.SaveChanges();
                        this.refreshLoginInfo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("btnEdiLoginInfo_Click" + "\n\n" + ex.ToString());
                    }
                }   
            }
        }

        private void btnEditCss_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Not implemented");
            CSSCode courrent = lbCssCodes.SelectedItem as CSSCode;

            CreateNewCss formCss = new CreateNewCss(courrent.Function, courrent.Code);
            if (formCss.ShowDialog() == DialogResult.OK)
            {
                CSSCode modified = formCss.GetCssCode();
                try
                {
                    using (ProjectsDbEntities context = new ProjectsDbEntities())
                    {
                        List<CSSCode> cssCodes = context.CSSCodes.ToList();
                        foreach (CSSCode c in cssCodes)
                        {
                            if (c.Id == courrent.Id)
                            {
                                c.Function = modified.Function;
                                c.Code = modified.Code;

                                context.SaveChanges();
                                this.refreshCssCodes();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("btnEditCss_click\n\n" + ex.ToString());
                }
            }
        }

        private void btnDeleteAssignment_Click(object sender, EventArgs e)
        {
            Assignment current = clbAssignments.SelectedItem as Assignment;
            
            if(current == null){
                MessageBox.Show("Can't delete null object!");
                return;
            }

            try
            {
                using (ProjectsDbEntities context = new ProjectsDbEntities())
                {
                    List<Assignment> assignments = context.Assignments.ToList();
                    foreach (Assignment a in assignments)
                    {
                        if (a.Id == current.Id)
                        {
                            context.Assignments.Remove(a);
                            context.SaveChanges();
                            refreshAssignments();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDeleteAssignment\n\n" + ex.ToString());
            }



        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            Project courrent = lbProjects.SelectedItem as Project;
            int courentProjectId = courrent.Id;

            try
            {
                using (ProjectsDbEntities context = new ProjectsDbEntities())
                {   
                    // first delete Assignments and LoginInfoes associated with project that will be deleted
                    // then delete the project itself
                    //
                    // CssCodes should remain
                    //
                    // Note:
                    // This method is not working properly!!!
                    // cssCode can not be associated with non existing (deleted) project
                    //
                    // Solution:
                    // Change the DataBase or don't delete the projects

                    List<Assignment> assignments = context.Assignments.ToList();
                    foreach (Assignment a in assignments)
                    {
                        if (a.ProjectId == courentProjectId)
                        {
                            context.Assignments.Remove(a);
                            context.SaveChanges();
                            refreshAssignments();
                        }
                    }

                    List<LoginInfo> loginInfoes = context.LoginInfoes.ToList();
                    foreach (LoginInfo l in loginInfoes)
                    {
                        if (l.ProjectId == courentProjectId)
                        {
                            context.LoginInfoes.Remove(l);
                            context.SaveChanges();
                            refreshLoginInfo();
                        }
                    }

                    List<Project> projects = context.Projects.ToList();
                    foreach (Project p in projects)
                    {
                        if (p.Id == courentProjectId)
                        {
                            context.Projects.Remove(p);
                            context.SaveChanges();
                            refreshFromDatabase();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDeleteProject_click\n\n" + ex.ToString());
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            Project courrent = lbProjects.SelectedItem as Project;

            CreateNewProject formProject = new CreateNewProject(courrent.Name, courrent.Client, courrent.DeadLine.Value);
            if (formProject.ShowDialog() == DialogResult.OK)
            {
                Project modified = formProject.GetProjet();

                try
                {
                    using (ProjectsDbEntities context = new ProjectsDbEntities())
                    {
                        List<Project> projects = context.Projects.ToList();
                        foreach (Project p in projects)
                        {
                            if (p.Id == courrent.Id)
                            {
                                p.Name = modified.Name;
                                p.Client = modified.Client;
                                p.StartDate = modified.StartDate;
                                p.DeadLine = modified.DeadLine;
                                p.FinishDate = modified.FinishDate;

                                context.SaveChanges();
                                refreshFromDatabase();
                                RefreshProjectDetail();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("btnEditProject_click\n\n" + ex.ToString());
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String query = tbSearch.Text;
            
            if(query.Trim().Length == 0){
                MessageBox.Show("Can't search for empty string!");
                return;
            }

            lbCssCodes.Items.Clear();
            try
            {
                using (ProjectsDbEntities context = new ProjectsDbEntities())
                {
                    List<CSSCode> cssCodes = context.CSSCodes.ToList();
                    foreach (CSSCode c in cssCodes)
                    {
                        if (c.Function.Contains(query))
                        {
                            lbCssCodes.Items.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSearch_click\n\n" + ex.ToString());
                //
            }   
        }
    }
}
