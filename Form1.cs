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
            var myForm = new Form3();
            myForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var myForm = new Form4();
            myForm.Show();
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
    }
}
