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

        private bool readyForCheckBoxChange;    // is used to determine if ListBox vith assignments should change selected property or not
                                                // 
                                                // the problem ocurs when AssignmentsListBox is cleared and populated with new content
                                                // a.k.a. refreshAsignment() is executed
                                                //
                                                // in this case selectedValueChanged() method is triged automatically but it shouldnt
                                                // this method should be trigered only when double clicked over listBox item instead
                                                //
                                                // this variable is used as flag to determine if we should consider
                                                // selectedValueChanged() as it is expected to happen atm or it not.
                                                //
                                                // as described above, it is expected all the time except when calling refreshAssignments()

        public Form1()
        {
            
            InitializeComponent();
            readyForCheckBoxChange = true;
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

            Project p = lbProjects.SelectedItem as Project;
            if (p != null)
            {
                enableProjectControls();
            }
            else
            {
                disableProjectControls();
            }
        }

        private void disableProjectControls()
        {
            btnEditProject.Enabled = false;
            btnAddLoginInfo.Enabled = false;
            btnAddAssignment.Enabled = false;
            btnAddCssCode.Enabled = false;
        }

        private void enableProjectControls()
        {
            btnEditProject.Enabled = true;
            btnAddLoginInfo.Enabled = true;
            btnAddAssignment.Enabled = true;
            btnAddCssCode.Enabled = true;
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
            readyForCheckBoxChange = false;     // description about this variable is writen next to it's declaration

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

            readyForCheckBoxChange = true;  // description about this variable is writen next to it's declaration
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
            Project project = lbProjects.SelectedItem as Project;
            if (project == null)
            {
                return;
            }

            Project projectFromDB = null;
            List<Assignment> assignments;

            try
            {
                using (ProjectsDbEntities entities = new ProjectsDbEntities())
                {
                    List<Project> projects = entities.Projects.ToList();

                    foreach (Project p in projects)
                    {
                        if (p.Id == project.Id)
                        {
                            projectFromDB = p;
                            projectFromDB.Status = getProjectStatus(projectFromDB.Id);
                            entities.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("refreshProjectDetail\n\n" + ex.ToString());
            }

            if (projectFromDB != null)
            {
                tbProjectName.Text = projectFromDB.Name;
                tbClientName.Text = projectFromDB.Client;

                tbStartDate.Text = projectFromDB.StartDate.ToString();
                tbDeadLine.Text = projectFromDB.DeadLine.ToString();

                if (projectFromDB.Status == true)
                {
                    tbStatus.Text = "Done";
                }
                else
                {
                    tbStatus.Text = "Unfinished";
                }
            }
            else
            {
                tbProjectName.Clear();
                tbClientName.Clear();

                tbStartDate.Clear();
                tbDeadLine.Clear();

                tbStatus.Clear();
            }           
        }

        private bool getProjectStatus(int ID)
        {
            List<Assignment> assignments = null;
            bool isUnfinished = false;

            try
            {
                using (ProjectsDbEntities entities = new ProjectsDbEntities())
                {
                    assignments = entities.Assignments.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getProjectStatus\n\n" + ex.ToString());
            }

            foreach (Assignment a in assignments)
            {
                if (a.ProjectId == ID)
                {
                    if (a.Done == false)
                    {
                        isUnfinished = true;
                    }
                }
            }

            if (isUnfinished)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void lbCssCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CSSCode c = lbCssCodes.SelectedItem as CSSCode;
            if (c != null)
            {
                rtbCssCodeDetails.Text = c.Code;
                btnEditCss.Enabled = true;
            }
            else
            {
                rtbCssCodeDetails.Clear();
                btnEditCss.Enabled = false;
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
            Assignment assignment = clbAssignments.SelectedItem as Assignment;

            if (assignment != null && readyForCheckBoxChange)
            {
                try
                {
                    using (ProjectsDbEntities entititties = new ProjectsDbEntities())
                    {
                        List<Assignment> assignments = entititties.Assignments.ToList();
                        foreach (Assignment a in assignments)
                        {
                            if (a.Id == assignment.Id)
                            {
                                a.Done = !a.Done;
                                entititties.SaveChanges();
                            }
                        }
                        refreshAssignments();
                        RefreshProjectDetail();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("clbAssignments_SelectedValueChanged\n\n" + e.ToString());
                }
            }
            else
            {
                // MessageBox.Show("clbAssignments_SelectedValueChanged\n\nNull value returnet by ComboListBox");
                return;
            }
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

                btnEdiLoginInfo.Enabled = true;
                btnAddLoginInfo.Enabled = true;
                btnDeleteLoginInfo.Enabled = true;
            }
            else
            {
                btnEdiLoginInfo.Enabled = false;
                btnDeleteLoginInfo.Enabled = false;
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
            String query = tbSearch.Text.ToLower().Trim();
            
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
                        if (c.Function.ToLower().Contains(query))
                        {
                            lbCssCodes.Items.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSearch_click\n\n" + ex.ToString());
            }   
        }

        private void clbAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Assignment asignment = clbAssignments.SelectedItem as Assignment;
            if (asignment != null)
            {
                btnEditAssignment.Enabled = true;
                btnDeleteAssignment.Enabled = true;
            }
            else
            {
                btnEditAssignment.Enabled = false;
                btnDeleteAssignment.Enabled = false;
            }
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSort.Text == "Deadline")
            {
                lbpRojectsSortByDeadline();
            }
            else if (cbSort.Text == "Status")
            {
                lbpRojectsSortByStatus();
                //MessageBox.Show("sorting by status");
            }
        }

        private void lbpRojectsSortByStatus()
        {
            List<Project> projects = new List<Project>();

            try
            {
                using (ProjectsDbEntities entities = new ProjectsDbEntities())
                {
                    projects = entities.Projects.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lbpRojectsSortByStatus\n\n" + ex.ToString());
            }

            projects.Sort(projectComparatorByStatus);

            lbProjects.SelectedIndex = -1;
            lbProjects.Items.Clear();
            foreach (Project p in projects)
            {
                lbProjects.Items.Add(p);
            }
        }

        private int projectComparatorByStatus(Project x, Project y)
        {
            bool xStatus = (bool)x.Status;
            bool yStatus = (bool)y.Status;

            if (xStatus && yStatus)
            {
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                if (xStatus)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        private void lbpRojectsSortByDeadline()
        {
            List<Project> projects = new List<Project>();

            foreach (Project p in lbProjects.Items)
            {
                projects.Add(p);
            }

            projects.Sort(projectComparatorByDate);

            lbProjects.SelectedIndex = -1;
            lbProjects.Items.Clear();

            foreach (Project p in projects)
            {
                lbProjects.Items.Add(p);
            }
        }

        private int projectComparatorByDate(Project x, Project y)
        {
            return (x.DeadLine.Value.Date.ToString().CompareTo(y.DeadLine.Value.Date.ToString()));
        }
    }
}
