namespace SporSalonuApp.WinForm.Views.KullanıcıViews
{
    partial class FrmLogin
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
            this.lblError = new System.Windows.Forms.Label();
            this.txtKullanıcıadı = new System.Windows.Forms.TextBox();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.btnTamam = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.ıconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.ıconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.ıconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ıconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ıconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ıconPictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(53, 255);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(181, 13);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "* Kullannıcı Adı ya da Parola Hatalı !!!";
            this.lblError.Visible = false;
            // 
            // txtKullanıcıadı
            // 
            this.txtKullanıcıadı.Location = new System.Drawing.Point(56, 201);
            this.txtKullanıcıadı.Name = "txtKullanıcıadı";
            this.txtKullanıcıadı.Size = new System.Drawing.Size(215, 20);
            this.txtKullanıcıadı.TabIndex = 3;
            // 
            // txtParola
            // 
            this.txtParola.Location = new System.Drawing.Point(56, 227);
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(215, 20);
            this.txtParola.TabIndex = 4;
            this.txtParola.UseSystemPasswordChar = true;
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(196, 14);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(75, 23);
            this.btnTamam.TabIndex = 5;
            this.btnTamam.Text = "Giriş";
            this.btnTamam.UseVisualStyleBackColor = true;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(116, 14);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 23);
            this.btnIptal.TabIndex = 6;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // ıconPictureBox1
            // 
            this.ıconPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.ıconPictureBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.ıconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt;
            this.ıconPictureBox1.IconColor = System.Drawing.Color.SteelBlue;
            this.ıconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconPictureBox1.IconSize = 118;
            this.ıconPictureBox1.Location = new System.Drawing.Point(79, 32);
            this.ıconPictureBox1.Name = "ıconPictureBox1";
            this.ıconPictureBox1.Size = new System.Drawing.Size(136, 118);
            this.ıconPictureBox1.TabIndex = 7;
            this.ıconPictureBox1.TabStop = false;
            // 
            // ıconPictureBox2
            // 
            this.ıconPictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.ıconPictureBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ıconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.ıconPictureBox2.IconColor = System.Drawing.SystemColors.Highlight;
            this.ıconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconPictureBox2.IconSize = 20;
            this.ıconPictureBox2.Location = new System.Drawing.Point(26, 227);
            this.ıconPictureBox2.Name = "ıconPictureBox2";
            this.ıconPictureBox2.Size = new System.Drawing.Size(24, 20);
            this.ıconPictureBox2.TabIndex = 8;
            this.ıconPictureBox2.TabStop = false;
            // 
            // ıconPictureBox3
            // 
            this.ıconPictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.ıconPictureBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ıconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.ıconPictureBox3.IconColor = System.Drawing.SystemColors.Highlight;
            this.ıconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconPictureBox3.IconSize = 20;
            this.ıconPictureBox3.Location = new System.Drawing.Point(26, 201);
            this.ıconPictureBox3.Name = "ıconPictureBox3";
            this.ıconPictureBox3.Size = new System.Drawing.Size(24, 20);
            this.ıconPictureBox3.TabIndex = 9;
            this.ıconPictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(0, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 45);
            this.label1.TabIndex = 10;
            this.label1.Text = "Spor Salonu APP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 2);
            this.label2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ıconPictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 132);
            this.panel1.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 2);
            this.label4.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTamam);
            this.panel2.Controls.Add(this.btnIptal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 281);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 51);
            this.panel2.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Location = new System.Drawing.Point(0, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(291, 2);
            this.label5.TabIndex = 15;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnTamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(291, 332);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ıconPictureBox3);
            this.Controls.Add(this.ıconPictureBox2);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.txtKullanıcıadı);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmLogin";
            ((System.ComponentModel.ISupportInitialize)(this.ıconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ıconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ıconPictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtKullanıcıadı;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.Button btnIptal;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
    }
}