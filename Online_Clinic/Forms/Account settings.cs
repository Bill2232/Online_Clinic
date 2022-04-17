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
using ComponentFactory.Krypton.Toolkit;

namespace Online_Clinic.Forms
{
    public partial class Account_settings : KryptonForm
    {
        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        SqlCommand command;
        public string email = Form1.email;
        public Account_settings()
        {
            InitializeComponent();
        }

        private void Account_settings_Load(object sender, EventArgs e)
        {
            con.Open();
            command = new SqlCommand("select * from doctor where email = '"+email+"'",con);
             
            SqlDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                label14.Text = reader.GetValue(0).ToString();
                label15.Text = reader.GetValue(1).ToString();
                label18.Text = reader.GetValue(8).ToString();
                label20.Text = reader.GetValue(7).ToString();
                label16.Text = reader.GetValue(3).ToString();
            }
           


        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormVerificationEdit a = new FormVerificationEdit();
            a.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormVerificationEdit a = new FormVerificationEdit();
            a.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormVerificationEdit a = new FormVerificationEdit();
            a.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormVerificationEdit a = new FormVerificationEdit();
            a.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormVerificationEdit a = new FormVerificationEdit();
            a.ShowDialog();
        }
    }
}
