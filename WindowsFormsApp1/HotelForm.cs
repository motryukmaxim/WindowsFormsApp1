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
    public partial class HotelForm : Form
    {
        hotel[] array;
        public HotelForm()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void HotelForm_Load(object sender, EventArgs e)
        {

        }

        private void updateComboBox()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand commandSelect = new MySqlCommand("SELECT * FROM `hotel` WHERE 1", db.getConnection());
            adapter.SelectCommand = commandSelect;
            adapter.Fill(table);
            DataRow[] rows = table.Select();
            array = new hotel[table.Rows.Count];
            comboBox1.Items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                array[i] = new hotel(rows[i][1].ToString(), rows[i][2].ToString(), rows[i][3].ToString(), Convert.ToInt32(rows[i][4]));
                comboBox1.Items.Add(array[i].name);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {

                updateComboBox();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `hotel` (`name`, `country`, `address`, `pricePerDay` ) VALUES (@name,@country,@address,@pricePerDay)", db.connection);
                command.Parameters.AddWithValue("@name", textBox1.Text);
                command.Parameters.AddWithValue("@country", textBox2.Text);
                command.Parameters.AddWithValue("@address", textBox3.Text);
                command.Parameters.AddWithValue("@pricePerDay", Convert.ToInt32(textBox4.Text));
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                    MessageBox.Show("Дія виконана.");
                }
                db.closeConnection();
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка, перевірте всі поля");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox7.Text = array[comboBox1.SelectedIndex].country;
            textBox5.Text = array[comboBox1.SelectedIndex].get('c') ;
            textBox6.Text = array[comboBox1.SelectedIndex].get(1).ToString();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("UPDATE hotel SET country = @country,`address` = @address, pricePerDay = @pricePerDay WHERE name = @name", db.getConnection());
                command.Parameters.AddWithValue("@name", comboBox1.Text);
                command.Parameters.AddWithValue("@country", textBox7.Text);
                command.Parameters.AddWithValue("@address", textBox5.Text);
                command.Parameters.AddWithValue("@pricePerDay", textBox6.Text);

                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    comboBox1.Text = "";
                    textBox7.Text = null;
                    textBox5.Text = null;
                    textBox6.Text = null;
                    MessageBox.Show("Дія виконана.");
                }
                db.closeConnection();
                updateComboBox();
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка, перевірте всі поля");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `hotel` WHERE name = @name", db.getConnection());
            command.Parameters.AddWithValue("@name", Convert.ToInt32(comboBox1.Text));
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                comboBox1.Text = "";
                textBox7.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                MessageBox.Show("Дія виконана.");
            }
            db.closeConnection();
            updateComboBox();
        }
    }
}
