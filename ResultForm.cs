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
    public partial class ResultForm : Form
    {
        public string ResultMessage { get; set; }  // SlectFormからのメッセージを受け取る

        public ResultForm()
        {
            InitializeComponent();

            // headerのインスタンス
            HeaderForm headerForm = new HeaderForm();
            headerForm.TopLevel = false;  // メインフォーム内のサブフォームとして表示
            headerForm.Dock = DockStyle.Top;  // 上部に配置
            this.Controls.Add(headerForm);
            headerForm.Show();  // フォームを表示

            // footerフォームインスタンス
            FooterForm footerForm = new FooterForm();
            footerForm.TopLevel = false;  // メインフォーム内のサブフォームとして表示
            footerForm.Dock = DockStyle.Bottom;  // 下部に配置
            this.Controls.Add(footerForm);
            footerForm.Show();  // フォームを表示
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            label1.Text = ResultMessage;  // label1にメッセージを表示
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.mhlw.go.jp/mamorouyokokoro/",
                UseShellExecute = true
            });
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
