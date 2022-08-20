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
    public partial class Display_Form : Form
    {
        SqlConnection sc = new SqlConnection("Data Source = MOSES-QUAYSON\\SQLEXPRESS; Initial Catalog=Checkmate_Travels; Integrated Security =TRUE");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public Display_Form()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("Select * from tblDetails",sc);
            ds.Clear();
            da.Fill(ds);
            dg.DataSource = ds.Tables[0];
        }
    }
}
