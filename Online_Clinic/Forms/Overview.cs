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
    public partial class Overview : Form
    {
        public string email = Form1.email;

        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        SqlCommand cmd;
        bool isAway = false;
        bool setPanel = false;
        public Overview()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            con.Open();
            
            DateTime now = DateTime.Now;
            DateTime dateTime1 = DateTime.Now;
            if (DateTime.Now.ToString("tt") == "AM")
                label1.Text = "Good Morning,";
            else
                label1.Text = "Good Evening,";
            var vi = now.AddDays(0);
            Today.Text = now.ToString("f");
            SqlCommand command = new SqlCommand("SELECT * FROM( SELECT  ROW_NUMBER() OVER(ORDER BY booking.time) AS num_row, patient.name, booking.title, booking.time from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.ToString("d") + "'and state='accepted') t where num_row = 1" +
             "SELECT * FROM( SELECT  ROW_NUMBER() OVER(ORDER BY booking.time) AS num_row, patient.name,  booking.title,booking.time from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.ToString("d") + "'and state='accepted') t where num_row = 2" +
             "SELECT * FROM( SELECT  ROW_NUMBER() OVER(ORDER BY booking.time) AS num_row, patient.name,  booking.title,booking.time from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.ToString("d") + "'and state='accepted') t where num_row = 3" +
             "SELECT * FROM( SELECT  ROW_NUMBER() OVER(ORDER BY booking.time) AS num_row, patient.name, patient.mobile_numbur,booking.time from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.ToString("d") + "'and state='accepted') t where num_row = 4" +
             "SELECT * FROM( SELECT  ROW_NUMBER() OVER(ORDER BY booking.time) AS num_row, patient.name, patient.mobile_numbur,booking.time from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.ToString("d") + "'and state='accepted') t where num_row = 5" +
             "SELECT * FROM( SELECT  ROW_NUMBER() OVER(ORDER BY booking.time) AS num_row, patient.name, patient.mobile_numbur,booking.time from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.ToString("d") + "'and state='accepted') t  where num_row = 6" +
             "SELECT  patient.name, patient.mobile_numbur from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and state='active'" +                                                                 //vi = now.AddDays(+2);
            "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.ToString("d") + "'and state='accepted'" +
            "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.AddDays(+1).ToString("d") + "'and state='accepted'" +
            "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.AddDays(+2).ToString("d") + "'and state='accepted'" +
            "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.AddDays(+3).ToString("d") + "'and state='accepted'" +
            "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.AddDays(+4).ToString("d") + "'and state='accepted'" +
            "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.AddDays(+5).ToString("d") + "'and state='accepted'" +
            "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date = '" + now.AddDays(+6).ToString("d") + "'and state='accepted'" +
            "SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY booking.time) AS num_row, patient.name, booking.title,booking.userID from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and state = 'Working') t where num_row = 1" + // to get the name and treatment title for cruunt treatment
            "SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY orderno) AS num_row, booking.date, booking.details from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and state = 'done' and booking.userID = '"+label12.Text+"') t where num_row = 1" + // to get the last treatment
            "SELECT * FROM(SELECT  ROW_NUMBER() OVER(ORDER BY booking.time) AS num_row, patient.name, patient.mobile_numbur, booking.time ,booking.title ,booking.orderno from booking JOIN patient ON booking.userID = patient.userID join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and state  = 'in progress') t where num_row = 1 "+ // leve it for now
            "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'and date like  '%" + now.ToString("MMMM")+"/"+now.ToString("yyyy") + "%'" +
            "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "'"+
            "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and state = 'in progress'"+
             "SELECT  COUNT (*) from booking join doctor on booking.doctorID = doctor.doctorID where doctor.email = '" + email + "' and state = 'accepted'"
            , con);
            SqlDataReader reader = command.ExecuteReader();



            if (reader.Read())
            {
                label26.Text = reader.GetValue(1).ToString();
                label25.Text = reader.GetValue(2).ToString();
                label28.Text = reader.GetValue(3).ToString();
                //label31.Text = "next one in " + label9.Text; not needed
                label45.Visible = false;
                panel6.Visible = true;
            }
            else
            {
                label45.Visible = true;
                panel4.Visible = false;
            }
            reader.NextResult();
            if (reader.Read())
            {
                label29.Text = reader.GetValue(1).ToString();
                label33.Text = reader.GetValue(2).ToString();
                label34.Text = reader.GetValue(3).ToString();
                panel5.Visible= true;
            }
            else
            {
                panel5.Visible = false;
            }
            reader.NextResult();
            if (reader.Read())
            {
                label35.Text = reader.GetValue(1).ToString();
                label36.Text = reader.GetValue(2).ToString();
                label37.Text = reader.GetValue(3).ToString();
               panel6.Visible = true;
            }
            else
            {
               panel6.Visible= false;
            }
            reader.NextResult();
            if (reader.Read())
            {
                //    COMMENTED cuz there is just 3 rows in today_tretiment
               // label18.Text = reader.GetValue(1).ToString();
               // label17.Text = reader.GetValue(2).ToString();
               // label16.Text = reader.GetValue(3).ToString();
              //  label18.Visible = true;
              //  label17.Visible = true;
             //   label16.Visible = true;
            }
            else
            {
                //label18.Visible = false;
               // label17.Visible = false;
               // label16.Visible = false;
            }
            reader.NextResult();
            if (reader.Read())
            {
             //   label24.Text = reader.GetValue(1).ToString();
            //    label23.Text = reader.GetValue(2).ToString();
           //     label22.Text = reader.GetValue(3).ToString();
           //     label24.Visible = true;
           //     label23.Visible = true;
           //     label22.Visible = true;
            }
            else
            {
           //     label24.Visible = false;
           //     label23.Visible = false;
            //    label22.Visible = false;
            }
            reader.NextResult();
            if (reader.Read())
            {
               // label27.Text = reader.GetValue(1).ToString();
              //  label26.Text = reader.GetValue(2).ToString();
              //  label25.Text = reader.GetValue(3).ToString();
              //  label27.Visible = true;
              //  label26.Visible = true;
              //  label25.Visible = true;
            }
            else
            {
               // label27.Visible = false;
              //  label26.Visible = false;
               //  label25.Visible = false;
            }
            reader.NextResult();
            if (reader.Read())
            {
             //   label11.Text = reader.GetValue(1).ToString();
            //    label12.Text = reader.GetValue(2).ToString();
             //   label11.Visible = true;
            //    label12.Visible = true;
            //    label22.Visible = true;
               // button2.Visible = true;
            }
            else
            {
               // button2.Visible = false;
             //   label11.Visible = false;
            //    label12.Visible = false;
            //    label22.Visible = false;
            }

            reader.NextResult();

            while (reader.Read())
            {
                Today.Text = now.ToString("ddd");
                guna2ShadowPanel2.Height =  (int)reader.GetValue(0);
                label38.Text = Convert.ToString(reader.GetValue(0));
            }
            reader.NextResult();
            while (reader.Read())
            {
                tomorrow.Text = now.AddDays(+1).ToString("ddd");
                guna2ShadowPanel3.Height =  (int)reader.GetValue(0);

            }
            reader.NextResult();
            while (reader.Read())
            {
                after.Text = now.AddDays(+2).ToString("ddd");
                guna2ShadowPanel5.Height = (int)reader.GetValue(0);

            }
            reader.NextResult();
            while (reader.Read())
            {
                    after1.Text = now.AddDays(+3).ToString("ddd");
                    guna2ShadowPanel7.Height = (int)reader.GetValue(0);

            }
            reader.NextResult();
            while (reader.Read())
            {
                   after2.Text = now.AddDays(+4).ToString("ddd");
                   guna2ShadowPanel10.Height =  (int)reader.GetValue(0);

            }
            reader.NextResult();
            while (reader.Read())
            {
                  after3.Text = now.AddDays(+5).ToString("ddd");
                  guna2ShadowPanel12.Height =  (int)reader.GetValue(0);

            }
            reader.NextResult();
            while (reader.Read())
            {
                  after4.Text = now.AddDays(+6).ToString("ddd");
                  guna2ShadowPanel14.Height = (int)reader.GetValue(0);

            }
            reader.NextResult();
            if (reader.Read())
            {
                label39.Text = reader.GetValue(1).ToString();
                label40.Text = reader.GetValue(2).ToString();
                label12.Text = reader.GetValue(3).ToString();
                label13.Visible = false;
                label39.Visible = true;
                label40.Visible = true;
            }
            else
            {
                label13.Visible = true;
                label39.Visible = false;
                label40.Visible = false;
            }

            reader.NextResult();
            if (reader.Read())
            {
                label10.Text = reader.GetValue(1).ToString();
                label11.Text = reader.GetValue(2).ToString();
                panel8.Visible = true;
            }
            else
            {
                panel8.Visible = false;
                
            }

            reader.NextResult();
            if (reader.Read())
            {
       
           //     label40.Text = reader.GetValue(1).ToString();
           //     label41.Text = reader.GetValue(4).ToString();
           //     label29.Text = reader.GetValue(5).ToString();
            }
            else
            {
          
            }
            reader.NextResult();
            while (reader.Read())
            {
                label50.Text = Convert.ToString(reader.GetValue(0));
            }

            reader.NextResult();
            while (reader.Read())
            {
                label44.Text = Convert.ToString(reader.GetValue(0));
            }

            reader.NextResult();
            while (reader.Read())
            {
                label21.Text = Convert.ToString(reader.GetValue(0));
            }

            reader.NextResult();
            while (reader.Read())
            {
                label24.Text = Convert.ToString(reader.GetValue(0));
            }


            con.Close();
        }

        private void Overview_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            con.Open();
            cmd = new SqlCommand("UPDATE doctor SET Dstate='offline' WHERE email='" + email+ "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void Overview_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("select name from doctor where email ='" + email+"'"+
              "select phone_secretary from doctor where email ='" + email + "'"+
              "select Address from Clinic_Loc  where email ='" + email + "'"
              , con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                label2.Text = "Dr "+Convert.ToString(reader.GetValue(0));

            reader.NextResult();
            while (reader.Read())
                label32.Text = Convert.ToString(reader.GetValue(0));
            reader.NextResult();
            while (reader.Read())
                label31.Text = Convert.ToString(reader.GetValue(0));

            con.Close();
        }
    }
}
