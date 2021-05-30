using MySql.Data.MySqlClient;
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
    public partial class UserForm : Form
    {
        tour[] array;
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand commandSelect = new MySqlCommand("SELECT * FROM `tour` WHERE 1", db.getConnection());
            adapter.SelectCommand = commandSelect;
            adapter.Fill(table);
            DataRow[] rows = table.Select();

            DataTable tableHotel = new DataTable();
            commandSelect = new MySqlCommand("SELECT * FROM `hotel` WHERE 1", db.getConnection());
            adapter.SelectCommand = commandSelect;
            adapter.Fill(tableHotel);
            DataRow[] rowsHotel = tableHotel.Select();
            array = new tour[table.Rows.Count];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                int tmp = 0;
                for (int j = 0; j < tableHotel.Rows.Count; j++)
                {
                    if (Convert.ToInt32(rowsHotel[j][0]) == Convert.ToInt32(rows[i][4]))
                    {
                        tmp = j;
                    }

                }

                array[i] = new tour(rowsHotel[tmp][1].ToString(), rowsHotel[tmp][2].ToString(), rowsHotel[tmp][3].ToString(), Convert.ToInt32(rowsHotel[tmp][4]), rows[i][1].ToString(), (DateTime)rows[i][2], rows[i][3].ToString(), Convert.ToInt32(rows[i][0]));
                comboBox4.Items.Add(array[i].name + "    " + array[i].startTour.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("County: " + array[comboBox4.SelectedIndex].name);
            listBox1.Items.Add("Hotel name: " + array[comboBox4.SelectedIndex].country);
            listBox1.Items.Add("Hotel address: " + array[comboBox4.SelectedIndex].address);
            listBox1.Items.Add("pricePerDay: " + array[comboBox4.SelectedIndex].pricePerDay);
            listBox1.Items.Add("Transport type: " + array[comboBox4.SelectedIndex].transportType);
            listBox1.Items.Add("Date: " + array[comboBox4.SelectedIndex].startTour);
            listBox1.Items.Add("Duration: " + array[comboBox4.SelectedIndex].duration);
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox4.Text = "";
            listBox1.Items.Clear();
            MessageBox.Show("Done");
        }
    }
}
