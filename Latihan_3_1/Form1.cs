using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;

namespace Latihan_3_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Color color = new Color();
            PropertyInfo[] colour = color.GetType().GetProperties();

            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.fcolor.Items.Add(c.Name);
            }

            List<string> fonts = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
            }

            foreach(string k in fonts)
            {
                ffamily.Items.Add(k);
            }
            for (int i=8;i<=72;i++)
            {
                fsize.Items.Add(i);
            }

            this.fcolor.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            foreach (PropertyInfo c in colour)
            {
                if (c.PropertyType == typeof(System.Drawing.Color))
                {
                    fcolor.Items.Add(c.Name);
                }
            }
            this.fcolor.ComboBox.DrawItem += new DrawItemEventHandler(fcolor_DrawItem);

            string ss = "Times New Roman";
            fsize.Text = "12";
            fcolor.Text = "Black";
            //MessageBox.Show(richTextBox1.SelectionFont.FontFamily.Name);
            richTextBox1.Font = new Font(ss, 12);
            boldButton.CheckOnClick = true;
            italicButton.CheckOnClick = true;
            underlineButton.CheckOnClick = true;
        }
        private void fcolor_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Calibri", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5,
                                rect.Width - 10, rect.Height - 10);
            }

        }

        private void fsize_typing(object sender, EventArgs e)
        {
            size();
        }
        private void ffamily_typing(object sender, EventArgs e)
        {
            styling();
        }
        private void fcolor_typing(object sender, EventArgs e)
        {
            color();
        }
        private void fsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox fokus = (ToolStripComboBox)sender;
            if (!fokus.Focused) return;
            size();
        }
        private void ffamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            styling();
        }
        private void fcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            color();
        }
        private void boldButton_Click_1(object sender, EventArgs e)
        {
            System.Drawing.FontStyle state = (boldButton.Checked) ? FontStyle.Bold : FontStyle.Regular;
            state |= (italicButton.Checked) ? FontStyle.Italic : FontStyle.Regular;
            state |= (underlineButton.Checked) ? FontStyle.Underline : FontStyle.Regular;
            int start = richTextBox1.SelectionStart;
            int finish = richTextBox1.SelectionLength;
             
            if (finish != 0)
            {
                
                for (int i = start; i < start + finish; i++)
                {
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = 1;
                    Font font = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, state);
                    richTextBox1.SelectionFont = font;
                }
                richTextBox1.SelectionStart = start;
                richTextBox1.SelectionLength = finish;
            }
            else
            {
                Font font = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, state);
                richTextBox1.SelectionFont = font;
            }
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            System.Drawing.FontStyle state = (boldButton.Checked) ? FontStyle.Bold : FontStyle.Regular;
            state |= (italicButton.Checked) ? FontStyle.Italic : FontStyle.Regular;
            state |= (underlineButton.Checked) ? FontStyle.Underline : FontStyle.Regular;
            int start = richTextBox1.SelectionStart;
            int finish = richTextBox1.SelectionLength;
            if (finish != 0)
            {
                for (int i = start; i < start + finish; i++)
                {
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = 1;
                    Font font = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, state);
                    richTextBox1.SelectionFont = font;
                }
                richTextBox1.SelectionStart = start;
                richTextBox1.SelectionLength = finish;
            }
            else
            {
                Font font = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, state);
                richTextBox1.SelectionFont = font;
            }
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            System.Drawing.FontStyle state = (boldButton.Checked) ? FontStyle.Bold : FontStyle.Regular;
            state |= (italicButton.Checked) ? FontStyle.Italic : FontStyle.Regular;
            state |= (underlineButton.Checked) ? FontStyle.Underline : FontStyle.Regular;
            int start = richTextBox1.SelectionStart;
            int finish = richTextBox1.SelectionLength;
            if (finish != 0)
            {
                for (int i = start; i < start + finish; i++)
                {
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = 1;
                    Font font = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, state);
                    richTextBox1.SelectionFont = font;
                }
                richTextBox1.SelectionStart = start;
                richTextBox1.SelectionLength = finish;
            }
            else
            {
                Font font = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, state);
                richTextBox1.SelectionFont = font;
            }
        }
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            boldButton.Checked = false;
            italicButton.Checked = false;
            underlineButton.Checked = false;
            if(richTextBox1.SelectionFont!=null)
            {
                fsize.Text = richTextBox1.SelectionFont.Size.ToString();
                ffamily.Text = richTextBox1.SelectionFont.FontFamily.Name;
                fcolor.Text = richTextBox1.SelectionColor.Name;
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Bold")>=0) boldButton.Checked = true;
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Italic") >= 0) italicButton.Checked = true;
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Underline") >= 0) underlineButton.Checked = true;
            }
            else
            {
                fsize.Text = "";
                ffamily.Text = "";
                //fcolor.Text = "";
            }

        }        
        private void size()
        {
            int start = richTextBox1.SelectionStart;
            int finish = richTextBox1.SelectionLength;
            try
            {
                float fs = (fsize.Text == "") ? 12 : Convert.ToSingle(fsize.Text);
                if (finish != 0)
                {
                    for (int i = start; i < start + finish; i++)
                    {
                        richTextBox1.SelectionStart = i;
                        richTextBox1.SelectionLength = 1;
                        Font font = new Font(richTextBox1.SelectionFont.FontFamily, fs, richTextBox1.SelectionFont.Style);
                        richTextBox1.SelectionFont = font;
                    }
                    richTextBox1.SelectionStart = start;
                    richTextBox1.SelectionLength = finish;
                }
                else
                {
                    Font font = new Font(richTextBox1.SelectionFont.FontFamily, fs, richTextBox1.SelectionFont.Style);
                    richTextBox1.SelectionFont = font;
                    richTextBox1.Focus();
                }
            }
            catch
            {
                return;
            }
        }
        private void color()
        {
            richTextBox1.SelectionColor = Color.FromName(fcolor.Text);
            //richTextBox1.Focus();
        }
        private void styling()
        {
            int start = richTextBox1.SelectionStart;
            int finish = richTextBox1.SelectionLength;
            try
            {
                string fstring = ffamily.Text;
                ffamily.Text = fstring;
                for (int i = start; i < start + finish; i++)
                {
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = 1;
                    Font font = new Font(fstring, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                    richTextBox1.SelectionFont = font;
                }
                richTextBox1.SelectionStart = start;
                richTextBox1.SelectionLength = finish;
            }
            catch
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ffamily.Text = "Times New Roman";
        }     
    }
}
