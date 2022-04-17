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

namespace Online_Clinic.Forms
{
    public partial class Settings : Form
    {
        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        SqlCommand cmd;
        public Settings()
        {
            InitializeComponent();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Account_settings a = new Account_settings();
            a.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
            string email = Form1.email;
            con.Open();
            cmd = new SqlCommand("UPDATE doctor SET Dstate='offline' WHERE email='" + email + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
