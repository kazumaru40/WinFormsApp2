using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp2
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();

            // headerフォームのインスタンスを作成してメインフォームに追加
            HeaderForm headerForm = new HeaderForm();
            headerForm.TopLevel = false;  // 子フォームとしてメインフォーム内に表示
            headerForm.Dock = DockStyle.Top;  // 上部に配置
            this.Controls.Add(headerForm);
            headerForm.Show();  // フォームを表示
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {

        }

    }
}
