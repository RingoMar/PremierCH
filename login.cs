using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace PremierCH_MGMT
{
    public partial class login : Form
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public login()
        {
            InitializeComponent();

            pictureBox1.Controls.Add(pictureBox2);
            pictureBox1.Controls.Add(label1);

            pictureBox2.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            passwordBox.PasswordChar = '*';
            passwordBox.MaxLength = 14;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean found = false;
            string query = "Select email, staff_id from users where email ='" + emailBox.Text.ToString() + "' and password = '" + passwordBox.Text.ToString() + "'";
            OracleCommand oc = new OracleCommand(query, con);
            con.Open();

            OracleDataReader odr = oc.ExecuteReader();
            while (odr.Read())
            {
                string isAdmin = odr["staff_id"].ToString();
                string email = odr["email"].ToString();
                if (isAdmin != "")
                {
                    Program.isAdmin = true;
                }
                Program.email = email;
                found = true;

            }
            con.Close();

            if (found)
            {
                Program.isVaildUser = true;


                Program.SetMainForm(new Home());
                Program.ShowMainForm();
                this.Close();
            }
            else if (!found)
            {
                MessageBox.Show("Incorect Username / Password\nDon't have an account? Consider signing up!");
            }


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sginup Signup = new sginup();
            Signup.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void emailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
