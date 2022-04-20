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
      
        string gander;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM doctor WHERE email='" + kryptonTextBox2.Text + "'", con);
            DataTable mail = new DataTable();
            sda.Fill(mail);
            if (//comboBox1.Text != ""
                   kryptonTextBox1.Text != ""
                && kryptonTextBox2.Text != ""
                && kryptonTextBox3.Text != ""
                && kryptonTextBox4.Text != ""
                && kryptonTextBox5.Text != ""
                && kryptonTextBox8.Text != ""
                && password_macth == true
                && Valid_email == true
                && gander_Checked == true
                && Email_available_check == true
                && kryptonTextBox4.Text.Length > 7
                && kryptonComboBox2.Text != "specialization"
                && kryptonTextBox8.Text.Length == 10)
            {
                if (mail.Rows[0][0].ToString() == "0")
                {
                    string doctorID = Guid.NewGuid().ToString("N");
                    string name = kryptonTextBox1.Text.ToString() + "  " + kryptonTextBox3.Text.ToString();
                    string email = kryptonTextBox2.Text;

                    con.Open();
                    cmd = new SqlCommand("insert into doctor ([doctorID],[name],specialization,certificate_name,email,certificate,password,[phone_secretary],verificationCode)values" +
                        "('" + doctorID + "','" + name + "','" + Convert.ToString(kryptonComboBox2.SelectedItem) + "','" + "null" + "','" + email + "','" + "null" + "','" + kryptonTextBox5.Text + "','" + kryptonTextBox8.Text + "','" + "unverified" + "')", con);
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
                    client.Send("support@awd.somee.com", email, "Welcome to Online Clinic", "HI " + name + "\nThank you for using Online Clinic");

                    Form5 f = new Form5();
                    f.Show();
                    this.Hide();
                }

            }
            else
            {
                if (password_macth != true || kryptonTextBox4.Text != "")
                {
                    label3.ForeColor = Color.Red;
                }

                if ( kryptonComboBox2.Text == "specialization")
                    label5.ForeColor = Color.Red;
               

                if (gander_Checked == false)
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
                if (kryptonTextBox2.Text == "" || kryptonTextBox2.Text == "Enter your email.")
                    label1.ForeColor = Color.Red;
                if (kryptonTextBox1.Text == "" || kryptonTextBox3.Text == "" || kryptonTextBox1.Text == "First name" || kryptonTextBox1.Text == "Last name")
                    label2.ForeColor = Color.Red;
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
       private void  radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
            gander = "female";
            gander_Checked = true;
        }
        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
            gander = "male";
            gander_Checked = true;
        }
        private void kryptonTextBox5_TextChanged(object sender, EventArgs e)
        {

            if (kryptonTextBox4.Text == kryptonTextBox5.Text && kryptonTextBox4.Text != "")
            {
                password_macth = true;
            }

            else
            {
                password_macth = false;
            }
        }
        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            //check avelabeil in Patient table
            SqlDataAdapter ska = new SqlDataAdapter("SELECT COUNT(*) FROM patient WHERE email='" + kryptonTextBox2.Text + "'", con);
            DataTable mail = new DataTable();
            ska.Fill(mail);
            //check avelabeil in doctor table
            SqlDataAdapter dska = new SqlDataAdapter("SELECT COUNT(*) FROM doctor WHERE email='" + kryptonTextBox2.Text + "'", con);
            DataTable doctor_mail = new DataTable();
            dska.Fill(doctor_mail);
            if (kryptonTextBox2.Text.Contains('@') && kryptonTextBox2.Text.Contains("."))
            {


                if (mail.Rows[0][0].ToString() == "0" && doctor_mail.Rows[0][0].ToString() == "0")
                {
                    label10.Visible = true;
                    label10.Text = "email available";
                    label10.ForeColor = Color.Green;
                    Email_available_check = true;
                }

                else
                {
                    label10.Text = "This email is already used!";
                    label10.ForeColor = Color.Red;
                    label10.Visible = true;
                    Email_available_check = false;
                }
                Valid_email = true;
            }
            else
            {

                if (mail.Rows[0][0].ToString() == "0" && doctor_mail.Rows[0][0].ToString() == "0")
                {
                    label10.Visible = true;

                    Email_available_check = true;
                }
                else
                {
                    label10.Visible = true;

                    Email_available_check = false;
                }
                Valid_email = false;
                label10.Text = "unvalid email";
            }
        }
        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            if (kryptonTextBox2.Text == "Enter your email.")
            {
                kryptonTextBox2.AlwaysActive = true;
                kryptonTextBox2.Text = "";
            }



        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
            if (kryptonTextBox3.Text == "Last name")
            {
                kryptonTextBox3.AlwaysActive = true;
                kryptonTextBox3.Text = "";
            }
        }

        private void kryptonTextBox5_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;

            if (kryptonTextBox5.Text == "Enter the password againe.")
            {
                kryptonTextBox5.AlwaysActive = true;
                kryptonTextBox5.Text = "";

                kryptonTextBox5.UseSystemPasswordChar = true;
                pictureBox2.Visible = true;
            }
            if (pictureBox3.Visible == false && pictureBox2.Visible == false)
                pictureBox2.Visible = true;
        }

       

       

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            kryptonTextBox4.UseSystemPasswordChar = true;
            kryptonTextBox5.UseSystemPasswordChar = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            kryptonTextBox4.UseSystemPasswordChar = false;
            kryptonTextBox5.UseSystemPasswordChar = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void kryptonTextBox5_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox5.Text == "" && kryptonTextBox4.Text == "")
            {
                pictureBox3.Visible = false;
                pictureBox2.Visible = false;
            }
            if (kryptonTextBox4.Text == kryptonTextBox5.Text && kryptonTextBox4.Text != "" && kryptonTextBox5.Text != "")
            {
                password_macth = true;
                label12.Visible = true;
                label12.ForeColor = Color.Green;
                label12.Text = "password match";

            }
            else
            {
                password_macth = false;
                label12.Visible = true;
                label12.ForeColor = Color.Red;
                label12.Text = "Password does not match!";
            }
        }

        private void kryptonTextBox4_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox5.Text == "" && kryptonTextBox4.Text == "")
            {
                pictureBox3.Visible = false;
                pictureBox2.Visible = false;
            }
            if (kryptonTextBox4.Text == kryptonTextBox5.Text && kryptonTextBox5.Text != "")
            {
                password_macth = true;
                label12.Visible = true;
                label12.Text = "password match";
                label12.ForeColor = Color.Green;
            }
            else if (kryptonTextBox4.Text == kryptonTextBox5.Text && kryptonTextBox5.Text == "")
            {
                password_macth = false;
                label12.Visible = false;
            }
        }

        private void kryptonTextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kryptonTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kryptonTextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kryptonComboBox2_Enter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            kryptonTextBox4.UseSystemPasswordChar = true;
            kryptonTextBox5.UseSystemPasswordChar = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
    
}
