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
    public partial class bookApp : Form
    {
        private void updateAppCombo()
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            OracleDataAdapter ocr = new OracleDataAdapter("Select staff_id, staff_name from staff", con);
            OracleDataAdapter ocs = new OracleDataAdapter("Select SER_TYPE, SERVICEID from SERVICE", con);
            con.Open();

            DataTable dt = new DataTable();
            DataTable dts = new DataTable();
            ocr.Fill(dt);
            ocs.Fill(dts);

            DataRow row = dt.NewRow();
            DataRow serRow = dts.NewRow();
            row[0] = 0;
            row[1] = "Please select";

            dt.Rows.InsertAt(row, 0);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "staff_name";
            comboBox2.ValueMember = "staff_id";

            serRow[1] = 0;
            serRow[0] = "Please select";

            dts.Rows.InsertAt(serRow, 0);
            comboBox1.DataSource = dts;
            comboBox1.DisplayMember = "SER_TYPE";
            comboBox1.ValueMember = "SERVICEID";

            // appointbox
            //roomid

            con.Close();
        }

        public bookApp()
        {
            InitializeComponent();
            updateAppCombo();
            //comboBox1
            //comboBox2
        }

        private void bookApp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            int room = Convert.ToInt32(comboBox1.SelectedValue);
            int staff = Convert.ToInt32(comboBox2.SelectedValue);
            int appt = Convert.ToInt32(comboBox1.SelectedValue);

            OracleCommand oda = new OracleCommand("SELECT PATIENT.pid FROM PATIENT left JOIN users ON users.pid = patient.pid WHERE users.email = '" + Program.email + "'", con);
            con.Open();

            OracleDataReader odr = oda.ExecuteReader();
            if (odr.Read())
            {
                string pname = odr["pid"].ToString();

                string query = "INSERT INTO APPOINTMENT VALUES ('" + pname + "', SYSDATE, appointnum.nextval, '" + room + "', '" + staff + "', '" + appt + "', null)";

                try
                {
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand("commit", con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Apppointment has been made!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to add user to database:\n" + ex);
                }
            }
            con.Close();

        }
    }
}
