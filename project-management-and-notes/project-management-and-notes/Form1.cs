using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            draw_elements();
        }

        private void draw_elements()
        {
            int width = this.Width;
            int height = this.Height -65;
            // MessageBox.Show("width: " + width + " height: " + height);

            tabControl1.Width = width;
            tabControl1.Height = height;

            tabPage1.Width = width;
            tabPage2.Width = width;

            //gbProjects.Width = width / 3 -40;
            //lbProjects.Width = gbProjects.Width -20;
            gbProjects.Height = height - 85;
            lbProjects.Height = gbProjects.Height - 110;

            btnAddProject.Location = new Point(btnAddProject.Location.X, gbProjects.Location.Y + lbProjects.Height - 25);
            btnEditProject.Location = new Point(btnAddProject.Location.X, btnAddProject.Location.Y + 25);
            btnDeleteProject.Location = new Point(btnAddProject.Location.X, btnEditProject.Location.Y + 25);

            //gbDetails.Location = new Point((width/3) -20, 50);
            gbDetails.Height = gbProjects.Height;
            gbAssignments.Height = gbProjects.Height - 20;
            clbAssignments.Height = gbAssignments.Height - 100;

            btnAddAssignment.Location = new Point(btnAddAssignment.Location.X, btnAddProject.Location.Y -15);
            btnEditAssignment.Location = new Point(btnEditAssignment.Location.X, btnAddAssignment.Location.Y + 25);
            btnDeleteAssignment.Location = new Point(btnDeleteAssignment.Location.X, btnEditAssignment.Location.Y + 25);

            gbCssCides.Height = height -100;
            lbCssCodes.Height = gbCssCides.Height - 50;
            
            btnAddCssCode.Location = new Point(6, gbCssCides.Location.Y + lbCssCodes.Height -35);

            gbNotesDetails.Width = width - lbCssCodes.Width - 60;
            gbNotesDetails.Height = gbCssCides.Height;

            rtbCssCodeDetails.Width = gbNotesDetails.Width - 10;
            rtbCssCodeDetails.Height = lbCssCodes.Height;

            btnEditCss.Location = new Point(6, btnAddCssCode.Location.Y);
            btnEditCss.Width = rtbCssCodeDetails.Width;

        }

        private void importFromBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Importing from backup is not working.
            // when object is added from backup file it has new id
            // this couse for example:
            // when adding assignment to project that had id of 5
            // the same project now has new random id
            // so we can not link them together

            MessageBox.Show("Not working properly");

            //clearDatabase();
            //refreshFromDatabase();

            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //importProjectsFromBackup(path);
            //importAssignmentsFromBackup(path);
            //importCssCodesFromBackup(path);
            //importLoginInfoFromBackup(path);
        }

        private void clearDatabase()
        {
            try
            {
                using (ProjectsDbEntities entities = new ProjectsDbEntities())
                {
                    List<CSSCode> cssCodes = entities.CSSCodes.ToList();
                    List<Assignment> assignments = entities.Assignments.ToList();
                    List<LoginInfo> loginInfoes = entities.LoginInfoes.ToList();
                    List<Project> projects = entities.Projects.ToList();

                    foreach (CSSCode c in cssCodes)
                    {
                        entities.CSSCodes.Remove(c);
                    }

                    foreach (Assignment a in assignments)
                    {
                        entities.Assignments.Remove(a);
                    }

                    foreach (LoginInfo l in loginInfoes)
                    {
                        entities.LoginInfoes.Remove(l);
                    }

                    foreach (Project p in projects)
                    {
                        entities.Projects.Remove(p);
                    }

                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("clearDatabase\n\n" + ex.ToString());
            }
        }

        private void importLoginInfoFromBackup(string path)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(path + @"\loginInfo.txt");
                foreach (string line in lines)
                {
                    LoginInfo l = new LoginInfo();

                    string[] parts = line.Split(' ');

                    l.Id = Int32.Parse(parts[0]);
                    l.ProjectId = Int32.Parse(parts[1]);
                    l.Url = parts[2];
                    l.Username = parts[3];
                    l.Password = parts[4];

                    using (ProjectsDbEntities entities = new ProjectsDbEntities())
                    {
                        entities.LoginInfoes.Add(l);
                        entities.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("importLoginInfoFromBackup\n\n" + ex.ToString());
            }
        }

        private void importCssCodesFromBackup(string path)
        {
            try
            {
                String input = System.IO.File.ReadAllText(path + @"/cssCodes.txt");
                
                String[] parts = Regex.Split(input, "EOL\n");
                foreach (string part in parts)
                {
                    if (part.Length > 0)
                    {
                        string[] actualData = Regex.Split(part, "____");
                        CSSCode css = new CSSCode();
                        
                        css.Id = Int32.Parse(actualData[0]);
                        css.ProjectId = Int32.Parse(actualData[1]);
                        css.Function = actualData[2];
                        css.Code = actualData[3];

                        using (ProjectsDbEntities entities = new ProjectsDbEntities())
                        {
                            entities.CSSCodes.Add(css);
                            entities.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("importCssCodesFromBackup\n\n" + ex.ToString());
            }
        }

        private void importAssignmentsFromBackup(string path)
        {
            try
            {
                String[] lines = System.IO.File.ReadAllLines(path + @"/assignments.txt");
                foreach (string line in lines)
                {
                    Assignment assignment = new Assignment();

                    string[] parts = line.Split(' ');

                    assignment.Id = Int32.Parse(parts[0]);
                    assignment.ProjectId = Int32.Parse(parts[1]);
                    assignment.ToDo = parts[2];
                    
                    if (parts[3] == "False")
                    {
                        assignment.Done = false;
                    }
                    else
                    {
                        assignment.Done = true;
                    }

                    using (ProjectsDbEntities entities = new ProjectsDbEntities())
                    {
                        entities.Assignments.Add(assignment);
                        entities.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("importAssignmentsFromBackup\n\n" + ex.ToString());
            }
        }

        private void importProjectsFromBackup(string path)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(path + @"\projects.txt");

                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');

                    Project p = new Project();

                    p.Id = Int32.Parse(parts[0]);
                    p.Name = parts[1];
                    p.Client = parts[2];
                    p.StartDate = DateTime.Parse(parts[3]);
                    if (parts[4].Length > 1)
                    {
                        p.FinishDate = DateTime.Parse(parts[4]);
                    }
                    else
                    {
                        p.FinishDate = null;
                    }
                    p.DeadLine = DateTime.Parse(parts[5]);

                    using (ProjectsDbEntities entities = new ProjectsDbEntities())
                    {
                        entities.Projects.Add(p);
                        entities.SaveChanges();
                    }
                }

                refreshFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("importProjectsFromBackup\n\n" + ex.ToString());
            }
        }

        private void tsmExportBackup_Click(object sender, EventArgs e)
        {
            // make .bak of .mdf file instead of making backup as plain text
            MessageBox.Show("Not working properly");
            
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //exportProjectsAsBackup(path);
            //exportAssignmentsAsBackup(path);
            //exportCssCodeAsBackup(path);
            //exportLoginInfoAsBackup(path);
        }

        private void exportProjectsAsBackup(string path)
        {
            try
            {
                List<Project> projects = new List<Project>();
                string result = "";

                using (ProjectsDbEntities entitties = new ProjectsDbEntities())
                {
                    projects = entitties.Projects.ToList();
                }

                foreach (Project p in projects)
                {
                    result += p.toBackupFormat();
                }

                System.IO.File.WriteAllText(path + @"\projects.txt", result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("exportProjectsAsBackup\n\n" + ex.Message.ToString());
            }
        }

        private void exportAssignmentsAsBackup(string path)
        {
            try
            {
                List<Assignment> assignments = new List<Assignment>();
                string result = "";

                using (ProjectsDbEntities entities = new ProjectsDbEntities())
                {
                    assignments = entities.Assignments.ToList();
                }

                foreach (Assignment a in assignments)
                {
                    result += a.toBackUpFormat();
                }

                System.IO.File.WriteAllText(path + @"\assignments.txt", result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ExportAssignmentsAsBackup\n\n" + ex.ToString());
            }
        }

        private void exportCssCodeAsBackup(string path)
        {
            try
            {
                List<CSSCode> cssCodes = new List<CSSCode>();
                string result = "";

                using(ProjectsDbEntities entities = new ProjectsDbEntities())
                {
                    cssCodes = entities.CSSCodes.ToList();   
                }

                foreach (CSSCode css in cssCodes)
                {
                    result += css.toBackUpFormat();
                }

                System.IO.File.WriteAllText(path + @"\cssCodes.txt", result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("exportCssCodeAsBackup\n\n" + ex.ToString());
            }
        }

        private void exportLoginInfoAsBackup(string path)
        {
            try
            {
                List<LoginInfo> loginInfoes = new List<LoginInfo>();
                string result = "";

                using (ProjectsDbEntities entities = new ProjectsDbEntities())
                {
                    loginInfoes = entities.LoginInfoes.ToList();
                }

                foreach (LoginInfo l in loginInfoes)
                {
                    result += l.toBackUpFormat();
                }

                System.IO.File.WriteAllText(path + @"\loginInfo.txt", result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("exportLoginInfoAsBackup\n\n" + ex.ToString());
            }
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
