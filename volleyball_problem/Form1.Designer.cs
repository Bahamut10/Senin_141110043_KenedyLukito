namespace volleyball_problem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Txt1 = new System.Windows.Forms.TextBox();
            this.Txt2 = new System.Windows.Forms.TextBox();
            this.BtnHitung = new System.Windows.Forms.Button();
            this.TxtHasil = new System.Windows.Forms.TextBox();
            this.Lbl1 = new System.Windows.Forms.Label();
            this.Lbl2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Txt1
            // 
            this.Txt1.Location = new System.Drawing.Point(12, 15);
            this.Txt1.Name = "Txt1";
            this.Txt1.Size = new System.Drawing.Size(200, 20);
            this.Txt1.TabIndex = 0;
            // 
            // Txt2
            // 
            this.Txt2.Location = new System.Drawing.Point(12, 53);
            this.Txt2.Name = "Txt2";
            this.Txt2.Size = new System.Drawing.Size(200, 20);
            this.Txt2.TabIndex = 1;
            // 
            // BtnHitung
            // 
            this.BtnHitung.Location = new System.Drawing.Point(246, 16);
            this.BtnHitung.Name = "BtnHitung";
            this.BtnHitung.Size = new System.Drawing.Size(132, 52);
            this.BtnHitung.TabIndex = 2;
            this.BtnHitung.Text = "Hitung";
            this.BtnHitung.UseVisualStyleBackColor = true;
            this.BtnHitung.Click += new System.EventHandler(this.BtnHitung_Click);
            // 
            // TxtHasil
            // 
            this.TxtHasil.Enabled = false;
            this.TxtHasil.Location = new System.Drawing.Point(12, 98);
            this.TxtHasil.Name = "TxtHasil";
            this.TxtHasil.Size = new System.Drawing.Size(366, 20);
            this.TxtHasil.TabIndex = 3;
            // 
            // Lbl1
            // 
            this.Lbl1.AutoSize = true;
            this.Lbl1.Location = new System.Drawing.Point(12, -1);
            this.Lbl1.Name = "Lbl1";
            this.Lbl1.Size = new System.Drawing.Size(41, 13);
            this.Lbl1.TabIndex = 4;
            this.Lbl1.Text = "Score I";
            // 
            // Lbl2
            // 
            this.Lbl2.AutoSize = true;
            this.Lbl2.Location = new System.Drawing.Point(15, 37);
            this.Lbl2.Name = "Lbl2";
            this.Lbl2.Size = new System.Drawing.Size(44, 13);
            this.Lbl2.TabIndex = 5;
            this.Lbl2.Text = "Score II";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Jumlah Permainan";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 130);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl2);
            this.Controls.Add(this.Lbl1);
            this.Controls.Add(this.TxtHasil);
            this.Controls.Add(this.BtnHitung);
            this.Controls.Add(this.Txt2);
            this.Controls.Add(this.Txt1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt1;
        private System.Windows.Forms.TextBox Txt2;
        private System.Windows.Forms.Button BtnHitung;
        private System.Windows.Forms.TextBox TxtHasil;
        private System.Windows.Forms.Label Lbl1;
        private System.Windows.Forms.Label Lbl2;
        private System.Windows.Forms.Label label1;
    }
}

