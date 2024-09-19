using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WinFormsApp2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // headerフォームのインスタンスを作成してメインフォームに追加
            HeaderForm headerForm = new HeaderForm();
            headerForm.TopLevel = false;  // 子フォームとしてメインフォーム内に表示
            headerForm.Dock = DockStyle.Top;  // 上部に配置
            this.Controls.Add(headerForm);
            headerForm.Show();  // フォームを表示

        }


        private void Form1_Load(object sender, EventArgs e)　//ID入力
        {
            ActiveControl = txtEmpID;  //カーソルがID入力フォームに移動
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT * FROM EMPLOYEE WHERE EMP_ID = @EMP_ID";
                sql.Parameters.AddWithValue("@EMP_ID", txtEmpID.Text);

                using var reader = sql.ExecuteReader();
                if (reader.Read())
                {
                    // ログイン成功
                    MessageBox.Show("ログイン成功しました！");
                    InformationForm informationForm = new InformationForm(); // 遷移先のフォームをインスタンス化
                    informationForm.Show();　　　　　　　　　　　　　　　　　//InfomationFormに遷移する
                    this.Hide();                                             // 現在のLoginFormを非表示にする
                }
                else
                {
                    // ログイン失敗（IDまたはpasswordが一致しない）
                    MessageBox.Show("IDが正しくありません。");
                }
            }
            catch (SqlException ex)
            {
                Rdb.ErrorMessage(ex);
            }
        }

        private void txtEmpID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)　//password入力
        {
            textBox1.PasswordChar = '*';　//パスワードの文字を伏字にする

            // IsNullOrWhiteSpace（この中に判定したい文字列）空文字を判定するメソッド
            if (string.IsNullOrWhiteSpace(textBox1.Text))　//Stringクラスのメソッドなのでstring.を前につける
            {
                MessageBox.Show("パスワードを入力してください。");　//指定したテキストを表示するメソッド
            }
        }
    }
}

