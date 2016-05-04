﻿using System;
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
    public partial class CreateNewCss : Form
    {
        private CssCode cssCode { get; set; }

        public CreateNewCss()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cssCode = new CssCode();
            cssCode.SetCode(rbCode.Text);
            cssCode.SetDescription(tbFunction.Text);

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public CssCode GetCssCode()
        {
            return this.cssCode;
        }

    }
}