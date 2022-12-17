using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremierCH_MGMT
{
    public partial class Home : Form
    {

        dashboard Dashboard = new dashboard();
        bookApp book = new bookApp();
        invoice Invoice = new invoice();
        login Login = new login();
        userinfo userPage = new userinfo();

        public Home()
        {
            InitializeComponent();
            if (Program.isAdmin == false)
            {
                Console.WriteLine("Hidding Button");
                button4.Visible = false;
            }

            pictureBox1.Controls.Add(label1);
            pictureBox1.Controls.Add(label2);
            pictureBox1.Controls.Add(label3);
            pictureBox1.Controls.Add(label4);
            pictureBox1.Controls.Add(label5);
            pictureBox1.Controls.Add(label6);

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.isAdmin = false;
            Program.isVaildUser = false;

            Login.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            book.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Program.isAdmin)
            {
                Dashboard.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Invoice.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Program.isVaildUser)
            {
                userPage.Show();
            }
        }
    }
}
