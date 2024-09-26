using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp2
{
    public partial class InformationForm : Form
    {
        public InformationForm()
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

        private void InformationForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Ａ あなたの仕事についてうかがいます。最もあてはまるものを選んでください。");
            SelectForm selectFrom = new SelectForm();
            selectFrom.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void SetTitle(string title)    //タイトルをA～Dを表示していく時に使う
        {
            label1.Text = title;
        }
    }
}
