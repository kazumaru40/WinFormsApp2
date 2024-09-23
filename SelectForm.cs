using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsApp2
{
    public partial class SelectForm : Form
    {

        public SelectForm()
        {
            InitializeComponent();

            HeaderForm headerForm = new HeaderForm();　　// headerフォーム
            headerForm.TopLevel = false;
            headerForm.Dock = DockStyle.Top;
            this.Controls.Add(headerForm);
            headerForm.Show();

            FooterForm footerForm = new FooterForm(); // hooterフォーム
            footerForm.TopLevel = false;
            footerForm.Dock = DockStyle.Bottom;
            this.Controls.Add(footerForm);
            footerForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int i = 0; // 変数iでループ
        private List<string> questions = new List<string>(); // 質問を格納するリストを作成

        private void SelectForm_Load(object sender, EventArgs e)
        {
            try
            {
                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT Q_TEXT FROM QUESTION WHERE Q_CATEGORY = 'A' ORDER BY Q_NO";

                using var reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    questions.Add(reader["Q_TEXT"].ToString());
                }
            }
            catch (SqlException ex)
            {
                Rdb.ErrorMessage(ex);
            }

            // 最初の質問を表示
            if (questions.Count > 0)
            {
                NextQuestion();
            }

        }

        private void NextQuestion()　　        // 質問を表示するメソッドを作成
        {
            if (i < questions.Count)
            {
                label1.Text = questions[i];    //配列iを表示
                i++; 　　　　　　　　　　　　　// i++で次の質問へ
            }
            else
            {
                // 全部表示した後の処理
                MessageBox.Show("全ての質問が終了しました。次のステップに移ります。");　//メッセージ表示
                InformationForm informationForm = new InformationForm();　//次のフォームに遷移
                informationForm.Show();
                this.Hide();

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                NextQuestion();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                NextQuestion();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                NextQuestion();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                NextQuestion();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
