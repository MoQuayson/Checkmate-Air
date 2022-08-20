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
    public partial class Delete_Form : Form
    {
        SqlConnection sc = new SqlConnection("Data Source = MOSES-QUAYSON\\SQLEXPRESS; Initial Catalog=Checkmate_Travels; Integrated Security =TRUE");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public Delete_Form()
        {
            InitializeComponent();
        }

        private void Delete_Form_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            da.DeleteCommand = new SqlCommand("Delete from tblDetails where TELEPHONE = '" + txtSearch.Text + "'",sc);
            //da.DeleteCommand.Parameters.AddWithValue();
            sc.Open();
            da.DeleteCommand.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Delete Successful!!");

            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("SELECT * FROM tblDetails where TELEPHONE = '" + txtSearch.Text + "'", sc);
            ds.Clear();
            da.Fill(ds);
            dg.DataSource = ds.Tables[0];
        }
    }
}
