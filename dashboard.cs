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
    public partial class dashboard : Form
    {


        private void fullAllTables()
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            OracleDataAdapter oda = new OracleDataAdapter("SELECT appointment.app_id, patient.fname, patient.lname, service.ser_type, staff.staff_name, room.roomtype, appointment.app_date FROM appointment INNER JOIN patient ON appointment.pid = patient.pid INNER JOIN staff ON appointment.staff_id = staff.staff_id INNER JOIN service ON appointment.serviceid = service.serviceid INNER JOIN room ON appointment.room_id = room.room_id WHERE appointment.rec_id IS NULL ORDER BY appointment.app_id", con);

            DataTable dt = new DataTable();
            oda.Fill(dt);
            User_List.DataSource = dt;

            OracleDataAdapter odap = new OracleDataAdapter("SELECT patient.pid, patient.fname, patient.lname, patient.contact, patient.gender, patient.bloodgroup, patient.adress, patient.pdetails FROM patient", con);

            DataTable dtp = new DataTable();
            odap.Fill(dtp);
            dataGridView3.DataSource = dtp;


            OracleDataAdapter odar = new OracleDataAdapter("SELECT patient.fname, patient.lname, patient.contact, patient.gender, patient.pdetails, patient.bloodgroup, appointment.app_date FROM record  INNER JOIN appointment ON appointment.app_id = record.app_id INNER JOIN patient ON patient.pid = record.pid where appointment.rec_id is not null", con);

            DataTable dtr = new DataTable();
            odar.Fill(dtr);

            OracleDataAdapter query = new OracleDataAdapter("SELECT bill.billid, patient.pid, bill.name, bill.cost FROM bill INNER JOIN patient ON bill.billid = patient.billid", con);
            DataTable dataTable = new DataTable();

            query.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            recordTables.DataSource = dtp;

            recordTables.AllowUserToAddRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView3.AllowUserToAddRows = false;
            User_List.AllowUserToAddRows = false;


        }

        private void updateAppCombo()
        {
            // Updates all combo boxes with data
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            OracleDataAdapter ocr = new OracleDataAdapter("Select staff_id, staff_name from staff", con);
            OracleDataAdapter ocs = new OracleDataAdapter("Select SER_TYPE, SERVICEID from SERVICE", con);
            OracleDataAdapter ocroo = new OracleDataAdapter("Select ROOM_ID, ROOMTYPE from room", con);
            OracleCommand ocp = new OracleCommand("Select pid from patient", con);
            OracleCommand ocap = new OracleCommand("SELECT app_id FROM appointment", con);
            con.Open();

            OracleDataReader odp = ocp.ExecuteReader();
            OracleDataReader odap = ocap.ExecuteReader();

            DataTable dt = new DataTable();
            DataTable dts = new DataTable();
            DataTable dtroo = new DataTable();
            ocr.Fill(dt);
            ocs.Fill(dts);
            ocroo.Fill(dtroo);

            DataRow row = dt.NewRow();
            DataRow serRow = dts.NewRow();
            DataRow roomRow = dtroo.NewRow();
            row[0] = 0;
            row[1] = "Please select";

            dt.Rows.InsertAt(row, 0);
            staffbox.DataSource = dt;
            staffbox.DisplayMember = "staff_name";
            staffbox.ValueMember = "staff_id";

            serRow[1] = 0;
            serRow[0] = "Please select";

            dts.Rows.InsertAt(serRow, 0);
            appty.DataSource = dts;
            appty.DisplayMember = "SER_TYPE";
            appty.ValueMember = "SERVICEID";

            roomRow[0] = 0;
            roomRow[1] = "Please select";

            dtroo.Rows.InsertAt(roomRow, 0);
            roomid.DataSource = dtroo;
            roomid.DisplayMember = "ROOMTYPE"; 
            roomid.ValueMember = "ROOM_ID";
            // appointbox
            //roomid

            while (odp.Read())
            {
                string first_name = odp["pid"].ToString();
                pids.Items.Add(first_name);
            }

            while (odap.Read())
            {
                string first_name = odap["app_id"].ToString();
                appointbox.Items.Add(first_name);
            }

            con.Close();
        }

        public dashboard()
        {
            InitializeComponent();
            fullAllTables();
            updateAppCombo();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Updates the data table for the appointment data table 
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            OracleDataAdapter oda = new OracleDataAdapter("SELECT appointment.app_id, patient.fname, patient.lname, service.ser_type, staff.staff_name, room.roomtype, appointment.app_date FROM appointment INNER JOIN patient ON appointment.pid = patient.pid INNER JOIN staff ON appointment.staff_id = staff.staff_id INNER JOIN service ON appointment.serviceid = service.serviceid INNER JOIN room ON appointment.room_id = room.room_id WHERE appointment.rec_id IS NULL ORDER BY appointment.app_id", con);

            DataTable dt = new DataTable();

            oda.Fill(dt);

            User_List.DataSource = dt;
        }

        private void Delete_Audit_Records_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            OracleDataAdapter oda = new OracleDataAdapter("SELECT * FROM record left JOIN users ON users.pid = record.pid WHERE users.email = '" + Program.email + "'", con);

            DataTable dt = new DataTable();

            oda.Fill(dt);

            recordTables.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            OracleDataAdapter query = new OracleDataAdapter("SELECT bill.billid, patient.pid, bill.name, bill.cost FROM bill INNER JOIN patient ON bill.billid = patient.billid", con);
            DataTable dataTable = new DataTable();

            query.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Makes a new appointment
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            String pname = pids.Text.ToString();
            int room = Convert.ToInt32(roomid.SelectedValue);
            int staff = Convert.ToInt32(staffbox.SelectedValue);
            int appt = Convert.ToInt32(appty.SelectedValue);

            string query = "INSERT INTO APPOINTMENT VALUES ('" + pname + "', SYSDATE, appointnum.nextval, '" + room + "', '" + staff + "', '" + appt + "', null)";

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
                MessageBox.Show("Unable to add user to database:\n" + ex);
            }
            con.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Add a new user
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            String fname = s_fnam.Text.ToString();
            String lname = s_lname.Text.ToString();
            String connum = s_con.Text.ToString();
            String gen = s_gen.Text.ToString();
            String bg = s_bg.Text.ToString();
            String pother = s_de.Text.ToString();
            String adrr = s_addr.Text.ToString();

            string query = "INSERT INTO patient VALUES ('" + fname + "', '" + lname + "', '" +  connum + "', paitennum.nextval, '" + gen +"', '" + adrr + "', '" + pother + "', '" + bg + "', null, null)";
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
                MessageBox.Show("Unable to add user to database:\n" + ex);
            }

            OracleDataAdapter odap = new OracleDataAdapter("SELECT patient.fname, patient.lname, patient.contact, patient.gender, patient.bloodgroup, patient.adress, patient.pdetails FROM patient", con);

            DataTable dtp = new DataTable();
            odap.Fill(dtp);
            dataGridView3.DataSource = dtp;

            con.Close();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            OracleDataAdapter odap = new OracleDataAdapter("SELECT patient,pid, patient.fname, patient.lname, patient.contact, patient.gender, patient.bloodgroup, patient.adress, patient.pdetails FROM patient", con);

            DataTable dtp = new DataTable();
            odap.Fill(dtp);
            dataGridView3.DataSource = dtp;

        }

        private void View_User_Priv_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            OracleCommand oda = new OracleCommand("SELECT appointment.pid, service.ser_type FROM appointment INNER JOIN service ON appointment.serviceid = service.serviceid WHERE appointment.app_id = '" + appointbox.Text.ToString() + "'", con);
            con.Open();

            OracleDataReader odr = oda.ExecuteReader();
            if (odr.Read())
            {
                string service = odr["ser_type"].ToString();
                string pid = odr["pid"].ToString();

                try
                {
                    OracleCommand cmd = new OracleCommand("INSERT INTO bill VALUES (billnum.nextval, '" + service + "',  1000)", con);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand("update patient set billid = billnum.currval where pid = '" + pid + "'", con);
                    cmd.ExecuteNonQuery();

                    cmd = new OracleCommand("commit", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to chnage database:\n" + ex);
                }
            }

            try
            {
                OracleCommand cmd = new OracleCommand("delete from APPOINTMENT where app_id ='" + appointbox.Text.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                cmd = new OracleCommand("commit", con);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to adjust database:\n" + ex);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            bookApp book = new bookApp();
            book.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            invoice Invoice = new invoice();
            Invoice.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            userinfo userPage = new userinfo();
            userPage.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            login Login = new login();
            Login.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            OracleDataAdapter oda = new OracleDataAdapter("select * from prescription", con);

            DataTable dt = new DataTable();

            oda.Fill(dt);

            dataGridView2.DataSource = dt;
        }

        private void recordTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
