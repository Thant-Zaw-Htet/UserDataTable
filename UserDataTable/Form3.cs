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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {


            try
            {
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirmPassword = txtConfirmPassword.Text.Trim();

                if (password != confirmPassword)
                {
                    MessageBox.Show("Your Password and Confirm Password doesn't match!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Please fill add fields", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                else
                {
                    SqlConnection conn = new SqlConnection(GetConnectionString.connectionString);
                    conn.Open();
                    string query = @"INSERT INTO UserRegistration (Name,Email,Password) VALUES (@Name,@Email,@Password)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    int result = cmd.ExecuteNonQuery();

                    conn.Close();
                    if (result > 0)
                    {
                        MessageBox.Show("Register Successful!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        Form1 form1 = new Form1();
                        form1.Show();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
