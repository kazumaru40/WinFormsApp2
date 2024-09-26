using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Windows.Forms;
using RadioButton = System.Windows.Forms.RadioButton;
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
                radioButton1.CheckedChanged += radioButton_CheckedChangedA;
                radioButton2.CheckedChanged += radioButton_CheckedChangedA;
                radioButton3.CheckedChanged += radioButton_CheckedChangedA;
                radioButton4.CheckedChanged += radioButton_CheckedChangedA;

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


        private int scoreA = 0;　//点数を加算していく変数
        private void radioButton_CheckedChangedA(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton != null && selectedRadioButton.Checked)
            {
                // 選択されたラジオボタンを未選択状態に戻す
                selectedRadioButton.Checked = false;

                if (i < questions.Count)
                {
                    // 特定の質問（1～7、11～13、15）の場合の処理
                    bool specialQuestion = (i >= 0 && i <= 7) || (i >= 11 && i <= 13) || i == 15;

                    // ラジオボタンごとのスコア加算処理
                    switch (selectedRadioButton.Name)
                    {
                        case "radioButton1":
                            scoreA += specialQuestion ? 4 : 1;
                            break;
                        case "radioButton2":
                            scoreA += specialQuestion ? 3 : 2;
                            break;
                        case "radioButton3":
                            scoreA += specialQuestion ? 2 : 3;
                            break;
                        case "radioButton4":
                            scoreA += specialQuestion ? 1 : 4;
                            break;
                    }

                    // 次の質問を表示
                    label1.Text = questions[i];
                    i++;
                }
                else
                {
                    MessageBox.Show("全ての質問が終了しました。次のステップに移ります。");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
