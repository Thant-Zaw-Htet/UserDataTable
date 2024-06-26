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

namespace UserDataTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all fields!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                SqlConnection conn = new SqlConnection(GetConnectionString.connectionString);
                conn.Open();
                string query = @"SELECT * FROM UserRegistration WHERE email = @email and password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email",email);
                cmd.Parameters.AddWithValue("@Password",password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);//

                DataTable dt = new DataTable();//
                da.Fill(dt);//
                conn.Close();
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Login failed! Username and password are wrong!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) 
            { 
            
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
