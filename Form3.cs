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
    public partial class Form3 : Form
    {
        string connString = "Data Source=AKASHPC;Initial Catalog=TDK;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            string query = "SELECT Name, PhoneNo, Email, Address FROM Employee_Details WHERE PhoneNo = @PhoneNumber";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PhoneNumber", textBox1.Text);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox5.Text = reader["Name"].ToString();
                            textBox6.Text = reader["PhoneNo"].ToString();
                            textBox7.Text = reader["Email"].ToString();
                            textBox8.Text = reader["Address"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No record found with the provided phone number.");
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Employee_Details SET Name = @Name, PhoneNo = @PhoneNo, Email = @Email, Address = @Address WHERE PhoneNo = @SearchPhoneNumber";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", textBox5.Text);
                    command.Parameters.AddWithValue("@PhoneNo", textBox6.Text);
                    command.Parameters.AddWithValue("@Email", textBox7.Text);
                    command.Parameters.AddWithValue("@Address", textBox8.Text);
                    command.Parameters.AddWithValue("@SearchPhoneNumber", textBox1.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data updated successfully!");
        }


        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
