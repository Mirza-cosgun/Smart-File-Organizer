namespace AkilliDosyaDuzenleyici
{
    partial class GizliArkaPlanMotoru
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GizliArkaPlanMotoru));
            this.sagTikMenusu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nIconMotor = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // sagTikMenusu
            // 
            this.sagTikMenusu.Name = "sagTikMenusu";
            this.sagTikMenusu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.sagTikMenusu.Size = new System.Drawing.Size(61, 4);
            // 
            // nIconMotor
            // 
            this.nIconMotor.Icon = ((System.Drawing.Icon)(resources.GetObject("nIconMotor.Icon")));
            this.nIconMotor.Text = "Akıllı Dosya Düzenleyici";
            this.nIconMotor.Visible = true;
            // 
            // GizliArkaPlanMotoru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GizliArkaPlanMotoru";
            this.Text = "GizliArkaPlanMotoru";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip sagTikMenusu;
        private System.Windows.Forms.NotifyIcon nIconMotor;
    }
}