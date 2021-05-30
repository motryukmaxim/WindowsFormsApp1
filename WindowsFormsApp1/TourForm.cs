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
    public partial class TourForm : Form
    {
        tour[] array;
        public TourForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `tour` (`transportType`, `startTour`, `duration`, `idhotel` ) VALUES (@transportType,@startTour,@duration,@idhotel)", db.connection);

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand commandSelect = new MySqlCommand("SELECT * FROM `hotel` WHERE 1", db.getConnection());
                adapter.SelectCommand = commandSelect;
                adapter.Fill(table);
                DataRow[] rows = table.Select();
                command.Parameters.AddWithValue("@transportType", comboBox2.Text);
                command.Parameters.AddWithValue("@startTour", dateTimePicker1.Value.Date);
                command.Parameters.AddWithValue("@duration", comboBox3.Text);
                command.Parameters.AddWithValue("@idhotel", rows[comboBox4.SelectedIndex][0]);
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    comboBox2.Text = null;
                    comboBox3.Text = null;
                    comboBox4.Text = null;
                    dateTimePicker1.Value = DateTime.Now;

                    MessageBox.Show("Дія виконана.");
                }
                db.closeConnection();
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка, перевірте всі поля");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TourForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand commandSelect = new MySqlCommand("SELECT * FROM `hotel` WHERE 1", db.getConnection());
            adapter.SelectCommand = commandSelect;
            adapter.Fill(table);
            DataRow[] rows = table.Select();
            comboBox1.Items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBox4.Items.Add(rows[i][0]);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                comboBoxUpdate();
            }
        }
        private void comboBoxUpdate()
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
            comboBox1.Items.Clear();
            comboBox7.Items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int tmp = 0;
                for (int j = 0; j < tableHotel.Rows.Count;j++)
                {
                    if(i == 0 )
                    {
                        comboBox1.Items.Add(rowsHotel[j][1]);
                    }
                    if(Convert.ToInt32(rowsHotel[j][0]) == Convert.ToInt32(rows[i][4]))
                    {
                        tmp = j;
                    }

                }
                
                array[i] = new tour(rowsHotel[tmp][1].ToString(), rowsHotel[tmp][2].ToString(), rowsHotel[tmp][3].ToString(), Convert.ToInt32(rowsHotel[tmp][4]), rows[i][1].ToString(), (DateTime)rows[i][2], rows[i][3].ToString(), Convert.ToInt32(rows[i][0]));
                comboBox7.Items.Add(array[i].name +"    "+ array[i].startTour.ToString());
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.Text = +array[comboBox7.SelectedIndex];
            comboBox6.Text = array[comboBox7.SelectedIndex].transportType;
            dateTimePicker2.Value = array[comboBox7.SelectedIndex].startTour;
            comboBox5.Text = array[comboBox7.SelectedIndex].duration;
            button3.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand commandSelect = new MySqlCommand("SELECT * FROM `hotel` WHERE 1", db.getConnection());
            adapter.SelectCommand = commandSelect;
            adapter.Fill(table);
            DataRow[] rows = table.Select();

            MySqlCommand command = new MySqlCommand("UPDATE tour SET transportType = @transportType,`startTour` = @startTour, duration = @duration, idhotel = @idhotel WHERE id = @id", db.getConnection());
            command.Parameters.AddWithValue("@transportType", comboBox6.Text);
            command.Parameters.AddWithValue("@startTour", dateTimePicker2.Value.Date);
            command.Parameters.AddWithValue("@duration", comboBox5.Text);
            command.Parameters.AddWithValue("@idhotel", rows[comboBox1.Items.IndexOf(comboBox1.Text)][0]);
            command.Parameters.AddWithValue("@id", array[comboBox7.SelectedIndex].id);

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                comboBox7.Text = "";
                comboBox1.Text = null;
                comboBox6.Text = null;
                comboBox5.Text = null;
                button2.Enabled = false;
                button3.Enabled = false;
                MessageBox.Show("Дія виконана.");
            }
            db.closeConnection();
            comboBoxUpdate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `tour` WHERE id = @id", db.getConnection());
            command.Parameters.AddWithValue("@id", array[comboBox7.SelectedIndex].id);
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                comboBox7.Text = "";
                comboBox1.Text = null;
                comboBox6.Text = null;
                comboBox5.Text = null;
                button2.Enabled = false;
                button3.Enabled = false;
                MessageBox.Show("Дія виконана.");
            }
            db.closeConnection();
            comboBoxUpdate();
        }
    }
}
