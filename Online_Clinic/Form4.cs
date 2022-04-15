using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Online_Clinic
{
    public partial class Form4 : KryptonForm
    {
        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        SqlCommand cmd;

        bool password_macth = false;
        bool Email_available_check = false;
        bool Valid_email = false;
        bool gander_Checked = false;
        int age = 0;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            //Form5 a = new Form5();
            // a.Show();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM doctor WHERE email='" + kryptonTextBox2.Text + "'", con);
            DataTable mail = new DataTable();
            sda.Fill(mail);
            if (//comboBox1.Text != ""
                   kryptonTextBox1.Text != ""
                && kryptonTextBox2.Text != ""
                && kryptonTextBox3.Text != ""
                && kryptonTextBox4.Text != ""
                && kryptonTextBox5.Text != ""
                && kryptonTextBox6.Text != ""
                && kryptonTextBox7.Text != ""
                && kryptonTextBox8.Text != ""
                && password_macth == true
                && Valid_email == true
                && gander_Checked == true
                && Email_available_check == true
                && kryptonTextBox4.Text.Length > 7
                && kryptonComboBox2.Text != "Month"
                && kryptonTextBox7.Text != "YYYY"
                && kryptonTextBox7.Text.Length > 3
                && Convert.ToInt32(kryptonTextBox6.Text) > 32
                && kryptonTextBox8.Text.Length == 11)
            {
                if (mail.Rows[0][0].ToString() == "0")
                {
                    string doctorID = Guid.NewGuid().ToString("N");
                    string name = kryptonTextBox1.Text.ToString() + "  "+kryptonTextBox3.Text.ToString();
                    string email = kryptonTextBox2.Text;

                    con.Open();
                    cmd = new SqlCommand("insert into doctor ([doctorID],[name],specialization,certificate_name,email,certificate,password,[phone_secretary],verificationCode)values" +
                        "('" + doctorID + "','" + name + "','" + "null" + "','" + "null" + "','" + email + "','" + "null" + "','" + kryptonTextBox5.Text + "','" + kryptonTextBox8.Text + "','" + "unverified" + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //
                    var client = new SmtpClient()
                    {
                        Host = "smtp.zoho.com",
                        EnableSsl = true,
                        Port = 587,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("support@awd.somee.com", "Jasba@ya%dee#")
                    };
                    client.Send("support@awd.somee.com", email, "Welcome to Online Clinic", "HI " + name + "\nThank you for using AWD");
                    //

                    //


                    MessageBox.Show("great! ,now lets sighn in");
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                }
               
            }
            
            if (password_macth != true || kryptonTextBox4.Text != "")
            {
                label3.ForeColor = Color.Red;
            }

            if (kryptonTextBox6.Text == "" || kryptonTextBox6.Text == "DD" || kryptonTextBox7.Text == "" || kryptonComboBox2.Text == "Month" || kryptonTextBox7.Text == "YYYY" || kryptonTextBox7.Text.Length != 4 || Convert.ToInt32(kryptonTextBox6.Text) > 32)
                label5.ForeColor = Color.Red;
            if (age < 16)
                label5.ForeColor = Color.Red;

            if (radioButton1.Checked == false && radioButton2.Checked == false)
                label6.ForeColor = Color.Red;

            if (kryptonTextBox8.Text == "" || kryptonTextBox8.Text == "Enter your phone number.")
                label7.ForeColor = Color.Red;

            if (kryptonTextBox4.Text != kryptonTextBox5.Text && kryptonTextBox4.Text != "" && kryptonTextBox5.Text != "")
            {
                label3.ForeColor = Color.Red;
                label4.ForeColor = Color.Red;
            }
            else if (kryptonTextBox4.Text == kryptonTextBox5.Text && kryptonTextBox4.Text != "")
            {
                label12.Visible = true;
                label12.Text = "password macth";
                label12.ForeColor = Color.Green;

            }

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void kryptonTextBox4_TextChanged(object sender, EventArgs e)
        {
            int password_length = kryptonTextBox4.Text.Length;
            if (password_length < 8)
                label11.Visible = true;
            else
                label11.Visible = false;
        }

        private void kryptonTextBox8_Enter(object sender, EventArgs e)
        {
            kryptonTextBox8.AlwaysActive = true;
            label7.ForeColor = Color.Black;
            if (kryptonTextBox8.Text == "Enter your phone number.")
                kryptonTextBox8.Text = "";
        }

        private void kryptonTextBox4_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            if (kryptonTextBox4.Text == "Create a password.")
            {
                kryptonTextBox4.Text = "";
                kryptonTextBox4.AlwaysActive = true;
                kryptonTextBox4.UseSystemPasswordChar = true;
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "First name")
                kryptonTextBox1.Text = "";
            label2.ForeColor = Color.Black;
        }

        private void kryptonTextBox4_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
