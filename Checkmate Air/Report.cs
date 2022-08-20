using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkmate_Air
{
    public partial class Report : Form
    {
        public Report(String name , string telephone)
        {
            InitializeComponent();
            txtDisplay.Text = name;
            txtDisplay2.Text = telephone;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.tblDetails' table. You can move, or remove it, as needed.
            this.tblDetailsTableAdapter.Fill(this.DataSet1.tblDetails,txtDisplay2.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
