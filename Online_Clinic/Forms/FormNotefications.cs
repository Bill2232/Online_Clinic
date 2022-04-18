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
    public partial class FormNotefications : Form
    {

        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        SqlCommand cmd;
        public string email = Form1.email;

        public void update_data()
        {
            con.Open();


            SqlCommand command = new SqlCommand("SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY booking.time) AS num_row, patient.name, patient.mobile_numbur, booking.time, booking.title, booking.orderno ,booking.date from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and state = 'in progress') t where num_row = 1 "
              , con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                guna2ShadowPanel4.Visible = true;
             
                label14.Text = reader.GetValue(1).ToString();
                label1.Text = reader.GetValue(5).ToString();
                label12.Text = reader.GetValue(2).ToString();
                label26.Text = reader.GetValue(6).ToString();
                label13.Text = reader.GetValue(3).ToString();
               // MessageBox.Show(label7.Text);
            }
            else
            {
                guna2ShadowPanel4.Visible = false;
            }

            con.Close();

        }
        public FormNotefications()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormNotefications_Load(object sender, EventArgs e)
        {
            update_data();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            update_data();
           
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
             con.Open();
             cmd = new SqlCommand("UPDATE booking SET state='accepted' WHERE orderno='" + label1.Text + "'", con);
             cmd.ExecuteNonQuery();
             con.Close();
        }
    }
}
