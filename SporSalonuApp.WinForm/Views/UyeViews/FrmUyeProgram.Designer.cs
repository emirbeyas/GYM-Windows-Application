namespace SporSalonuApp.WinForm.Views.UyeViews
{
    partial class FrmUyeProgram
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblDivider = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTamam = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpBasTarih = new System.Windows.Forms.DateTimePicker();
            this.dtpBitisTarih = new System.Windows.Forms.DateTimePicker();
            this.chkAktif = new System.Windows.Forms.CheckBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Üye Program Bilgileri";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDivider
            // 
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDivider.Location = new System.Drawing.Point(10, 45);
            this.lblDivider.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(323, 2);
            this.lblDivider.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTamam);
            this.panel1.Controls.Add(this.btnIptal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 58);
            this.panel1.TabIndex = 35;
            // 
            // btnTamam
            // 
            this.btnTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTamam.Location = new System.Drawing.Point(222, 18);
            this.btnTamam.Margin = new System.Windows.Forms.Padding(4);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(100, 32);
            this.btnTamam.TabIndex = 31;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.UseVisualStyleBackColor = true;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(114, 18);
            this.btnIptal.Margin = new System.Windows.Forms.Padding(4);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(100, 32);
            this.btnIptal.TabIndex = 32;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label9.Location = new System.Drawing.Point(10, 278);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(323, 2);
            this.label9.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Başlangıç Tarihi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "Bitiş Tarihi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 41;
            this.label5.Text = "Açıklama :";
            // 
            // dtpBasTarih
            // 
            this.dtpBasTarih.Location = new System.Drawing.Point(132, 66);
            this.dtpBasTarih.Margin = new System.Windows.Forms.Padding(5);
            this.dtpBasTarih.Name = "dtpBasTarih";
            this.dtpBasTarih.Size = new System.Drawing.Size(200, 22);
            this.dtpBasTarih.TabIndex = 42;
            // 
            // dtpBitisTarih
            // 
            this.dtpBitisTarih.Location = new System.Drawing.Point(132, 98);
            this.dtpBitisTarih.Margin = new System.Windows.Forms.Padding(5);
            this.dtpBitisTarih.Name = "dtpBitisTarih";
            this.dtpBitisTarih.ShowCheckBox = true;
            this.dtpBitisTarih.Size = new System.Drawing.Size(200, 22);
            this.dtpBitisTarih.TabIndex = 43;
            // 
            // chkAktif
            // 
            this.chkAktif.AutoSize = true;
            this.chkAktif.Location = new System.Drawing.Point(132, 130);
            this.chkAktif.Margin = new System.Windows.Forms.Padding(5);
            this.chkAktif.Name = "chkAktif";
            this.chkAktif.Size = new System.Drawing.Size(92, 20);
            this.chkAktif.TabIndex = 44;
            this.chkAktif.Text = "Aktif / Pasif";
            this.chkAktif.UseVisualStyleBackColor = true;
            this.chkAktif.CheckedChanged += new System.EventHandler(this.chkAktif_CheckedChanged);
            // 
            // txtAciklama
            // 
            this.txtAciklama.AcceptsReturn = true;
            this.txtAciklama.Location = new System.Drawing.Point(132, 160);
            this.txtAciklama.Margin = new System.Windows.Forms.Padding(5);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(198, 99);
            this.txtAciklama.TabIndex = 45;
            // 
            // FrmUyeProgram
            // 
            this.AcceptButton = this.btnTamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(343, 338);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.chkAktif);
            this.Controls.Add(this.dtpBitisTarih);
            this.Controls.Add(this.dtpBasTarih);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUyeProgram";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmUyeProgram";
            this.Load += new System.EventHandler(this.FrmUyeProgram_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpBasTarih;
        private System.Windows.Forms.DateTimePicker dtpBitisTarih;
        private System.Windows.Forms.CheckBox chkAktif;
        private System.Windows.Forms.TextBox txtAciklama;
    }
}