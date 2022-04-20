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
            guna2ComboBox1.Text = "hgfdfghj";
        }

        private void guna2ComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_Leave(object sender, EventArgs e)
        {
            

        }

        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            
            if (kryptonTextBox1.Text != "Search by Name")
            {
                con.Open();
                string email = Form1.email;
           
                SqlCommand command = new SqlCommand(
                 " SELECT * FROM doctor WHERE name LIKE '%"+ kryptonTextBox1.Text + "%' and  specialization = '" + guna2ComboBox1.SelectedItem.ToString() + "'" +
                 " select userID from Patient where email = '" + email + "'"
                  , con);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    guna2ShadowPanel3.Visible = true;
                    panel1.Dock = DockStyle.Top;
                    guna2ShadowPanel3.Dock = DockStyle.Top;
                    label1.Text = reader.GetValue(0).ToString();
                    label7.Text = reader.GetValue(1).ToString();
                    label9.Text = reader.GetValue(7).ToString();
                    label8.Text = reader.GetValue(8).ToString();
                    label11.Text = reader.GetValue(10).ToString(); 
                }


                reader.NextResult();
                while (reader.Read())
                {
                    label2.Text = reader.GetValue(0).ToString();

                }
                con.Close();
            
            }
            else
            {
                con.Open();
                string email = Form1.email;
                SqlCommand command = new SqlCommand("select * from doctor where specialization = '" + guna2ComboBox1.SelectedItem.ToString() + "';" +
                  " select userID from Patient where email = '" + email + "'"
                  , con);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    guna2ShadowPanel3.Visible = true;
                    panel1.Dock = DockStyle.Top;
                    guna2ShadowPanel3.Dock = DockStyle.Top;
                    label1.Text = reader.GetValue(0).ToString();
                    label7.Text = reader.GetValue(1).ToString();
                    label9.Text = reader.GetValue(7).ToString();
                    label8.Text = reader.GetValue(8).ToString();
                    label11.Text = reader.GetValue(10).ToString();
                }


                reader.NextResult();
                while (reader.Read())
                {
                    label2.Text = reader.GetValue(0).ToString();

                }
                con.Close();
           
            }
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
            cmd = new SqlCommand("INSERT INTO booking (userID, doctorID, time, date,  state)VALUES('"+label2.Text+"','"+label1.Text+"','"+ kryptonTextBox2.Text+"','"+ kryptonTextBox1.Text + "','in progress'  ); ",con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Search by Name")
                kryptonTextBox1.Text = "";

        }

        private void kryptonTextBox1_Click(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Search by Name")
                kryptonTextBox1.Text = "";
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Search by Name")
                kryptonTextBox1.Text = "";
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
                kryptonTextBox1.Text = "Search by Name";
        }

        private void kryptonTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                kryptonButton2.PerformClick();
        }

        private void kryptonTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
