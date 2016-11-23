using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int hari = 0;
            int setahun = 365;
            DateTime day = new DateTime(2016, 1, 1);
            DateTime end = new DateTime(2016, 12, 31);
            while (hari < setahun)
            {
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    monthCalendar1.AddBoldedDate(day);
                }
                hari++;
                day = day.AddDays(1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            monthCalendar1.AddAnnuallyBoldedDate(new DateTime(2016,4,16));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (domainUpDown1.SelectedIndex + 1 == 2 && numericUpDown1.Value > 29)
            {
                MessageBox.Show("Inputted date is not available");
            }
            else if (domainUpDown1.SelectedIndex + 1 <= 7 && (domainUpDown1.SelectedIndex + 1) % 2 == 0 && numericUpDown1.Value > 30)
            {
                MessageBox.Show("Inputted date is not available");
            }
            else if (domainUpDown1.SelectedIndex + 1 > 7 && (domainUpDown1.SelectedIndex + 1) % 2 != 0 && numericUpDown1.Value > 30)
            {
                MessageBox.Show("Inputted date not available");
            }
            else if (numericUpDown1.Value > 1 && numericUpDown1.Value < 31)
            {
                monthCalendar1.AddAnnuallyBoldedDate(new DateTime(2016, domainUpDown1.SelectedIndex + 1, Convert.ToInt32(numericUpDown1.Value)));
                monthCalendar1.UpdateBoldedDates();
                monthCalendar1.SetDate(new DateTime(2016, domainUpDown1.SelectedIndex + 1, Convert.ToInt32(numericUpDown1.Value)));
            }
            else MessageBox.Show("Please, input valid data!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (domainUpDown1.SelectedIndex + 1 == 2 && numericUpDown1.Value > 29)
            {
                MessageBox.Show("Inputted date is not available");
            }
            else if (domainUpDown1.SelectedIndex + 1 <= 7 && (domainUpDown1.SelectedIndex + 1) % 2 == 0 && numericUpDown1.Value > 30)
            {
                MessageBox.Show("Inputted date is not available");
            }
            else if (domainUpDown1.SelectedIndex + 1 > 7 && (domainUpDown1.SelectedIndex + 1) % 2 != 0 && numericUpDown1.Value > 30)
            {
                MessageBox.Show("Inputted date is not available");
            }
            else if (numericUpDown1.Value > 1 && numericUpDown1.Value < 31)
            {
                DateTime hilang = monthCalendar1.SelectionRange.Start.Date;
                monthCalendar1.RemoveAnnuallyBoldedDate(hilang);
                monthCalendar1.UpdateBoldedDates();
            }
            else MessageBox.Show("Please, input a valid data!!!");
            
        }
    }
}
