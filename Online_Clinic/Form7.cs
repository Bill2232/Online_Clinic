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

namespace Online_Clinic
{
    public partial class Form7 : KryptonForm
    {
        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        SqlCommand cmd;
        public string email = Form1.email;
        private Form activeForm;
        bool isAway = false;

        
            private void OpenChildForm(Form childForm, object btnSender)
        {

            if (activeForm == childForm)
            {
                activeForm.Close();
            }
            
           // else if(activeForm = childForm) 
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(childForm);
            this.panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label5.Text = childForm.Text;
            pictureBox3.Image = childForm.BackgroundImage;
            

        }

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Overview(), sender);
            pictureBox3.Image = pictureBox8.Image;
            label5.Visible = true;
            label4.Text = Forms.Overview.name;
            label3.Text = Forms.Overview.specialization;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (activeForm.Text != "Overview")
            {
                OpenChildForm(new Forms.Overview(), sender);
                pictureBox3.Image = pictureBox8.Image;
                label5.Visible = true;
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (activeForm.Text != "Calendar")
            {
                OpenChildForm(new Forms.Calendar(), sender);
                pictureBox3.Image = pictureBox7.Image;
            }
        }

        private void buttonPatientList_Click(object sender, EventArgs e)
        {
            if (activeForm.Text != "Patient List")
            {
                OpenChildForm(new Forms.Patient_List(), sender);
                pictureBox3.Image = pictureBox6.Image;
            }
        }

        private void buttonMessages_Click(object sender, EventArgs e)
        {
            if (activeForm.Text != "Mwssages")
            {
                OpenChildForm(new Forms.Messages(), sender);
                pictureBox3.Image = pictureBox4.Image;
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (activeForm.Text != "Settings")
            {
                OpenChildForm(new Forms.Settings(), sender);
                pictureBox3.Image = pictureBox5.Image;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            con.Open();
            cmd = new SqlCommand("UPDATE doctor SET Dstate='offline' WHERE email='" + email + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (isAway)
            {
                pictureBox17.Visible = true;
                pictureBox16.Visible = false;
                con.Open();
                cmd = new SqlCommand("UPDATE doctor SET Dstate='away' WHERE email='" + email + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void Form7_Activated(object sender, EventArgs e)
        {
            isAway = false;
            pictureBox17.Visible = false;
            pictureBox16.Visible = true;
        }

        private void Form7_Deactivate(object sender, EventArgs e)
        {
            isAway = true;

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            //con.Open();
            //cmd = new SqlCommand("UPDATE booking SET state='accepted' WHERE orderno='" + label29.Text + "'", con);
            //cmd.ExecuteNonQuery();
            //con.Close();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            if (activeForm.Name == "Overview")
            OpenChildForm(new Forms.FormNotefications(), sender);
            else
                OpenChildForm(new Forms.Overview(), sender);

        }
    }
}
