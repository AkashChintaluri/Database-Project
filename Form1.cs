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
    public partial class Form1 : Form
    {
        string connString = "Data Source=AKASHPC;Initial Catalog=TDK;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new Form2();
            myForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the primary key of the selected row (assuming it's in the first cell)
                string primaryKey = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                var myForm = new Form3(primaryKey);
                myForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the primary key of the selected row (assuming it's in the first cell)
                string primaryKey = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "DELETE FROM dbo.Employee_Details WHERE PhoneNo = @PrimaryKey";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PrimaryKey", primaryKey);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                button4_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "SELECT * FROM dbo.Employee_Details";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    dAdapter.Fill(ds);

                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
