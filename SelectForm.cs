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
using static System.Formats.Asn1.AsnWriter;
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

            FooterForm footerForm = new FooterForm();    // footerフォーム
            footerForm.TopLevel = false;
            footerForm.Dock = DockStyle.Bottom;
            this.Controls.Add(footerForm);
            footerForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int i = 0; 　　　　　　　　　　　　　　　　　// 変数iを初期化
        private List<string> questions = new List<string>(); // 質問を格納するリストquestionsを作成

        private void SelectForm_Load(object sender, EventArgs e)
        {
            try
            {
                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT Q_TEXT FROM QUESTION WHERE Q_CATEGORY = 'A'";  //クエリ作成
                using var reader = sql.ExecuteReader();　//SQLクエリを実行して、データを読み取る

                while (reader.Read())　　　//while ループ reader.Read() が trueの時ループ実行
                {
                    questions.Add(reader["Q_TEXT"].ToString()); //Q_TEXT列のすべての行が処理される
                }

                
                if (i < questions.Count)           // i が questions.Countの要素数より小さい場合
                {
                    label1.Text = questions[i];    // 配列 i = 0 から表示
                    i++;                           // i++で次の配列へ
                }
            }
            catch (SqlException ex)
            {
                Rdb.ErrorMessage(ex);
            }
        }

        private int score = 0;　//点数を加算していく変数

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (i < questions.Count)
                {
                    label1.Text = questions[i];
                    i++;　　　　　　　　　　　　　　　// 次の質問を表示
                    score += 1;　　　　　　　　　　　　// 点数を加算
                }
                else
                {
                    MessageBox.Show("全ての質問が終了しました。次のステップに移ります。");
                    InformationForm informationForm = new InformationForm();
                    informationForm.Show();
                    this.Hide();
                }
                radioButton1.Checked = false;　　　// ラジオボタン選択後、未選択状態に戻す
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (i < questions.Count)
                {
                    label1.Text = questions[i];
                    i++;
                    score += 2;
                }
                else
                {
                    MessageBox.Show("全ての質問が終了しました。次のステップに移ります。");
                    InformationForm informationForm = new InformationForm();
                    informationForm.Show();
                    this.Hide();
                }
                radioButton2.Checked = false;

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                if (i < questions.Count)
                {
                    label1.Text = questions[i];
                    i++;
                    score += 3;
                }
                else
                {
                    MessageBox.Show("全ての質問が終了しました。次のステップに移ります。");
                    InformationForm informationForm = new InformationForm();
                    informationForm.Show();
                    this.Hide();
                }
                radioButton3.Checked = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                if (i < questions.Count)
                {
                    label1.Text = questions[i];
                    i++;
                    score += 4;
                }
                else
                {
                    MessageBox.Show("全ての質問が終了しました。次のステップに移ります。");
                    InformationForm informationForm = new InformationForm();
                    informationForm.Show();
                    this.Hide();
                }
                radioButton4.Checked = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
