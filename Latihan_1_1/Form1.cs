using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            dateTimePicker1.Enabled = true;
            int thn = DateTime.Now.Year - vScrollBar1.Value;
            int tgl = DateTime.Now.Day;
            int bln = DateTime.Now.Month;
            label1.Text = thn.ToString();
            dateTimePicker1.MinDate = new DateTime(thn, bln, tgl);
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            dateTimePicker1.Enabled = true;
            int thn = DateTime.Now.Year + vScrollBar2.Value;
            int tgl = DateTime.Now.Day;
            int bln = DateTime.Now.Month;
            label2.Text = thn.ToString();
            dateTimePicker1.MaxDate = new DateTime(thn, bln, tgl);
        }


    }
}
