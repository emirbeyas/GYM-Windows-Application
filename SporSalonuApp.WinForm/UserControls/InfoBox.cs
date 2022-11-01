using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace SporSalonuApp.WinForm.UserControls
{
    public partial class InfoBox : UserControl
    {
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public string Value
        {
            get { return lblValue.Text; }
            set { lblValue.Text = value; }
        }

        public Color IconBackgroundColor
        {
            get { return pnlIconBack.BackColor; }
            set { pnlIconBack.BackColor = value; }
        }

        public Color InfoBoxBackColor
        {
            get {return pnlBack.BackColor; }
            set { pnlBack.BackColor = value; }
        }

        public IconChar IconChar
        {
            get { return ıconPictureBox1.IconChar; }
            set { ıconPictureBox1.IconChar = value; }
        }

        public Color IconColor
        {
            get { return ıconPictureBox1.IconColor; }
            set { ıconPictureBox1.IconColor = value; }
        }

        public InfoBox()
        {
            InitializeComponent();
        }

        private void InfoBox_Resize(object sender, EventArgs e)
        {
            ıconPictureBox1.Top = pnlIconBack.Height / 2 - ıconPictureBox1.Height / 2;
            ıconPictureBox1.Left = pnlIconBack.Width / 2 - ıconPictureBox1.Width / 2;
        }
    }
}
