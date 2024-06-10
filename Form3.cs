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
        string phoneNumber;

        public Form3(string phoneNumber)
        {
            InitializeComponent();
            this.phoneNumber = phoneNumber;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Employee_Details SET Name = @Name, PhoneNo = @PhoneNo, Email = @Email, Address = @Address WHERE PhoneNo = @SearchPhoneNumber";

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"))
            {
                MessageBox.Show("Invalid Email!");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, @"^[0-9]{10}$"))
            {
                MessageBox.Show("Invalid Phone Number! It should be 10 digits.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", textBox5.Text);
                    command.Parameters.AddWithValue("@PhoneNo", textBox6.Text);
                    command.Parameters.AddWithValue("@Email", textBox7.Text);
                    command.Parameters.AddWithValue("@Address", textBox8.Text);
                    command.Parameters.AddWithValue("@SearchPhoneNumber", this.phoneNumber);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data updated successfully!");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string query = "SELECT Name, PhoneNo, Email, Address FROM Employee_Details WHERE PhoneNo = @PhoneNumber";

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"))
            {
                MessageBox.Show("Invalid Email!");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, @"^[0-9]{10}$"))
            {
                MessageBox.Show("Invalid Phone Number! It should be 10 digits.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PhoneNumber", this.phoneNumber);

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
    }
}
