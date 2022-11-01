namespace SporSalonuApp.WinForm.Views
{
    partial class MainView
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
            this.lblDivider = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.infoUyeAdet = new SporSalonuApp.WinForm.UserControls.InfoBox();
            this.infoEgzersizAdet = new SporSalonuApp.WinForm.UserControls.InfoBox();
            this.infoAktifProgAdet = new SporSalonuApp.WinForm.UserControls.InfoBox();
            this.infoKullanıcıAdet = new SporSalonuApp.WinForm.UserControls.InfoBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(1190, 37);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Ana Sayfa";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDivider
            // 
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDivider.Location = new System.Drawing.Point(0, 47);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(1190, 2);
            this.lblDivider.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(0, 295);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(1190, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "Bugün Antrenmanı Olan Üyeler";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1170, 361);
            this.dataGridView1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 332);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel2.Size = new System.Drawing.Size(1190, 361);
            this.panel2.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.infoUyeAdet);
            this.flowLayoutPanel1.Controls.Add(this.infoEgzersizAdet);
            this.flowLayoutPanel1.Controls.Add(this.infoAktifProgAdet);
            this.flowLayoutPanel1.Controls.Add(this.infoKullanıcıAdet);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 49);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1190, 244);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // infoUyeAdet
            // 
            this.infoUyeAdet.IconBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.infoUyeAdet.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.infoUyeAdet.IconColor = System.Drawing.Color.White;
            this.infoUyeAdet.InfoBoxBackColor = System.Drawing.SystemColors.Control;
            this.infoUyeAdet.Location = new System.Drawing.Point(15, 15);
            this.infoUyeAdet.Margin = new System.Windows.Forms.Padding(5);
            this.infoUyeAdet.Name = "infoUyeAdet";
            this.infoUyeAdet.Size = new System.Drawing.Size(300, 102);
            this.infoUyeAdet.TabIndex = 3;
            this.infoUyeAdet.Title = "Üye Sayısı";
            this.infoUyeAdet.Value = "120";
            // 
            // infoEgzersizAdet
            // 
            this.infoEgzersizAdet.IconBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(90)))));
            this.infoEgzersizAdet.IconChar = FontAwesome.Sharp.IconChar.Running;
            this.infoEgzersizAdet.IconColor = System.Drawing.Color.White;
            this.infoEgzersizAdet.InfoBoxBackColor = System.Drawing.SystemColors.Control;
            this.infoEgzersizAdet.Location = new System.Drawing.Point(325, 15);
            this.infoEgzersizAdet.Margin = new System.Windows.Forms.Padding(5);
            this.infoEgzersizAdet.Name = "infoEgzersizAdet";
            this.infoEgzersizAdet.Size = new System.Drawing.Size(300, 102);
            this.infoEgzersizAdet.TabIndex = 4;
            this.infoEgzersizAdet.Title = "Egzersiz Sayısı";
            this.infoEgzersizAdet.Value = "120";
            // 
            // infoAktifProgAdet
            // 
            this.infoAktifProgAdet.IconBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(75)))), ((int)(((byte)(57)))));
            this.infoAktifProgAdet.IconChar = FontAwesome.Sharp.IconChar.Dumbbell;
            this.infoAktifProgAdet.IconColor = System.Drawing.Color.White;
            this.infoAktifProgAdet.InfoBoxBackColor = System.Drawing.SystemColors.Control;
            this.infoAktifProgAdet.Location = new System.Drawing.Point(635, 15);
            this.infoAktifProgAdet.Margin = new System.Windows.Forms.Padding(5);
            this.infoAktifProgAdet.Name = "infoAktifProgAdet";
            this.infoAktifProgAdet.Size = new System.Drawing.Size(300, 102);
            this.infoAktifProgAdet.TabIndex = 5;
            this.infoAktifProgAdet.Title = "Aktif Program Sayısı";
            this.infoAktifProgAdet.Value = "120";
            // 
            // infoKullanıcıAdet
            // 
            this.infoKullanıcıAdet.IconBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.infoKullanıcıAdet.IconChar = FontAwesome.Sharp.IconChar.UserCog;
            this.infoKullanıcıAdet.IconColor = System.Drawing.Color.White;
            this.infoKullanıcıAdet.InfoBoxBackColor = System.Drawing.SystemColors.Control;
            this.infoKullanıcıAdet.Location = new System.Drawing.Point(15, 127);
            this.infoKullanıcıAdet.Margin = new System.Windows.Forms.Padding(5);
            this.infoKullanıcıAdet.Name = "infoKullanıcıAdet";
            this.infoKullanıcıAdet.Size = new System.Drawing.Size(300, 102);
            this.infoKullanıcıAdet.TabIndex = 6;
            this.infoKullanıcıAdet.Title = "Kullanıcı Sayısı";
            this.infoKullanıcıAdet.Value = "120";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1190, 2);
            this.label1.TabIndex = 17;
            // 
            // MainView
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblDivider);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "MainView";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.Size = new System.Drawing.Size(1190, 703);
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UserControls.InfoBox infoUyeAdet;
        private UserControls.InfoBox infoEgzersizAdet;
        private UserControls.InfoBox infoAktifProgAdet;
        private UserControls.InfoBox infoKullanıcıAdet;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDivider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}
