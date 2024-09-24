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
                    // 特定の質問（1～7、11～13、15）の場合の処理
                    if ((i >= 0 && i <= 6) || (i >= 10 && i <= 12) || i == 14)
                    {
                        score += 4;  // 上記の領域では4点
                    }
                    else
                    {
                        score += 1;  // 通常の質問では1点
                    }

                    label1.Text = questions[i];
                    i++;　　　　　　　　　　　　　　　// 次の質問を表示
                    
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
                    if ((i >= 0 && i <= 6) || (i >= 10 && i <= 12) || i == 14)
                    {
                        score += 3;  // 上の領域では3点
                    }
                    else
                    {
                        score += 2;  // 通常の質問では2点
                    }

                    label1.Text = questions[i];
                    i++;

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
                    if (i < questions.Count)
                    {
                        if ((i >= 0 && i <= 6) || (i >= 10 && i <= 12) || i == 14)
                        {
                            score += 2;  // 上記の領域ではで2点
                        }
                        else
                        {
                            score += 3;  // 通常の質問では3点
                        }

                        label1.Text = questions[i];
                        i++;
                    }
                    label1.Text = questions[i];
                    i++;

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
                    if ((i >= 0 && i <= 6) || (i >= 10 && i <= 12) || i == 14)
                    {
                        score += 1;  // 上記の領域では1点
                    }
                    else
                    {
                        score += 4;  // 通常の質問では4点
                    }

                    label1.Text = questions[i];
                    i++;

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
