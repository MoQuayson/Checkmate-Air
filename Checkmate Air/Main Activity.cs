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
       
    public partial class Main_Activity : Form
    {
        //Connection Class
        SqlConnection sc = new SqlConnection("Data Source= MOSES-QUAYSON\\SQLEXPRESS; Initial Catalog= Checkmate_Travels; Integrated Security=TRUE");
        SqlDataAdapter da = new SqlDataAdapter();

        double fare = 1325.25;
        double charge;
        String gender, meal,name;
        
        public Main_Activity(String username)
        {
            InitializeComponent();

            Greetings.Text = "Hello " + username;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCharge.Text = null;
            cbxAirport.SelectedIndex = 0;
            cbxFlight.SelectedIndex = 0;
            cbxTo.SelectedIndex = 0;
            cbxFlight.SelectedIndex = 0;
            txtFirstName.Text = null;
            txtSurname.Text = null;
            //txtHour.Text = null;
            txtAge.Text = null;
            txtTelephone.Text = null;
            txtDay.Text = null;

            btnConfirm.Enabled = true;
            
        }



        private void txtFrom_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void Charge()
        {
            if(cbxClass.Text == "First")
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

            
                if (rbMale.Checked == true)
                {
                    gender = rbMale.Text;
                }

                else if (rbFemale.Checked == true)
                {
                    gender = rbFemale.Text;
                }

                if (cbVeg.Checked == true)
                {
                    meal = cbVeg.Text;
                }

                else if (cbNonVeg.Checked == true)
                {
                    meal = cbNonVeg.Text;
                }

                
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
             //name = txtFirstName.Text + txtSurname.Text; 
            //String time = txtHour.Text + " " + " : " + txtMinute.Text + " " + cbxClock.Text;
            String jdate = txtDay.Text + " " + cbxMonth.Text + " " + txtYear.Text;
            Charge();
            da.InsertCommand = new SqlCommand("INSERT INTO tblDetails VALUES(@FIRSTNAME, @LASTNAME, @AGE, @GENDER, @MEAL,"
                                              +"@JOURNEY_DATE,@DEPARTURE_TIME,@FLIGHT_NAME, @AIRPORT, @DEPARTURE, @ARRIVAL, @CLASS, @CHARGE, @TELEPHONE)", sc);

            try
            {
                //Passenger Details
                da.InsertCommand.Parameters.AddWithValue("@FIRSTNAME", txtFirstName.Text);
                da.InsertCommand.Parameters.AddWithValue("@LASTNAME", txtSurname.Text);
                da.InsertCommand.Parameters.AddWithValue("@AGE", txtAge.Text);
                da.InsertCommand.Parameters.AddWithValue("@GENDER", gender);
                da.InsertCommand.Parameters.AddWithValue("@MEAL", meal);

                //Flight Details
                da.InsertCommand.Parameters.AddWithValue("@JOURNEY_DATE", jdate);
                da.InsertCommand.Parameters.AddWithValue("@DEPARTURE_TIME", txtDeptTime.Text + "GMT");
                da.InsertCommand.Parameters.AddWithValue("@FLIGHT_NAME", cbxFlight.Text);
                da.InsertCommand.Parameters.AddWithValue("@AIRPORT", cbxAirport.Text);
                da.InsertCommand.Parameters.AddWithValue("@DEPARTURE", txtFrom.Text);
                da.InsertCommand.Parameters.AddWithValue("@ARRIVAL", cbxTo.Text);
                da.InsertCommand.Parameters.AddWithValue("@TELEPHONE", txtTelephone.Text);
                da.InsertCommand.Parameters.AddWithValue("@CLASS", cbxClass.Text);
                da.InsertCommand.Parameters.AddWithValue("@CHARGE", txtCharge.Text);

                sc.Open();
                da.InsertCommand.ExecuteNonQuery();
                
                sc.Close();

                ////MessageBox.Show("Ticket Booked Successfully!!");
                btnConfirm.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
                    

        }

       

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbOption.SelectedIndex==0)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            name = txtFirstName.Text + txtSurname.Text;
            Report rep = new Report(name , txtTelephone.Text);
            rep.Show();
        }

        private void cbxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Charge();
        }

        private void cbxAirport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Arrival();
            DeptTime();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void DeptTime()
        {
            int n1, n2;
            String tot ;
            Random r = new Random();
            n1 = r.Next(00, 23);
            n2 = r.Next(00, 59);
            tot = Convert.ToString((n1) + ":" + (n2));
            txtDeptTime.Text = tot;
            
        }

        

        
        

        
    }
}
