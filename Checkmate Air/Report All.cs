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
    public partial class Report_All : Form
    {
        public Report_All()
        {
            InitializeComponent();
        }

        private void Report_All_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Report_All' table. You can move, or remove it, as needed.
            this.Report_AllTableAdapter.Fill(this.DataSet1.Report_All);

            this.reportViewer1.RefreshReport();
        }
    }
}
