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
    public partial class Patient_List : Form
    {
        public static string Pemail;
        public string email = Form1.email;
        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        SqlCommand cmd;

        public void update_data()
        {
            con.Open();

            SqlCommand command = new SqlCommand("SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and state != 'rejected'" + // count pathin
             "SELECT DISTINCT email , name, mobile_numbur  FROM(SELECT   ROW_NUMBER() OVER(ORDER BY patient.name ) AS num_row, patient.name, patient.email, patient.mobile_numbur   from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and state != 'rejected'  ) t where num_row =1" + //get info
             "SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY booking.orderno DESC) AS num_row, booking.date from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and patient.email ='" + label8.Text + "' and state = 'accepted') t  where num_row = 1" + // next booking
             "SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY booking.orderno DESC) AS num_row, booking.date from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and patient.email ='" + label8.Text + "' and state = 'done') t  where num_row = 1" + // last booking
             "SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY booking.orderno ASC) AS num_row, booking.date from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and patient.email ='" + label8.Text + "' and state = 'done') t  where num_row = 1" + // first booking
              //end of sql first panel
             "SELECT DISTINCT email , name, mobile_numbur  FROM(SELECT   ROW_NUMBER() OVER(ORDER BY patient.name ) AS num_row, patient.name, patient.email, patient.mobile_numbur   from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and state != 'rejected' ) t where num_row =2" + //get info
             "SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY booking.orderno DESC) AS num_row, booking.date from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and patient.email ='" + label18.Text + "' and state = 'accepted') t  where num_row = 1" + // next booking
             "SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY booking.orderno DESC) AS num_row, booking.date from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and patient.email ='" + label18.Text + "' and state = 'done') t  where num_row = 1" + // last booking
             "SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY booking.orderno ASC) AS num_row, booking.date from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and patient.email ='" + label18.Text + "' and state = 'done') t  where num_row = 1"  // first booking
              , con);
            SqlDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                label24.Text = reader.GetValue(0).ToString();
            }
            // first panel 
            reader.NextResult();
            if (reader.Read())
            {
                guna2ShadowPanel3.Visible = true;
                label7.Text = reader.GetValue(1).ToString();
                label8.Text = reader.GetValue(0).ToString();
                label9.Text = reader.GetValue(2).ToString();
            }
            else
            {
                guna2ShadowPanel3.Visible = false;
            }


            reader.NextResult();
            while (reader.Read())
            {
                label4.Text = reader.GetValue(1).ToString();
            }
            reader.NextResult();
            while (reader.Read())
            {
                label11.Text = reader.GetValue(1).ToString();
            }
            reader.NextResult();
            while (reader.Read())
            {
                label12.Text = reader.GetValue(1).ToString();
            }
            // end of first panel
            //panel 2
            reader.NextResult();
            if (reader.Read())
            {
                guna2ShadowPanel3.Visible = true;
                label17.Text = reader.GetValue(1).ToString();
                label18.Text = reader.GetValue(0).ToString();
                label16.Text = reader.GetValue(2).ToString();
            }
            else
            {
                guna2ShadowPanel4.Visible = false;
            }
            reader.NextResult();
            if (reader.Read())
            {
                label15.Text = reader.GetValue(1).ToString();
            }
            reader.NextResult();
            while (reader.Read())
            {
                label14.Text = reader.GetValue(1).ToString();
            }
            reader.NextResult();
            while (reader.Read())
            {
                label13.Text = reader.GetValue(1).ToString();
            }
            //end of panel2

            con.Close();

            //
        }

        private Form activeForm;

        private void OpenChildForm(Form childForm, object btnSender)
        {
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();   
        }
        public Patient_List()
        {
            InitializeComponent();
        }

        private void Patient_List_Load(object sender, EventArgs e)
        {
            panel2.Visible = true;
            update_data();
            panel2.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel3_CursorChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel3_Click(object sender, EventArgs e)
        {
            Pemail = label8.Text;
            OpenChildForm(new Forms.Patient_Details(), sender);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Pemail = label8.Text;
            OpenChildForm(new Forms.Patient_Details(), sender);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Pemail = label8.Text;
            OpenChildForm(new Forms.Patient_Details(), sender);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Pemail = label8.Text;
            OpenChildForm(new Forms.Patient_Details(), sender);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Pemail = label8.Text;
            OpenChildForm(new Forms.Patient_Details(), sender);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Patient_Details(), sender);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Patient_Details(), sender);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Patient_Details(), sender);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            update_data();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
