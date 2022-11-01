using FontAwesome.Sharp;

namespace SporSalonuApp.WinForm
{
    partial class MainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ıconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblActive = new System.Windows.Forms.Label();
            this.menuYedekIslemleri = new FontAwesome.Sharp.IconButton();
            this.menuKullanıcılar = new FontAwesome.Sharp.IconButton();
            this.menuOdemeler = new FontAwesome.Sharp.IconButton();
            this.menuEgzersizKategori = new FontAwesome.Sharp.IconButton();
            this.menuEgzersizler = new FontAwesome.Sharp.IconButton();
            this.menuUyeler = new FontAwesome.Sharp.IconButton();
            this.menuAnaSayfa = new FontAwesome.Sharp.IconButton();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ıconPictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlContainer, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 769F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1480, 769);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(186, 763);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ıconPictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 127);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.label1.Location = new System.Drawing.Point(0, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Spor Salonu App";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ıconPictureBox1
            // 
            this.ıconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.ıconPictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ıconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.ıconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Heartbeat;
            this.ıconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.ıconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconPictureBox1.IconSize = 119;
            this.ıconPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.ıconPictureBox1.Name = "ıconPictureBox1";
            this.ıconPictureBox1.Size = new System.Drawing.Size(180, 119);
            this.ıconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ıconPictureBox1.TabIndex = 0;
            this.ıconPictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(100)))), ((int)(((byte)(111)))));
            this.label2.Location = new System.Drawing.Point(3, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "MENÜ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblActive);
            this.panel2.Controls.Add(this.menuYedekIslemleri);
            this.panel2.Controls.Add(this.menuKullanıcılar);
            this.panel2.Controls.Add(this.menuOdemeler);
            this.panel2.Controls.Add(this.menuEgzersizKategori);
            this.panel2.Controls.Add(this.menuEgzersizler);
            this.panel2.Controls.Add(this.menuUyeler);
            this.panel2.Controls.Add(this.menuAnaSayfa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 593);
            this.panel2.TabIndex = 2;
            // 
            // lblActive
            // 
            this.lblActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.lblActive.Location = new System.Drawing.Point(0, 0);
            this.lblActive.Margin = new System.Windows.Forms.Padding(0);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(8, 50);
            this.lblActive.TabIndex = 4;
            // 
            // menuYedekIslemleri
            // 
            this.menuYedekIslemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuYedekIslemleri.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuYedekIslemleri.FlatAppearance.BorderSize = 0;
            this.menuYedekIslemleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuYedekIslemleri.ForeColor = System.Drawing.Color.White;
            this.menuYedekIslemleri.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.menuYedekIslemleri.IconColor = System.Drawing.Color.White;
            this.menuYedekIslemleri.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuYedekIslemleri.IconSize = 40;
            this.menuYedekIslemleri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuYedekIslemleri.Location = new System.Drawing.Point(0, 300);
            this.menuYedekIslemleri.Name = "menuYedekIslemleri";
            this.menuYedekIslemleri.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.menuYedekIslemleri.Size = new System.Drawing.Size(180, 50);
            this.menuYedekIslemleri.TabIndex = 8;
            this.menuYedekIslemleri.Text = "Yedek İşlemleri";
            this.menuYedekIslemleri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuYedekIslemleri.UseVisualStyleBackColor = true;
            this.menuYedekIslemleri.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // menuKullanıcılar
            // 
            this.menuKullanıcılar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuKullanıcılar.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuKullanıcılar.FlatAppearance.BorderSize = 0;
            this.menuKullanıcılar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuKullanıcılar.ForeColor = System.Drawing.Color.White;
            this.menuKullanıcılar.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            this.menuKullanıcılar.IconColor = System.Drawing.Color.White;
            this.menuKullanıcılar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuKullanıcılar.IconSize = 40;
            this.menuKullanıcılar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuKullanıcılar.Location = new System.Drawing.Point(0, 250);
            this.menuKullanıcılar.Name = "menuKullanıcılar";
            this.menuKullanıcılar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.menuKullanıcılar.Size = new System.Drawing.Size(180, 50);
            this.menuKullanıcılar.TabIndex = 7;
            this.menuKullanıcılar.Text = "Kullanıcılar";
            this.menuKullanıcılar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuKullanıcılar.UseVisualStyleBackColor = true;
            this.menuKullanıcılar.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // menuOdemeler
            // 
            this.menuOdemeler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuOdemeler.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuOdemeler.FlatAppearance.BorderSize = 0;
            this.menuOdemeler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuOdemeler.ForeColor = System.Drawing.Color.White;
            this.menuOdemeler.IconChar = FontAwesome.Sharp.IconChar.LiraSign;
            this.menuOdemeler.IconColor = System.Drawing.Color.White;
            this.menuOdemeler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuOdemeler.IconSize = 40;
            this.menuOdemeler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuOdemeler.Location = new System.Drawing.Point(0, 200);
            this.menuOdemeler.Name = "menuOdemeler";
            this.menuOdemeler.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.menuOdemeler.Size = new System.Drawing.Size(180, 50);
            this.menuOdemeler.TabIndex = 6;
            this.menuOdemeler.Text = "Ödemeler";
            this.menuOdemeler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuOdemeler.UseVisualStyleBackColor = true;
            this.menuOdemeler.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // menuEgzersizKategori
            // 
            this.menuEgzersizKategori.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuEgzersizKategori.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuEgzersizKategori.FlatAppearance.BorderSize = 0;
            this.menuEgzersizKategori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuEgzersizKategori.ForeColor = System.Drawing.Color.White;
            this.menuEgzersizKategori.IconChar = FontAwesome.Sharp.IconChar.Sitemap;
            this.menuEgzersizKategori.IconColor = System.Drawing.Color.White;
            this.menuEgzersizKategori.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuEgzersizKategori.IconSize = 40;
            this.menuEgzersizKategori.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuEgzersizKategori.Location = new System.Drawing.Point(0, 150);
            this.menuEgzersizKategori.Name = "menuEgzersizKategori";
            this.menuEgzersizKategori.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.menuEgzersizKategori.Size = new System.Drawing.Size(180, 50);
            this.menuEgzersizKategori.TabIndex = 5;
            this.menuEgzersizKategori.Text = "Egzersiz Kategori";
            this.menuEgzersizKategori.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuEgzersizKategori.UseVisualStyleBackColor = true;
            this.menuEgzersizKategori.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // menuEgzersizler
            // 
            this.menuEgzersizler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuEgzersizler.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuEgzersizler.FlatAppearance.BorderSize = 0;
            this.menuEgzersizler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuEgzersizler.ForeColor = System.Drawing.Color.White;
            this.menuEgzersizler.IconChar = FontAwesome.Sharp.IconChar.Running;
            this.menuEgzersizler.IconColor = System.Drawing.Color.White;
            this.menuEgzersizler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuEgzersizler.IconSize = 40;
            this.menuEgzersizler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuEgzersizler.Location = new System.Drawing.Point(0, 100);
            this.menuEgzersizler.Name = "menuEgzersizler";
            this.menuEgzersizler.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.menuEgzersizler.Size = new System.Drawing.Size(180, 50);
            this.menuEgzersizler.TabIndex = 2;
            this.menuEgzersizler.Text = "Egzersizler";
            this.menuEgzersizler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuEgzersizler.UseVisualStyleBackColor = true;
            this.menuEgzersizler.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // menuUyeler
            // 
            this.menuUyeler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuUyeler.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuUyeler.FlatAppearance.BorderSize = 0;
            this.menuUyeler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuUyeler.ForeColor = System.Drawing.Color.White;
            this.menuUyeler.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.menuUyeler.IconColor = System.Drawing.Color.White;
            this.menuUyeler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUyeler.IconSize = 40;
            this.menuUyeler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuUyeler.Location = new System.Drawing.Point(0, 50);
            this.menuUyeler.Name = "menuUyeler";
            this.menuUyeler.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.menuUyeler.Size = new System.Drawing.Size(180, 50);
            this.menuUyeler.TabIndex = 1;
            this.menuUyeler.Text = "Üyeler";
            this.menuUyeler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuUyeler.UseVisualStyleBackColor = true;
            this.menuUyeler.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // menuAnaSayfa
            // 
            this.menuAnaSayfa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuAnaSayfa.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuAnaSayfa.FlatAppearance.BorderSize = 0;
            this.menuAnaSayfa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuAnaSayfa.ForeColor = System.Drawing.Color.White;
            this.menuAnaSayfa.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.menuAnaSayfa.IconColor = System.Drawing.Color.White;
            this.menuAnaSayfa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAnaSayfa.IconSize = 40;
            this.menuAnaSayfa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAnaSayfa.Location = new System.Drawing.Point(0, 0);
            this.menuAnaSayfa.Name = "menuAnaSayfa";
            this.menuAnaSayfa.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.menuAnaSayfa.Size = new System.Drawing.Size(180, 50);
            this.menuAnaSayfa.TabIndex = 0;
            this.menuAnaSayfa.Text = "Ana Sayfa";
            this.menuAnaSayfa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuAnaSayfa.UseVisualStyleBackColor = true;
            this.menuAnaSayfa.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(202, 10);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(10);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1268, 749);
            this.pnlContainer.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 769);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ıconPictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private IconButton menuAnaSayfa;
        private IconButton menuEgzersizler;
        private IconButton menuUyeler;
        private System.Windows.Forms.Panel pnlContainer;
        private IconButton menuEgzersizKategori;
        private System.Windows.Forms.Label lblActive;
        private IconButton menuYedekIslemleri;
        private IconButton menuKullanıcılar;
        private IconButton menuOdemeler;
    }
}