﻿using Microsoft.Data.SqlClient;
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

        private int i = 0; 　　　　　　　　　　　　　　　　　// 変数を初期化
        private int j = 0;
        private int k = 0;
        private int l = 0;
        private List<string> questionsA = new List<string>(); // DBの質問を格納するリストquestionsを作成
        private List<string> questionsB = new List<string>(); //
        private List<string> questionsC = new List<string>();
        private List<string> questionsD = new List<string>();

        private void SelectForm_Load(object sender, EventArgs e)
        {

            try
            {
                label2.Text = "あなたの仕事についてうかがいます。最もあてはまるものを選んでください。";

                radioButton1.CheckedChanged += radioButton_CheckedChangedA;
                radioButton2.CheckedChanged += radioButton_CheckedChangedA;
                radioButton3.CheckedChanged += radioButton_CheckedChangedA;
                radioButton4.CheckedChanged += radioButton_CheckedChangedA;

                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT Q_TEXT FROM QUESTION WHERE Q_CATEGORY = 'A'";  //クエリ作成
                using var reader = sql.ExecuteReader();　//SQLクエリを実行して、データを読み取る

                while (reader.Read())　　　//while ループ reader.Read() が trueの時ループ実行
                {
                    questionsA.Add(reader["Q_TEXT"].ToString()); //Q_TEXT列のすべての行が処理される
                }


                if (i < questionsA.Count)           // i が questions.Countの要素数より小さい場合
                {
                    label1.Text = questionsA[i];    // label1に questionsAのi番目 の質問が表示
                    i++;                           // i++で次の質問を順番に表示
                }

            }
            catch (SqlException ex)
            {
                Rdb.ErrorMessage(ex);
            }

        }




        private int scoreA = 0; //点数を加算していく変数
        private bool isCategoryAComplete = false;  // 質問Aが終了したかを示すフラグ

        //Aの領域の質問を回答する時のラジオボタン１～４の計算方法
        private void radioButton_CheckedChangedA(object sender, EventArgs e)
        {
            //ラジオボタンのインスタンス化
            //sender as RadioButton (RadioButton 型にキャスト)
            RadioButton selectedRadioButton = sender as RadioButton;


            //ラジオボタンがnullではなくて、選択されているかどうかを確認
            if (selectedRadioButton != null && selectedRadioButton.Checked)
            {
                // 選択されたラジオボタンを未選択状態に戻す
                selectedRadioButton.Checked = false;


                // 特定の質問（1～7、11～13、15）の場合の処理
                bool specialQuestion = (i >= 0 && i <= 7) || (i >= 11 && i <= 13) || i == 15;

                // ラジオボタンごとのスコア加算処理
                switch (selectedRadioButton.Name)
                {
                    //specialQuestion　真偽値(bool型)をもった変数
                    //? でspecialQuestionがtrueかどうかを評価し、trueの場合は 4 を、false の場合は 1 。
                    //+= scoreA に指定された値を加算し、結果を scoreA に再代入。
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
                if (i < questionsA.Count) // 質問がまだ残っている場合
                {
                    label1.Text = questionsA[i]; // label1に質問を表示
                    i++; // 質問インデックスを進める
                }
                else // 質問Aが終了した場合
                {
                    MessageBox.Show("最近 1 か月間のあなたの状態についてうかがいます。最もあてはまるものを選んでください。");
                    LoadAndShowCategoryBQuestions(); // 質問Bをロードして表示

                    if (0 < 30)  // 1問目と2問目でラジオボタンのテキストを変更
                    {
                        radioButton1.Text = "ほとんどなかった";
                        radioButton2.Text = "ときどきあった";
                        radioButton3.Text = "しばしばあった";
                        radioButton4.Text = "ほとんどいつでもあった";
                    }
                }
            }

        }


        private int scoreB = 0;　//点数を加算していく変数

        //Bの領域の質問を回答する時のラジオボタン１～４の計算方法
        private void radioButton_CheckedChangedB(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton != null && selectedRadioButton.Checked)
            {
                // 選択されたラジオボタンを未選択状態に戻す
                selectedRadioButton.Checked = false;


                // 特定の質問（1～3）の場合の処理
                bool specialQuestion = (j == 1 || j == 2 || j == 3);

                // ラジオボタンごとのスコア加算処理
                switch (selectedRadioButton.Name)
                {
                    case "radioButton1":
                        scoreB += specialQuestion ? 4 : 1;
                        break;
                    case "radioButton2":
                        scoreB += specialQuestion ? 3 : 2;
                        break;
                    case "radioButton3":
                        scoreB += specialQuestion ? 2 : 3;
                        break;
                    case "radioButton4":
                        scoreB += specialQuestion ? 1 : 4;
                        break;
                }

                // 次の質問を表示
                if (j < questionsB.Count) // 質問がまだ残っている場合
                {
                    label1.Text = questionsB[j]; // 現在の質問を表示
                    j++; // 質問インデックスを進める
                }

                else // 質問Bが終了した場合
                {
                    MessageBox.Show("あなたの周りの方々についてうかがいます。最もあてはまるものを選んでください");
                    LoadAndShowCategoryCQuestions(); // 質問Cをロードして表示

                    if (0 < 8)  // 1問目と2問目でラジオボタンのテキストを変更
                    {
                        radioButton1.Text = "非常に";
                        radioButton2.Text = "かなり";
                        radioButton3.Text = "多少";
                        radioButton4.Text = "全くない";
                    }
                }
            }
        }


        private int scoreC = 0;　//点数を加算していく変数
        //Cの領域の質問を回答する時のラジオボタン１～４の計算方法
        private void radioButton_CheckedChangedC(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton != null && selectedRadioButton.Checked)
            {
                // 選択されたラジオボタンを未選択状態に戻す
                selectedRadioButton.Checked = false;


                // ラジオボタンごとのスコア加算処理
                switch (selectedRadioButton.Name)
                {
                    case "radioButton1":
                        scoreC += 1;  // radioButton1は1点
                        break;
                    case "radioButton2":
                        scoreC += 2;  // radioButton2は2点
                        break;
                    case "radioButton3":
                        scoreC += 3;  // radioButton3は3点
                        break;
                    case "radioButton4":
                        scoreC += 4;  // radioButton4は4点
                        break;
                }

                // 質問の領域ごとにサブタイトルを表示
                if (k >= 0 && k <= 2)
                {
                    label2.Text = "次の人たちはどのくらい気軽に話ができますか？";
                }
                else if (k >= 3 && k <= 5)
                {
                    label2.Text = "あなたが困った時、次の人たちはどのくらい頼りになりますか？";
                }
                else if (k >= 6 && k <= 8)
                {
                    label2.Text = "あなたの個人的な問題を相談したら、次の人たちはどのくらいきいてくれますか？";
                }


                // 次の質問を表示
                if (k < questionsC.Count)
                {
                    label1.Text = questionsC[k];
                    k++;
                }

                else // 質問Cが終了した場合
                {
                    MessageBox.Show(" 満足度について ");
                    LoadAndShowCategoryDQuestions(); // 質問Dをロードして表示
                                                     
                    if (0 < 2) // 1問目と2問目でラジオボタンのテキストを変更
                        {
                        radioButton1.Text = "満足";
                        radioButton2.Text = "まあ満足";
                        radioButton3.Text = "やや満足";
                        radioButton4.Text = "不満足";
                    }
                }
            }
        }


        private int scoreD = 0;　//点数を加算していく変数

        //Dの領域の質問を回答する時のラジオボタン１～４の計算方法
        private void radioButton_CheckedChangedD(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton != null && selectedRadioButton.Checked)
            {
                // 選択されたラジオボタンを未選択状態に戻す
                selectedRadioButton.Checked = false;


                // ラジオボタンごとのスコア加算処理
                switch (selectedRadioButton.Name)
                {
                    case "radioButton1":
                        scoreD += 1;  // radioButton1は1点
                        break;
                    case "radioButton2":
                        scoreD += 2;  // radioButton2は2点
                        break;
                    case "radioButton3":
                        scoreD += 3;  // radioButton3は3点
                        break;
                    case "radioButton4":
                        scoreD += 4;  // radioButton4は4点
                        break;
                }

                // 次の質問を表示
                if (l < questionsD.Count)
                {
                    label1.Text = questionsD[l];
                    l++;
                }

                else // 質問Dが終了した場合
                {
                    // スコア判定
                    bool isHighStress = false;

                    // ㋐ scoreBの合計点数が77点以上
                    if (scoreB >= 77)
                    {
                        isHighStress = true;
                    }

                    // ㋑ scoreAとscoreCの合算が76点以上かつscoreBが63点以上
                    if ((scoreA + scoreC >= 76) && (scoreB >= 63))
                    {
                        isHighStress = true;
                    }

                    // ㋐と㋑ 共に当てはまる
                    if ((scoreB >= 77) && ((scoreA + scoreC >= 76) && (scoreB >= 63)))
                    {
                        isHighStress = true;
                    }


                        // 判定結果を表示してフォームを遷移
                        if (isHighStress)　//trueの時
                    {
                        MessageBox.Show("高ストレス者です。");                      
                        ResultForm resultForm = new ResultForm();
                        resultForm.ResultMessage = "あなたは高ストレス者です。";  // メッセージをセット
                        resultForm.Show();
                        this.Hide();  // 現在のフォームを隠す
                    }
                    else　　　　　　　//falseの時
                    {
                        MessageBox.Show("高ストレス者ではありません。");
                        ResultForm resultForm = new ResultForm();
                        resultForm.ResultMessage = "あなたは高ストレス者ではありません。";  // メッセージをセット
                        resultForm.Show();
                        this.Hide();  // 現在のフォームを隠す
                    }
                }
            }
        }




        // 質問Bをロードし、最初の質問を表示するメソッド
        private void LoadAndShowCategoryBQuestions()
        {
            try
            {
                radioButton1.CheckedChanged -= radioButton_CheckedChangedA; //Aのハンドラーを削除
                radioButton2.CheckedChanged -= radioButton_CheckedChangedA;
                radioButton3.CheckedChanged -= radioButton_CheckedChangedA;
                radioButton4.CheckedChanged -= radioButton_CheckedChangedA;

                radioButton1.CheckedChanged += radioButton_CheckedChangedB; // Bのハンドラーを追加
                radioButton2.CheckedChanged += radioButton_CheckedChangedB;
                radioButton3.CheckedChanged += radioButton_CheckedChangedB;
                radioButton4.CheckedChanged += radioButton_CheckedChangedB;

                // 質問Bを取得
                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT Q_TEXT FROM QUESTION WHERE Q_CATEGORY = 'B'";
                using var reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    questionsB.Add(reader["Q_TEXT"].ToString());
                }

                // label2にBの説明を表示
                label2.Text = "最近 1 か月間のあなたの状態についてうかがいます。最もあてはまるものを選んでください。";

                // 最初の質問Bを表示
                if (j < questionsB.Count)
                {
                    label1.Text = questionsB[j];
                    j++;
                }

            }
            catch (SqlException ex)
            {
                Rdb.ErrorMessage(ex);
            }
        }


        // 質問Cをロードし、最初の質問を表示するメソッド
        private void LoadAndShowCategoryCQuestions()
        {
            try
            {
                radioButton1.CheckedChanged -= radioButton_CheckedChangedB; //Bのハンドラーを削除
                radioButton2.CheckedChanged -= radioButton_CheckedChangedB;
                radioButton3.CheckedChanged -= radioButton_CheckedChangedB;
                radioButton4.CheckedChanged -= radioButton_CheckedChangedB;

                radioButton1.CheckedChanged += radioButton_CheckedChangedC; // Cのハンドラーを追加
                radioButton2.CheckedChanged += radioButton_CheckedChangedC;
                radioButton3.CheckedChanged += radioButton_CheckedChangedC;
                radioButton4.CheckedChanged += radioButton_CheckedChangedC;

                // 質問Cを取得
                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT Q_TEXT FROM QUESTION WHERE Q_CATEGORY = 'C'";
                using var reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    questionsC.Add(reader["Q_TEXT"].ToString());
                }

                label2.Text = "次の人たちはどのくらい気軽に話ができますか？";


                // 最初の質問Cを表示
                if (k < questionsC.Count)
                {
                    label1.Text = questionsC[k];
                    k++;
                }

            }
            catch (SqlException ex)
            {
                Rdb.ErrorMessage(ex);
            }
        }

        // 質問Dをロードし、最初の質問を表示するメソッド
        private void LoadAndShowCategoryDQuestions()
        {
            try
            {
                radioButton1.CheckedChanged -= radioButton_CheckedChangedC; 
                radioButton2.CheckedChanged -= radioButton_CheckedChangedC;
                radioButton3.CheckedChanged -= radioButton_CheckedChangedC;
                radioButton4.CheckedChanged -= radioButton_CheckedChangedC;

                radioButton1.CheckedChanged += radioButton_CheckedChangedD; 
                radioButton2.CheckedChanged += radioButton_CheckedChangedD;
                radioButton3.CheckedChanged += radioButton_CheckedChangedD;
                radioButton4.CheckedChanged += radioButton_CheckedChangedD;

                // 質問Dを取得
                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT Q_TEXT FROM QUESTION WHERE Q_CATEGORY = 'D'";
                using var reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    questionsD.Add(reader["Q_TEXT"].ToString());
                }

                label2.Text = "満足度について ";


                // 最初の質問Dを表示
                if (l < questionsD.Count)
                {
                    label1.Text = questionsD[l];
                    l++;
                }

            }
            catch (SqlException ex)
            {
                Rdb.ErrorMessage(ex);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
