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
    public partial class Form8 : KryptonForm
    {
        SqlConnection con = new SqlConnection(@"workstation id=AWDsqlonline.mssql.somee.com;packet size=4096;user id=mustafaalsharef_SQLLogin_1;pwd=7aczijc3l9;data source=AWDsqlonline.mssql.somee.com;persist security info=False;initial catalog=AWDsqlonline");
        SqlCommand cmd;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_Click(object sender, EventArgs e)
        {
            //guna2ComboBox1.Items.RemoveAt(4);
        }

        private void guna2ComboBox1_Leave(object sender, EventArgs e)
        {
            

        }

        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            
            con.Open();
            string email = Form1.email;
            SqlCommand command = new SqlCommand("select name ,email ,phone_secretary , Dstate from doctor where specialization = '" + guna2ComboBox1.SelectedItem.ToString() + "' and name = '"+kryptonTextBox1.Text+"' ;"+
               " SELECT doctorId from doctor where email = '"+label8.Text+"' "+
              " select userID from Patient where email = '"+email+"'"
              , con);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                guna2ShadowPanel3.Visible = true;
                panel1.Dock = DockStyle.Top;
                guna2ShadowPanel3.Dock = DockStyle.Top;
                label7.Text=reader.GetValue(0).ToString();
                label8.Text=reader.GetValue(1).ToString();
                label9.Text=reader.GetValue(2).ToString();
                label11.Text=reader.GetValue(3).ToString();
            }
            reader.NextResult();
            while (reader.Read())
            {
                label1.Text=reader.GetValue(0).ToString();

            }
            reader.NextResult();
            while (reader.Read())
            {
                label2.Text = reader.GetValue(0).ToString();

            }
            con.Close();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.Dock = DockStyle.Top;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("INSERT INTO booking (userID, doctorID, time, date,  state)VALUES('"+label2.Text+"','"+label1.Text+"','"+ kryptonTextBox2.Text+"','"+ kryptonTextBox1.Text + "','in progress'  ); ");
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
