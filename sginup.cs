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
    public partial class sginup : Form
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public sginup()
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

            string query = "INSERT INTO users VALUES ('" + emailBox.Text.ToString() + "', '" + passwordBox.Text.ToString() + "', null, null)";
            try
            {
                OracleCommand cmd = new OracleCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd = new OracleCommand("commit", con);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to complate sign up:\n" + ex);
            }
            con.Close();
            Program.isVaildUser = true;
            Program.email = emailBox.Text.ToString();
            MessageBox.Show("Thank you for signing up!");
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sginup_Load(object sender, EventArgs e)
        {

        }
    }
}
