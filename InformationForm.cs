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
            try
            {
                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT 'あなたの仕事についてうかがいます' AS TITLE FROM question_title";

                using var reader = sql.ExecuteReader();
                if (reader.Read())

                {
                    label1.Text = reader["TITLE"].ToString(); // TITLE列の値を取得

                }
            }
            catch (SqlException ex)
            {
                Rdb.ErrorMessage(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectForm selectFrom = new SelectForm();
            selectFrom.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
