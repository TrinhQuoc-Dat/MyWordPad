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
    public partial class Replace : Form
    {
        public static Replace instance2;

        public Replace()
        {
            InitializeComponent();
            instance2 = this;
        }

        private void chbMatchWhole_CheckedChanged(object sender, EventArgs e)
        {
            Form1.instance.MatchWholeWord = chbMatchWhole.Checked;
        }

        private void chbMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            Form1.instance.MatchCase = chbMatchCase.Checked;
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

        private void Replace_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.instance.ResetTextColors();
            Form1.flagReplace = false;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            string newText = txtReplace.Text;
            Form1.instance.ReplaceSelectedText(newText);
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            string searchText = txtFind.Text; // Lấy từ cần tìm từ hộp văn bản txtFind
            string newText = txtReplace.Text; // Lấy từ mới từ hộp văn bản txtReplace
            Form1.instance.ReplaceAllText(searchText, newText);

        }
    }
}
