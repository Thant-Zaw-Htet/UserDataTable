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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(GetConnectionString.connectionString);
                conn.Open();
                string query = @"SELECT TOP (1000) [StudentID]
      ,[StudentName]
      ,[Email]
      ,[Gender]
      ,[Address]
      ,[isActive]
  FROM [students].[dbo].[profiles]";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();

               dgv1.DataSource = dt;    


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
