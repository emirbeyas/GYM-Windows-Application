namespace SporSalonuApp.WinForm.Views.KullanıcıViews
{
    partial class FrmKullanıcıYetkileri
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDivider = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTamam = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.cbxTablolar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkListele = new System.Windows.Forms.CheckBox();
            this.chkEkle = new System.Windows.Forms.CheckBox();
            this.chkSil = new System.Windows.Forms.CheckBox();
            this.chkGuncelle = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(280, 37);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Kullanıcı Yetki Ayarları";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDivider
            // 
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDivider.Location = new System.Drawing.Point(10, 47);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(280, 2);
            this.lblDivider.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIptal);
            this.panel1.Controls.Add(this.btnTamam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 50);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(10, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 2);
            this.label1.TabIndex = 8;
            // 
            // btnTamam
            // 
            this.btnTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTamam.Location = new System.Drawing.Point(202, 15);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(75, 23);
            this.btnTamam.TabIndex = 0;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.UseVisualStyleBackColor = true;
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(121, 15);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 23);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            // 
            // cbxTablolar
            // 
            this.cbxTablolar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTablolar.FormattingEnabled = true;
            this.cbxTablolar.Location = new System.Drawing.Point(87, 68);
            this.cbxTablolar.Name = "cbxTablolar";
            this.cbxTablolar.Size = new System.Drawing.Size(166, 21);
            this.cbxTablolar.TabIndex = 9;
            this.cbxTablolar.SelectedIndexChanged += new System.EventHandler(this.cbxTablolar_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tablo Adı :";
            // 
            // chkListele
            // 
            this.chkListele.AutoSize = true;
            this.chkListele.Location = new System.Drawing.Point(93, 106);
            this.chkListele.Name = "chkListele";
            this.chkListele.Size = new System.Drawing.Size(56, 17);
            this.chkListele.TabIndex = 11;
            this.chkListele.Text = "Listele";
            this.chkListele.UseVisualStyleBackColor = true;
            this.chkListele.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // chkEkle
            // 
            this.chkEkle.AutoSize = true;
            this.chkEkle.Location = new System.Drawing.Point(93, 129);
            this.chkEkle.Name = "chkEkle";
            this.chkEkle.Size = new System.Drawing.Size(47, 17);
            this.chkEkle.TabIndex = 12;
            this.chkEkle.Text = "Ekle";
            this.chkEkle.UseVisualStyleBackColor = true;
            this.chkEkle.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // chkSil
            // 
            this.chkSil.AutoSize = true;
            this.chkSil.Location = new System.Drawing.Point(170, 106);
            this.chkSil.Name = "chkSil";
            this.chkSil.Size = new System.Drawing.Size(37, 17);
            this.chkSil.TabIndex = 13;
            this.chkSil.Text = "Sil";
            this.chkSil.UseVisualStyleBackColor = true;
            this.chkSil.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // chkGuncelle
            // 
            this.chkGuncelle.AutoSize = true;
            this.chkGuncelle.Location = new System.Drawing.Point(170, 129);
            this.chkGuncelle.Name = "chkGuncelle";
            this.chkGuncelle.Size = new System.Drawing.Size(68, 17);
            this.chkGuncelle.TabIndex = 14;
            this.chkGuncelle.Text = "Güncelle";
            this.chkGuncelle.UseVisualStyleBackColor = true;
            this.chkGuncelle.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // FrmKullanıcıYetkileri
            // 
            this.AcceptButton = this.btnTamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(300, 226);
            this.Controls.Add(this.chkGuncelle);
            this.Controls.Add(this.chkSil);
            this.Controls.Add(this.chkEkle);
            this.Controls.Add(this.chkListele);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxTablolar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKullanıcıYetkileri";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmKullanıcıYetkileri";
            this.Load += new System.EventHandler(this.FrmKullanıcıYetkileri_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTablolar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkListele;
        private System.Windows.Forms.CheckBox chkEkle;
        private System.Windows.Forms.CheckBox chkSil;
        private System.Windows.Forms.CheckBox chkGuncelle;
    }
}