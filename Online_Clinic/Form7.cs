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

namespace Online_Clinic
{
    public partial class Form7 : KryptonForm
    {
        private Form activeForm;

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Overview(), sender);
            pictureBox3.Image = pictureBox8.Image;
            label5.Visible = true;
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Calendar(), sender);
            pictureBox3.Image = pictureBox7.Image;
        }

        private void buttonPatientList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Patient_List(), sender);
            pictureBox3.Image = pictureBox6.Image;
        }

        private void buttonMessages_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Mwssages(), sender);
            pictureBox3.Image = pictureBox4.Image;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Settings(), sender);
            pictureBox3.Image = pictureBox5.Image;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
    }
}
