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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace WinFormsApp2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            HeaderForm headerForm = new HeaderForm();　　// headerフォームのインスタンス化
            headerForm.TopLevel = false;  　　　　　　　 // メインフォーム内にサブフォームとして表示
            headerForm.Dock = DockStyle.Top;             // 上部にドッキングさせる
            this.Controls.Add(headerForm);　　　　　　　 // thisで現在のフォーム、現在のフォームにheaderFormを追加
            headerForm.Show();                           // フォームを表示

        }


        private void Form1_Load(object sender, EventArgs e)　//ID入力
        {
            loginbtn.Enabled = false;
            ActiveControl = txtEmpID;  //カーソルがIDコントロールに移動
        }

        private void txtEmpID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpID.Text))　//Stringクラスのメソッドなのでstring.を前につける
            {
                MessageBox.Show("IDとパスワードを入力してください。");　//false判定なら（）内のメッセージ表示
            }
        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)　//password入力
        {
            loginbtn.Enabled = true;      //文字が入力されるとログインボタンが有効になる
            textBox1.PasswordChar = '*';　//文字を伏字にする
        }


        private void button1_Click(object sender, EventArgs e) //ログインボタン
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))　
            {
                MessageBox.Show("IDとパスワードを入力してください。");
                return;

            }

            try
            {
                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT * FROM EMPLOYEE WHERE EMP_ID = @EMP_ID";
                sql.Parameters.AddWithValue("@EMP_ID", txtEmpID.Text);

                using var reader = sql.ExecuteReader(); //SQLクエリの結果セットを取得し、その結果を順次読み込むための
                                                        //SqlDataReader オブジェクトを返す。
                                                        //ExecuteReader() が呼ばれた瞬間に、DataReader が開かれる

                if (reader.Read())　//コネクションを開く
                {
                    // ログイン成功
                    MessageBox.Show("ログイン成功しました！");
                    reader.Close();  // DataReaderを閉じる
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
    }
}

