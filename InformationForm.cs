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

            // headerフォームのインスタンスを作成してメインフォームに追加
            HeaderForm headerForm = new HeaderForm();
            headerForm.TopLevel = false;  // 子フォームとしてメインフォーム内に表示
            headerForm.Dock = DockStyle.Top;  // 上部に配置
            this.Controls.Add(headerForm);
            headerForm.Show();  // フォームを表示

            // footerフォームのインスタンスを作成してメインフォームに追加
            FooterForm footerForm = new FooterForm();
            footerForm.TopLevel = false;  // 子フォームとしてメインフォーム内に表示
            footerForm.Dock = DockStyle.Bottom;  // 下部に配置
            this.Controls.Add(footerForm);
            footerForm.Show();  // フォームを表示
        }

        private void InformationForm_Load(object sender, EventArgs e)
        {
            // フォームのロード時に必要な初期化を行う
            LoadTitle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectForm selectForm = new SelectForm(); // 次の画面に遷移する処理
            selectForm.Show();
            this.Hide(); // 現在のフォームを隠す
        }

        private void LoadTitle()
        {
            try
            {
                // データベース接続
                using (var connection = Rdb.Conn)
                {
                    // クエリを作成
                    using (var command = new SqlCommand("SELECT TOP 1 TITLE FROM question_title WHERE Q_CATEGORY = 'A'", connection))
                    {
                        // クエリの結果取得
                        object result = command.ExecuteScalar();

                        // TextBox に表示                       
                        textBox1.Text = result.ToString();                  
                    }
                }
            }
            catch (SqlException ex)
            {                
                Rdb.ErrorMessage(ex); // SQL エラーが発生した場合 エラーメッセージ表示
            }
        }
    }
}
