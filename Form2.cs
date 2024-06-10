using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=AKASHPC;Initial Catalog=TDK;Integrated Security=True";
            string query = "INSERT INTO Employee_Details (Name, PhoneNo, Email, Address) VALUES (@Name, @PhoneNumber, @Email, @Address)";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", textBox5.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", textBox6.Text);
                    command.Parameters.AddWithValue("@Email", textBox7.Text);
                    command.Parameters.AddWithValue("@Address", textBox8.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data saved successfully!");
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
