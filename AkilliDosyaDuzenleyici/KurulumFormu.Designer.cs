namespace AkilliDosyaDuzenleyici
{
    partial class KurulumFormu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KurulumFormu));
            this.lblBaslik = new System.Windows.Forms.Label();
            this.txtKlasorYolu = new System.Windows.Forms.TextBox();
            this.btnGozat = new System.Windows.Forms.Button();
            this.chkOtoBaslat = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBaslik.Location = new System.Drawing.Point(62, 43);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(238, 20);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Düzenlenecek Ana Klasörü Seçin:";
            // 
            // txtKlasorYolu
            // 
            this.txtKlasorYolu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtKlasorYolu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKlasorYolu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtKlasorYolu.Location = new System.Drawing.Point(62, 84);
            this.txtKlasorYolu.Name = "txtKlasorYolu";
            this.txtKlasorYolu.Size = new System.Drawing.Size(290, 25);
            this.txtKlasorYolu.TabIndex = 1;
            // 
            // btnGozat
            // 
            this.btnGozat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnGozat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGozat.FlatAppearance.BorderSize = 0;
            this.btnGozat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGozat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGozat.Location = new System.Drawing.Point(362, 83);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(85, 27);
            this.btnGozat.TabIndex = 2;
            this.btnGozat.Text = "Göz At";
            this.btnGozat.UseVisualStyleBackColor = false;
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // chkOtoBaslat
            // 
            this.chkOtoBaslat.AutoSize = true;
            this.chkOtoBaslat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkOtoBaslat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkOtoBaslat.Location = new System.Drawing.Point(62, 134);
            this.chkOtoBaslat.Name = "chkOtoBaslat";
            this.chkOtoBaslat.Size = new System.Drawing.Size(118, 21);
            this.chkOtoBaslat.TabIndex = 3;
            this.chkOtoBaslat.Text = "Otomatik Başlat";
            this.chkOtoBaslat.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(62, 194);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(385, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Kaydet ve Başlat";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Akıllı Dosya Düzenleyici";
            this.notifyIcon1.Visible = true;
            // 
            // KurulumFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(506, 304);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkOtoBaslat);
            this.Controls.Add(this.btnGozat);
            this.Controls.Add(this.txtKlasorYolu);
            this.Controls.Add(this.lblBaslik);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KurulumFormu";
            this.Text = "KurulumFormu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.TextBox txtKlasorYolu;
        private System.Windows.Forms.Button btnGozat;
        private System.Windows.Forms.CheckBox chkOtoBaslat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}