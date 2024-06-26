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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                string name = txtName.Text;
                string email = txtEmail.Text;
                string gender = radMale.Checked ? "Male" : radFemale.Checked ? "Female": string.Empty;         
                string address = txtAddress.Text;


                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(address)) 
                {
                    MessageBox.Show("Please fill add field!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlConnection conn = new SqlConnection(GetConnectionString.connectionString);
                conn.Open();
                string query = @"INSERT INTO profiles (StudentName,Email,Gender,Address) VALUES(@StudentName,@Email,@Gender,@Address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentName", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Address", address);
                int result = cmd.ExecuteNonQuery();
                conn.Close();   
                if(result > 0)
                {
                    MessageBox.Show("Create Student Successful!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
                MessageBox.Show("Create Student Fail!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);




            }
            catch (Exception ex) 
            { 
            
            }
          
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 form = new Form2();
            form.Show();
        }
    }
}
