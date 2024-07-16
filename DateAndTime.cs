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
    public partial class DateAndTime : Form
    {
        private Form1 f;
        public DateAndTime()
        {
            InitializeComponent();
        }

        public DateAndTime(Form1 form1)
        {
            InitializeComponent();
            f = form1;
        }
        private void DateTime_Load(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lsBox.Items.Add(time.ToString("M/dd/yyyy"));
            lsBox.Items.Add(time.ToString("M/dd/yy"));
            lsBox.Items.Add(time.ToString("MM/dd/yy"));
            lsBox.Items.Add(time.ToString("MM/dd/yyyy"));
            lsBox.Items.Add(time.ToString("yy/MM/dd"));
            lsBox.Items.Add(time.ToString("yyyy-MM-dd"));



            lsBox.Items.Add(time.ToString("yy-MMM-yy"));
            lsBox.Items.Add(time.ToString("D"));
            lsBox.Items.Add(time.ToString("MMMM dd, yyyy"));


            lsBox.Items.Add(time.ToString("dddd, dd MMMM, yyyy"));
            lsBox.Items.Add(time.ToString("dd MMMM, yyyy"));
            lsBox.Items.Add(time.ToString("T"));
            lsBox.Items.Add(time.ToString("hh:mm:ss tt"));

            lsBox.Items.Add(time.ToString("h:mm:ss"));
            lsBox.Items.Add(time.ToString("hh:mm:ss"));

            // Chọn mặc định item đầu tiên trong ListBox
            lsBox.SelectedIndex = 0;

        }

        private void btOkDT_Click(object sender, EventArgs e)
        {
            Form1.timeNow = lsBox.SelectedItem.ToString();
            f.insert_Time();
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
