using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Checkmate_Air
{
    public partial class Update_Form : Form
    {
        SqlConnection sc = new SqlConnection("Data Source = MOSES-QUAYSON\\SQLEXPRESS; Initial Catalog=Checkmate_Travels; Integrated Security =TRUE");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingSource tblDetailsBS = new BindingSource();

        String name;

        public Update_Form()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            da.SelectCommand = new SqlCommand("SELECT * FROM tblDetails where TELEPHONE = '" + txtSearch.Text + "'" , sc);
            ds.Clear();
            da.Fill(ds);

            try
            {
                //dg.DataSource = ds.Tables[0];
                tblDetailsBS.DataSource = ds.Tables[0];
                txtFirstName.DataBindings.Add("Text", tblDetailsBS, "FIRSTNAME");
                txtSurname.DataBindings.Add("Text", tblDetailsBS, "LASTNAME");
                txtGender.DataBindings.Add("Text", tblDetailsBS, "GENDER");
                txtTelephone.DataBindings.Add("Text", tblDetailsBS, "TELEPHONE");
                txtMeal.DataBindings.Add("Text", tblDetailsBS, "MEAL");
                txtAge.DataBindings.Add("Text", tblDetailsBS, "AGE");
                txtJourneyDate.DataBindings.Add("Text", tblDetailsBS, "JOURNEY_DATE");
                txtDeptTime.DataBindings.Add("Text", tblDetailsBS, "DEPARTURE_TIME");
                cbxFlight.DataBindings.Add("Text", tblDetailsBS, "FLIGHT_NAME");
                txtCharge.DataBindings.Add("Text", tblDetailsBS, "CHARGE");
                cbxClass.DataBindings.Add("Text", tblDetailsBS, "CLASS");
                txtFrom.DataBindings.Add("Text", tblDetailsBS, "DEPARTURE");
                cbxTo.DataBindings.Add("Text", tblDetailsBS, "ARRIVAL");
                cbxAirport.DataBindings.Add("Text", tblDetailsBS, "AIRPORT");
                

            }
            catch (Exception ex)
            {

                MessageBox.Show("Search Successful!!");
            }
        }

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOption.SelectedIndex == 0)
            {
                /*this.Hide();
                Form1 f1 = new Form1();
                f1.Show();*/

                Close();
            }
        }

        private void cbxAirport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Arrival();
        }

        public void Arrival()
        {
            if (cbxAirport.Text == "Kotoka Int'l  Airport")
            {
                txtFrom.Text = "Accra";
            }

            else if (cbxAirport.Text == "Kumasi Airport")
            {
                txtFrom.Text = "Kumasi";
            }

            else if (cbxAirport.Text == "Tamale Airport")
            {
                txtFrom.Text = "Tamale";
            }

            else if (cbxAirport.Text == "Sunyani Airport")
            {
                txtFrom.Text = "Sunyani";
            }

            else if (cbxAirport.Text == "Takoradi Airport")
            {
                txtFrom.Text = "Takoradi";
            }

            else if (cbxAirport.Text == "Wa Airport")
            {
                txtFrom.Text = "Wa";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //da.UpdateCommand = new SqlCommand("Update tblDetails set FIRSTNAME LASTNAME AGE GENDER MEAL");
            name = txtFirstName.Text + txtSurname.Text;
            da.UpdateCommand = new SqlCommand("Update tblDetails set FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME, AGE = @AGE, GENDER = @GENDER, MEAL = @MEAL,"
                                              + "JOURNEY_DATE = @JOURNEY_DATE,DEPARTURE_TIME = @DEPARTURE_TIME," +
                                              "FLIGHT_NAME = @FLIGHT_NAME, AIRPORT = @AIRPORT, DEPARTURE = @DEPARTURE, ARRIVAL = @ARRIVAL, "+
                                              "CLASS = @CLASS, CHARGE = @CHARGE where TELEPHONE = @TELEPHONE ", sc);

            try
            {
                //Passenger Details
                da.UpdateCommand.Parameters.AddWithValue("@FIRSTNAME", txtFirstName.Text);
                da.UpdateCommand.Parameters.AddWithValue("@LASTNAME", txtSurname.Text);
                da.UpdateCommand.Parameters.AddWithValue("@AGE", txtAge.Text);
                da.UpdateCommand.Parameters.AddWithValue("@GENDER", txtGender.Text);
                da.UpdateCommand.Parameters.AddWithValue("@MEAL", txtMeal.Text);

                //Flight Details
                da.UpdateCommand.Parameters.AddWithValue("@JOURNEY_DATE", txtJourneyDate.Text);
                da.UpdateCommand.Parameters.AddWithValue("@DEPARTURE_TIME", txtDeptTime.Text);
                da.UpdateCommand.Parameters.AddWithValue("@FLIGHT_NAME", cbxFlight.Text);
                da.UpdateCommand.Parameters.AddWithValue("@AIRPORT", cbxAirport.Text);
                da.UpdateCommand.Parameters.AddWithValue("@DEPARTURE", txtFrom.Text);
                da.UpdateCommand.Parameters.AddWithValue("@ARRIVAL", cbxTo.Text);
                da.UpdateCommand.Parameters.AddWithValue("@TELEPHONE", txtTelephone.Text);
                da.UpdateCommand.Parameters.AddWithValue("@CLASS", cbxClass.Text);
                da.UpdateCommand.Parameters.AddWithValue("@CHARGE", txtCharge.Text);

                sc.Open();
                da.UpdateCommand.ExecuteNonQuery();

                sc.Close();

                MessageBox.Show("Update Successful");
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
                    
        }

        private void cbxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            double fare = 1325.25;
            double charge;

            if (cbxClass.Text == "First")
            {
                charge = fare + 400;
                txtCharge.Text = Convert.ToString(charge);
            }

            if (cbxClass.Text == "Business")
            {
                charge = fare + 200;
                txtCharge.Text = Convert.ToString(charge);
            }

            if (cbxClass.Text == "Economic")
            {
                charge = fare;
                txtCharge.Text = Convert.ToString(charge);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report rep = new Report(name , txtTelephone.Text);
            rep.Show();
        }
    }
}
