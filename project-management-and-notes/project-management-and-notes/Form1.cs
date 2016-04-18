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
        private List<Project> projects { get; set; }
        private List<Note> notes { get; set; }

        public Form1()
        {
            InitializeComponent();
            Project p1 = new Project("First Project", "01.05.2013");
            Project p2 = new Project("Second Project", "01.06.2013");
            Project p3 = new Project("Third Project", "10.06.2013");

            lbProjects.Items.Add(p1);
            lbProjects.Items.Add(p2);
            lbProjects.Items.Add(p3);

            Note n1 = new Note("Note one", "");
            Note n2 = new Note("Note two", "");
            Note n3 = new Note("Note three", "");

            lbNotes.Items.Add(n1);
            lbNotes.Items.Add(n2);
            lbNotes.Items.Add(n3);
        }

        private void lbNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Note selected = lbNotes.SelectedItem as Note;
            rtbNoteDetails.Clear();
            rtbNoteDetails.Text = selected.GetContent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectTab(1);
        }
    }
}
