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
    public partial class Admin_Form : Form
    {
        private int childFormNumber = 0;

        public Admin_Form()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void iNSERTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_Activity ma = new Main_Activity("Admin");
            ma.MdiParent = this;
            ma.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Form uf = new Update_Form();
            uf.MdiParent = this;
            uf.Show();
        }

        private void dISPLAYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Display_Form df = new Display_Form();
            df.MdiParent = this;
            df.Show();
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_Form df = new Delete_Form();
            df.MdiParent = this;
            df.Show();
        }

        private void rEPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_All ra = new Report_All();
            ra.Show();
        }
    }
}
