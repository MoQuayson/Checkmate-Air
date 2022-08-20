using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace Checkmate_Air
{
    public partial class Form1 : Form
    {
        //SqlConnection
        SqlConnection sc = new SqlConnection("Data Source= MOSES-QUAYSON\\SQLEXPRESS; Initial Catalog= Checkmate_Travels; Integrated Security=TRUE;");
        SqlDataAdapter da = new SqlDataAdapter();
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(Splash));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();

            t.Abort();

            
        }

        public void Splash()
        {
            Application.Run(new Form2());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogInChecks();
            //Admin();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            
            SignUpChecks();
        }

        public void LogInChecks()
        {
           sc.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblClients WHERE USERNAME = '" + txtUsername.Text + "' AND PASSWORD = '" + txtPassword.Text + "'", sc);
            
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            

            int count = 0;

            while (dr.Read())
            {
                count += 1;

            }

            if (count == 1)
            {
                this.Hide();
                Main_Activity main = new Main_Activity(txtUsername.Text);
                main.ShowDialog();
            }

            else if (txtUsername.Text == "admin" || txtSurname.Text == "admin")
            {
                this.Hide();
                Admin_Form admin = new Admin_Form();
                admin.Show();
            }

            else
            {
                MessageBox.Show("Invalid Username or Password!");
            }

            txtUsername.Clear();
            txtPassword.Clear();

            

            //sc.Close();
            //count = 0;
           
        }

        public  void Admin()
        {
            sc.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblAdmin WHERE USERNAME = '" + txtUsername.Text + "' AND PASSWORD = '" + txtPassword.Text + "'", sc);
            
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            int count = 0;

            while (dr.Read())
            {
                count += 1;
            }

            if (count == 1)
            {
                this.Hide();
                Admin_Form admin = new Admin_Form();
                admin.Show();
            }

            else
            {
                MessageBox.Show("Invalid Username or Password!");
            }

            txtUsername.Clear();
            txtPassword.Clear();

            

            //sc.Close();
            //count = 0;

        }

        public void SignUpChecks()
        {
            //String dob = cbxDay.Text +" " + cbxMonth.Text +" " + txtYear.Text;
            //Checks to see if SignUp column is filled
            if (txtFirstname.Text == "" || txtSurname.Text == "" || txtEmail.Text == "" || Username.Text == "" ||Password.Text == "" || 
                txtEmail.Text == "")
            {
                MessageBox.Show("Input your Credentials");
            }

            
            
                try
                {
                    da.InsertCommand = new SqlCommand("INSERT INTO tblClients VALUES(@FIRSTNAME, @SURNAME, @EMAIL, @USERNAME, @PASSWORD)", sc);
                    da.InsertCommand.Parameters.AddWithValue("@FIRSTNAME", txtFirstname.Text);
                    da.InsertCommand.Parameters.AddWithValue("@SURNAME", txtSurname.Text);
                    da.InsertCommand.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                    da.InsertCommand.Parameters.AddWithValue("@USERNAME",Username.Text);
                    da.InsertCommand.Parameters.AddWithValue("@PASSWORD",Password.Text);
                    //da.InsertCommand.Parameters.AddWithValue("@TELEPHONE",txtTelephone.Text);
                    //da.InsertCommand.Parameters.AddWithValue("@DOB",dob);
                    


           

                    sc.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    sc.Close();

                    txtFirstname.Text = txtSurname.Text = txtEmail.Text = txtUsername.Text = txtPassword.Text = " ";

                    this.Hide();
                    Main_Activity ma = new Main_Activity(Username.Text);
                    ma.ShowDialog();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                } 
            }
            
        }
    }

