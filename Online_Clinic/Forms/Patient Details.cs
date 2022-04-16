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
    public partial class Patient_Details : Form
    {
        //private Form activeForm;


        private void OpenChildForm(Form childForm, object btnSender)
        {
            //if (activeForm == childForm)
        //    {
           //     activeForm.Close();
           // } 
          //  activeForm = childForm;
          //  childForm.TopLevel = false;
          //  childForm.FormBorderStyle = FormBorderStyle.None;
          //  childForm.Dock = DockStyle.Fill;
          //  this.panel5.Controls.Add(childForm);
            //this.panel5.Tag = childForm;
          //  childForm.BringToFront();
          //  childForm.Show();
        }

        string Pemail = Patient_List.Pemail;
        string email = Form1.email;
        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        SqlCommand cmd;
        public Patient_Details()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Patient_Details_Load(object sender, EventArgs e)
        {
            label8.Text = Patient_List.Pemail;
            con.Open();
            SqlCommand command = new SqlCommand("SELECT  name,gender ,birthday,mobile_numbur (*) from Patient  where email = '" + label8.Text + "'" +
                "SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY booking.orderno ASC) AS num_row, booking.date from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and patient.email = '" + label8.Text + "' and state = 'done') t  where num_row = 1"
                , con);
            SqlDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                label7.Text = reader.GetString(0);
                label9.Text = reader.GetString(1);
                label10.Text = reader.GetString(2);
                label11.Text = reader.GetString(3);
            }
            reader.NextResult();
            while (reader.Read())
                label8.Text = reader.GetString(1);
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
           
            //OpenChildForm(new Forms.coming_treats(), sender);
            
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
           
            //OpenChildForm(new Forms.last_treats(), sender);
            
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            
             
            
        }
    }
}
