using System;
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
    public partial class AdminForm : Form
    {
        HotelForm hotelForm = new HotelForm();
        TourForm tourForm = new TourForm();
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelForm.Hide();
            tourForm.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            hotelForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tourForm.Show();
        }
    }
}
