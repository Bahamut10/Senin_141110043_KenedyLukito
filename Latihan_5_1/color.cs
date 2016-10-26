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

namespace Latihan_5_1
{
    public partial class color : Form
    {
        public static string textWarna { set; get; }

        Form1 mainform = (Form1)Form1.ActiveForm;
        //Form1 mainform;
        public color()
        {
            InitializeComponent();
            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.rtbbckColor.Items.Add(c.Name);
            }
            this.rtbbckColor.DrawMode = DrawMode.OwnerDrawFixed;
            this.rtbbckColor.DrawItem += new DrawItemEventHandler(rtbbckColor_DrawItem);
        }
        private void rtbbckColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.rtbbckColor.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }
        private void rtbbckColor_SelectedIndexChanged(object sender, EventArgs e)
        {
             textWarna= rtbbckColor.Text;   
        }
        private void OK_Click(object sender, EventArgs e)
        {
            mainform.rtbcolor = rtbbckColor.Text;
            if(mainform.rtbcolor!="Transparent")
            {
                mainform.saveStatus = false;
            }
            this.Dispose();
            mainform.hideshow();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mainform.hideshow();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode==treeView1.Nodes[0].Nodes[0])
            {
                //panel1.BackColor = Color.Red;
                panel1.Show();
            }
            else panel1.Hide();
        }

        private void color_Load(object sender, EventArgs e)
        {
            rtbbckColor.Text = mainform.rtbcolor;
        }

        private void color_Resize(object sender, EventArgs e)
        {
            treeView1.Height = this.Height;
        }
    }
}
