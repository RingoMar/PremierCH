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
    public partial class userinfo : Form
    {

        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public userinfo()
        {
            InitializeComponent();

            OracleCommand oda = new OracleCommand("SELECT PATIENT.fname, PATIENT.lname, PATIENT.contact, PATIENT.GENDER, PATIENT.ADRESS, PATIENT.PDETAILS, PATIENT.BLOODGROUP FROM PATIENT left JOIN users ON users.pid = patient.pid WHERE users.email = '" + Program.email + "'", con);
            con.Open();

            OracleDataReader odr = oda.ExecuteReader();
            if (odr.Read())
            {
                string fname = odr["fname"].ToString();
                string lname = odr["lname"].ToString();
                string contact= odr["contact"].ToString();
                string GENDER = odr["GENDER"].ToString();
                string ADRESS = odr["ADRESS"].ToString();
                string BLOODGROUP = odr["PDETAILS"].ToString();
                string PDETAILS = odr["BLOODGROUP"].ToString();

                fnameBox.Text = fname;
                lnameBox.Text = lname;
                conBox.Text = contact;
                addrBox.Text = ADRESS;
                bgBox.Text = PDETAILS;
                pdBox.Text = BLOODGROUP;

                if (GENDER == "M")
                {
                    checkBox1.Checked = true;

                } else if (GENDER == "F")
                {
                    checkBox2.Checked = true;
                }

            }
            con.Close();
            textBox1.Text = Program.email;
        }

        private void namebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bgBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void View_User_Priv_Click(object sender, EventArgs e)
        {

        }

        private void pdBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            bookApp book = new bookApp();
            book.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            invoice Invoice = new invoice();
            Invoice.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            login Login = new login();
            Login.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            userinfo userPage = new userinfo();
            userPage.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
