﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                this.Hide();
                AdminForm formAdmin = new AdminForm();
                formAdmin.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           Form1 form = new Form1();
            form.Show();
        }
    }
    
}
