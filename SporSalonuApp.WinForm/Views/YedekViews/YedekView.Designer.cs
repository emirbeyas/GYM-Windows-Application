namespace SporSalonuApp.WinForm.Views.YedekViews
{
    partial class YedekView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDısaAktarSatırAdet = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDısaAktarTabloAdı = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDısaAktar = new System.Windows.Forms.Button();
            this.btnListele = new System.Windows.Forms.Button();
            this.cbxTablo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.lblIceAktarSatırAdet = new System.Windows.Forms.ToolStripStatusLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblIceAktarTabloAdı = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDosyaYol = new System.Windows.Forms.TextBox();
            this.btnIceAktar = new System.Windows.Forms.Button();
            this.btnAc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnYedekle = new System.Windows.Forms.Button();
            this.btnYedektenDon = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(765, 37);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Yedek İşlemleri";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(765, 2);
            this.label1.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(70, 30);
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(745, 517);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnYedektenDon);
            this.tabPage3.Controls.Add(this.btnYedekle);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(737, 479);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Yedekle";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lblDısaAktarTabloAdı);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(737, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dışa Aktar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 114);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel3.Size = new System.Drawing.Size(717, 333);
            this.panel3.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(717, 323);
            this.dataGridView1.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDısaAktarSatırAdet});
            this.statusStrip1.Location = new System.Drawing.Point(10, 447);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(717, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDısaAktarSatırAdet
            // 
            this.lblDısaAktarSatırAdet.Name = "lblDısaAktarSatırAdet";
            this.lblDısaAktarSatırAdet.Size = new System.Drawing.Size(73, 17);
            this.lblDısaAktarSatırAdet.Text = "Satır Adet : 0";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(10, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(717, 2);
            this.label4.TabIndex = 3;
            // 
            // lblDısaAktarTabloAdı
            // 
            this.lblDısaAktarTabloAdı.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDısaAktarTabloAdı.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDısaAktarTabloAdı.Location = new System.Drawing.Point(10, 72);
            this.lblDısaAktarTabloAdı.Name = "lblDısaAktarTabloAdı";
            this.lblDısaAktarTabloAdı.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblDısaAktarTabloAdı.Size = new System.Drawing.Size(717, 40);
            this.lblDısaAktarTabloAdı.TabIndex = 2;
            this.lblDısaAktarTabloAdı.Text = "Tablo Adı :";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(10, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(717, 2);
            this.label3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDısaAktar);
            this.panel2.Controls.Add(this.btnListele);
            this.panel2.Controls.Add(this.cbxTablo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 60);
            this.panel2.TabIndex = 0;
            // 
            // btnDısaAktar
            // 
            this.btnDısaAktar.Enabled = false;
            this.btnDısaAktar.Location = new System.Drawing.Point(352, 14);
            this.btnDısaAktar.Name = "btnDısaAktar";
            this.btnDısaAktar.Size = new System.Drawing.Size(75, 23);
            this.btnDısaAktar.TabIndex = 2;
            this.btnDısaAktar.Text = "Dışa Aktar";
            this.btnDısaAktar.UseVisualStyleBackColor = true;
            this.btnDısaAktar.Click += new System.EventHandler(this.btnDısaAktar_Click);
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(271, 14);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(75, 23);
            this.btnListele.TabIndex = 2;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // cbxTablo
            // 
            this.cbxTablo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTablo.FormattingEnabled = true;
            this.cbxTablo.Location = new System.Drawing.Point(63, 16);
            this.cbxTablo.Name = "cbxTablo";
            this.cbxTablo.Size = new System.Drawing.Size(202, 21);
            this.cbxTablo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tablo :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.statusStrip2);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.lblIceAktarTabloAdı);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage2.Size = new System.Drawing.Size(737, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "İçe Aktar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(10, 114);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel5.Size = new System.Drawing.Size(717, 333);
            this.panel5.TabIndex = 6;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 10);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(717, 323);
            this.dataGridView2.TabIndex = 5;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblIceAktarSatırAdet});
            this.statusStrip2.Location = new System.Drawing.Point(10, 447);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(717, 22);
            this.statusStrip2.TabIndex = 5;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // lblIceAktarSatırAdet
            // 
            this.lblIceAktarSatırAdet.Name = "lblIceAktarSatırAdet";
            this.lblIceAktarSatırAdet.Size = new System.Drawing.Size(64, 17);
            this.lblIceAktarSatırAdet.Text = "Satır Adet :";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(10, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(717, 2);
            this.label8.TabIndex = 4;
            // 
            // lblIceAktarTabloAdı
            // 
            this.lblIceAktarTabloAdı.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIceAktarTabloAdı.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIceAktarTabloAdı.Location = new System.Drawing.Point(10, 72);
            this.lblIceAktarTabloAdı.Name = "lblIceAktarTabloAdı";
            this.lblIceAktarTabloAdı.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblIceAktarTabloAdı.Size = new System.Drawing.Size(717, 40);
            this.lblIceAktarTabloAdı.TabIndex = 3;
            this.lblIceAktarTabloAdı.Text = "Tablo Adı :";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(10, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(717, 2);
            this.label6.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtDosyaYol);
            this.panel4.Controls.Add(this.btnIceAktar);
            this.panel4.Controls.Add(this.btnAc);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(717, 60);
            this.panel4.TabIndex = 1;
            // 
            // txtDosyaYol
            // 
            this.txtDosyaYol.Location = new System.Drawing.Point(90, 16);
            this.txtDosyaYol.Name = "txtDosyaYol";
            this.txtDosyaYol.ReadOnly = true;
            this.txtDosyaYol.Size = new System.Drawing.Size(288, 20);
            this.txtDosyaYol.TabIndex = 3;
            // 
            // btnIceAktar
            // 
            this.btnIceAktar.Enabled = false;
            this.btnIceAktar.Location = new System.Drawing.Point(465, 14);
            this.btnIceAktar.Name = "btnIceAktar";
            this.btnIceAktar.Size = new System.Drawing.Size(75, 23);
            this.btnIceAktar.TabIndex = 2;
            this.btnIceAktar.Text = "İçe Aktar";
            this.btnIceAktar.UseVisualStyleBackColor = true;
            this.btnIceAktar.Click += new System.EventHandler(this.btnIceAktar_Click);
            // 
            // btnAc
            // 
            this.btnAc.Location = new System.Drawing.Point(384, 14);
            this.btnAc.Name = "btnAc";
            this.btnAc.Size = new System.Drawing.Size(75, 23);
            this.btnAc.TabIndex = 2;
            this.btnAc.Text = "Aç";
            this.btnAc.UseVisualStyleBackColor = true;
            this.btnAc.Click += new System.EventHandler(this.btnAc_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Dosya Yolu :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(765, 537);
            this.panel1.TabIndex = 11;
            // 
            // btnYedekle
            // 
            this.btnYedekle.Location = new System.Drawing.Point(26, 25);
            this.btnYedekle.Name = "btnYedekle";
            this.btnYedekle.Size = new System.Drawing.Size(111, 43);
            this.btnYedekle.TabIndex = 0;
            this.btnYedekle.Text = "Yedekle";
            this.btnYedekle.UseVisualStyleBackColor = true;
            this.btnYedekle.Click += new System.EventHandler(this.btnYedekle_Click);
            // 
            // btnYedektenDon
            // 
            this.btnYedektenDon.Location = new System.Drawing.Point(143, 25);
            this.btnYedektenDon.Name = "btnYedektenDon";
            this.btnYedektenDon.Size = new System.Drawing.Size(111, 43);
            this.btnYedektenDon.TabIndex = 1;
            this.btnYedektenDon.Text = "Yedekten Dön";
            this.btnYedektenDon.UseVisualStyleBackColor = true;
            this.btnYedektenDon.Click += new System.EventHandler(this.btnYedektenDon_Click);
            // 
            // YedekView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Name = "YedekView";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.Size = new System.Drawing.Size(765, 596);
            this.Load += new System.EventHandler(this.YedekView_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDısaAktarTabloAdı;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.ComboBox cbxTablo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDısaAktar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtDosyaYol;
        private System.Windows.Forms.Button btnIceAktar;
        private System.Windows.Forms.Button btnAc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIceAktarTabloAdı;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDısaAktarSatırAdet;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel lblIceAktarSatırAdet;
        private System.Windows.Forms.Button btnYedektenDon;
        private System.Windows.Forms.Button btnYedekle;
    }
}
