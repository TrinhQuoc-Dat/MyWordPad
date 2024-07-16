using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWordPad
{
    public partial class Find : Form
    {
        public static Find instance;
        
        public Find()
        {
            InitializeComponent();
            instance = this;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string searchText = txtFind.Text;
            Form1.instance.FindText(searchText);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Find_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.instance.ResetTextColors();
            Form1.flagFind = false;
        }

        private void chbMatchWhole_CheckedChanged(object sender, EventArgs e)
        {
            Form1.instance.MatchWholeWord = chbMatchWhole.Checked;
        }

        private void chbMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            Form1.instance.MatchCase = chbMatchCase.Checked;
        }

       
    }
}
