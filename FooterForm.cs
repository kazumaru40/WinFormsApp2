using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class FooterForm : Form
    {
        public FooterForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // ウィンドウフレームを非表示にする
        }

        private void footer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void footerpanel_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
