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
    public partial class invoice : Form
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public invoice()
        {
            InitializeComponent();

            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            OracleCommand ocp = new OracleCommand("Select pid from patient", con);
            con.Open();
            OracleDataReader odp = ocp.ExecuteReader();
            while (odp.Read())
            {
                string first_name = odp["pid"].ToString();
                comboBox1.Items.Add(first_name);
            }

            OracleDataAdapter query = new OracleDataAdapter("SELECT bill.billid, patient.pid, bill.name, bill.cost FROM bill INNER JOIN patient ON bill.billid = patient.billid", con);
            DataTable dataTable = new DataTable();

            query.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            con.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            OracleDataAdapter query = new OracleDataAdapter("SELECT bill.billid, patient.pid, bill.name, bill.cost FROM bill INNER JOIN patient ON bill.billid = patient.billid", con);
            DataTable dataTable = new DataTable();

            query.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {


            OracleCommand oc = new OracleCommand("SELECT bill.billid, bill.name, bill.cost, patient.fname, patient.lname FROM bill INNER JOIN patient ON bill.billid = patient.billid where patient.pid ='" + comboBox1.Text + "'", con);
            con.Open();

            OracleDataReader odr = oc.ExecuteReader();
            if (odr.Read())
            {
                string first_name = odr["fname"].ToString();
                string last_name = odr["lname"].ToString();
                string billid = odr["billid"].ToString();
                string cost = odr["cost"].ToString();

                label11.Text = first_name;
                label12.Text = last_name;
                label13.Text = "#ID: " + billid;
                label10.Text = "$" + cost;

            }
            else
            {
                label11.Text = "Invalid";
                label12.Text = "Invalid";
                label13.Text = "#ID: null";
            }

            con.Close();


        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // end the pending payment

            if (comboBox1.Text != "")
            {
                OracleCommand cmd = new OracleCommand("update patient set billid = null where pid = '" + comboBox1.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();

                cmd = new OracleCommand("commit", con);
                cmd.ExecuteNonQuery();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

