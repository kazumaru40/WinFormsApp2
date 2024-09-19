using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class SelectForm : Form
    {
        // テキストリストと現在のインデックスを管理
        private List<string> aTexts;
        private int currentIndex = 0;

        public SelectForm()
        {
            InitializeComponent();

            // テキストリストの初期化
            aTexts = new List<string>
            {
                "Aのテキスト 1",
                "Aのテキスト 2",
                "Aのテキスト 3",
                "Aのテキスト 4",
                // ... Aのテキスト17まで
                "Aのテキスト 17"
            };

            // 初期テキストを表示
            textBox1.Text = aTexts[currentIndex];

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

        private void SelectForm_Load(object sender, EventArgs e)
        {
            // ラジオボタンにイベントを接続
            radioButton1.CheckedChanged += radioButton_CheckedChanged;
            radioButton2.CheckedChanged += radioButton_CheckedChanged;
            radioButton3.CheckedChanged += radioButton_CheckedChanged;
            radioButton4.CheckedChanged += radioButton_CheckedChanged;
        }

        // ラジオボタンの状態が変更された時の処理
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // どのラジオボタンが選ばれても次のテキストを表示
            if (currentIndex < aTexts.Count - 1)
            {
                currentIndex++;
                textBox1.Text = aTexts[currentIndex];
            }
            else
            {
                // 17個目のテキストが表示された後、次のフォームへ遷移
                ResultForm resultForm = new ResultForm(); // 次のフォームのインスタンスを作成
                resultForm.Show();
                this.Hide();  // 現在のフォームを隠す（または閉じる）
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
