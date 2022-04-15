using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;


namespace Online_Clinic
{
    public partial class Form1 : KryptonForm
    {
        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        
        SqlCommand cmd;

        public static string email;
        public static int account_Type = 0;

        public Form1()
        {
           InitializeComponent();
        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            for (int v = 0; v <= 4; v++)
            {
                switch (v)
                {
                    case 0:
                        SqlDataAdapter sdafw = new SqlDataAdapter("SELECT COUNT(*) FROM doctor WHERE email='" + kryptonTextBox1.Text + "' AND password='" + kryptonTextBox2.Text + "'", con);
                        DataTable dseg = new DataTable();
                        sdafw.Fill(dseg);
                        if (dseg.Rows[0][0].ToString() == "1")
                        {
                            account_Type = 0;
                            SqlDataAdapter sdaq = new SqlDataAdapter("SELECT COUNT(*) FROM doctor WHERE email='" + kryptonTextBox1.Text + "' AND verificationCode='" + "unverified" + "'", con);
                            DataTable dtddd = new DataTable();
                            sdaq.Fill(dtddd);
                            if (dtddd.Rows[0][0].ToString() == "1")
                            {
                                MessageBox.Show("doctor but u have to vr ur email");
                                Form6 f = new Form6();
                                email = kryptonTextBox1.Text;
                                f.Show();
                                this.Hide();

                            }
                            else
                            {
                                Form7 fe = new Form7();
                                email = kryptonTextBox1.Text;
                                fe.Show();
                                this.Hide();
                                con.Open();
                                cmd = new SqlCommand("UPDATE doctor SET Dstate='actve' WHERE email='" + email + "'", con);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("doctor and the email is vertfied");
                            }
                        }
                        break;
                    case 1:
                        SqlDataAdapter sca = new SqlDataAdapter("SELECT COUNT(*) FROM patient WHERE email='" + kryptonTextBox1.Text + "' AND password='" + kryptonTextBox2.Text + "'", con);
                        DataTable dtsx = new DataTable();
                        sca.Fill(dtsx);
                        if (dtsx.Rows[0][0].ToString() == "1")
                        {
                            account_Type = 1;
                            SqlDataAdapter sdasz = new SqlDataAdapter("SELECT COUNT(*) FROM patient WHERE email='" + kryptonTextBox1.Text + "' AND verificationCode='" + "unverified" + "'", con);
                            DataTable dtddad = new DataTable();
                            sdasz.Fill(dtddad);
                            if (dtddad.Rows[0][0].ToString() == "1")
                            {
                                MessageBox.Show("ur patient but u have to vertfie ur email");
                                email = kryptonTextBox1.Text;
                                Form6 g = new Form6();
                                g.Show();
                                this.Hide();
                            }
                            else
                            {
                                email = kryptonTextBox1.Text;
                                MessageBox.Show("patient and the email is vertfied");
                            }
                        }
                        break;
                    default:
                        {
                         //   panel1.BackColor = Color.Red;
                         //   panel1.Visible = true;
                        //    panel2.BackColor = Color.Red;
                         //   panel2.Visible = true;
                            label3.Visible = true;
                         //   label3.ForeColor = Color.Red;
                        }
                        break;
                }
            }
            //  Form6 a = new Form6();
            //  a.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            kryptonTextBox2.UseSystemPasswordChar = false;
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Enter your email address")
                kryptonTextBox1.Text = "";
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Enter the password")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.UseSystemPasswordChar = true;
            }



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
