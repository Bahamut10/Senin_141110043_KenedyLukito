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
using System.IO;
namespace Latihan_4_1
{
    public partial class Form1 : Form
    {
        public bool saveStatus = true;
        public string savename = "";
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
            foreach (PropertyInfo c in propInfoList)
            {
                this.bckgrdColor.Items.Add(c.Name);
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
            this.bckgrdColor.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            foreach (PropertyInfo c in colour)
            {
                if (c.PropertyType == typeof(System.Drawing.Color))
                {
                    fcolor.Items.Add(c.Name);
                }
            }
            this.fcolor.ComboBox.DrawItem += new DrawItemEventHandler(fcolor_DrawItem);
            this.bckgrdColor.ComboBox.DrawItem += new DrawItemEventHandler(bckgrdColor_DrawItem);

            string ss = "Times New Roman";
            fsize.Text = "12";
            fcolor.Text = "Black";
            //MessageBox.Show(richTextBox1.SelectionFont.FontFamily.Name);
            richTextBox1.Font = new Font(ss, 12f);
            boldButton.CheckOnClick = true;
            italicButton.CheckOnClick = true;
            underlineButton.CheckOnClick = true;
        }
        private void fcolor_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.fcolor.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();

        }
        private void bckgrdColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.fcolor.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();

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
        private void bckgrdColor_typing(object sender, EventArgs e)
        {
            bgColor();
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
        private void bckgrdColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgColor();
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
                bckgrdColor.Text = richTextBox1.SelectionBackColor.Name;
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Bold")>=0) boldButton.Checked = true;
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Italic") >= 0) italicButton.Checked = true;
                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Underline") >= 0) underlineButton.Checked = true;
            }
            else
            {
                fsize.Text = "";
                ffamily.Text = "";
                fcolor.Text = "";
                bckgrdColor.Text = "";
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
                    //richTextBox1.Focus();
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
        private void bgColor()
        {
            richTextBox1.SelectionBackColor = Color.FromName(bckgrdColor.Text);
        }
        private void styling()
        {
            int start = richTextBox1.SelectionStart;
            int finish = richTextBox1.SelectionLength;
            try
            {
                string fstring = ffamily.Text;
                ffamily.Text = fstring;
                if (finish != 0)
                {
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
                else
                {
                    Font font = new Font(fstring, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                    richTextBox1.SelectionFont = font;
                    //richTextBox1.Focus();
                }
            }
            catch
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ffamily.Text = "Times New Roman";
            bckgrdColor.Text = "White";
            bgColor();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            saveStatus = false;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveStatus == false)
            {
                DialogResult dialogresult = MessageBox.Show("Do you want to save this file?", "Are You Sure?", MessageBoxButtons.YesNoCancel);
                if (dialogresult == DialogResult.Yes) save();
                else if (dialogresult == DialogResult.Cancel) return;
                else richTextBox1.Clear();
            }
            else
                richTextBox1.Clear();
            //saveStatus = false;
            savename = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = "*.rtf";
            open.Filter = "RTF files|*.rtf";
            if (saveStatus == false)
            {
                DialogResult dialogresult = MessageBox.Show("Do you want to save this file?", "Are You Sure?", MessageBoxButtons.YesNo);
                if (dialogresult == DialogResult.Yes)
                {
                    save();
                    //1
                    if (open.ShowDialog() == DialogResult.OK && open.FileName.Length > 0)
                    {
                        StreamReader read = new StreamReader(open.FileName);
                        richTextBox1.Rtf = read.ReadToEnd();
                        read.Close();
                        richTextBox1.SelectionStart = richTextBox1.SelectionLength;
                    }
                }
                else
                {
                    //2
                    if (open.ShowDialog() == DialogResult.OK && open.FileName.Length > 0)
                    {
                        StreamReader read = new StreamReader(open.FileName);
                        richTextBox1.Rtf = read.ReadToEnd();
                        read.Close();
                        richTextBox1.SelectionStart = richTextBox1.SelectionLength;
                    }
                }
            }
            else
            {
                if (open.ShowDialog() == DialogResult.OK && open.FileName.Length > 0)
                {
                    StreamReader read = new StreamReader(open.FileName);
                    richTextBox1.Rtf = read.ReadToEnd();
                    read.Close();
                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                }
            }
            savename = open.FileName;
            saveStatus = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveStatus == false)
                save();
            else
            { }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit();
        }
        private void save()
        {
            if( savename == "")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "RTF files|*.rtf";
                save.Title = "Save as...";
                save.DefaultExt = "*.rtf";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.RichText);
                    savename = save.FileName;
                }
            }
            else if (savename != "")
            {
                richTextBox1.SaveFile(savename);
            }
            saveStatus = true;
        }
        private void exit()
        {
            if (saveStatus == false)
            {
                DialogResult dialogresult = MessageBox.Show("Do you want to save this file?", "Are You Sure?", MessageBoxButtons.YesNoCancel);
                if (dialogresult == DialogResult.Yes)
                {
                    save();
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    return;
                }
                else
                    Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            richTextBox1.Height = this.Height - 110;
            richTextBox1.Width = this.Width - 26;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit();
        }
    }
}
