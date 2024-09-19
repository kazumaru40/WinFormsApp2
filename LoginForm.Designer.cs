namespace WinFormsApp2
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            pictureBox1 = new PictureBox();
            richTextBox2 = new RichTextBox();
            txtEmpID = new TextBox();
            label1 = new Label();
            label2 = new Label();
            loginbtn = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(364, 178);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(400, 80);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "         \n                １０分でできる職場のセルフストレスチェック";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.high_angle_traveling_planning_process_23_2148300713;
            pictureBox1.Location = new Point(398, 285);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(303, 409);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(500, 100);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "        ３つのステップで簡単な質問に答えてもらい、ストレス度をチェックします\n                         全５７問で約１０分ほどで終了します。";
            // 
            // txtEmpID
            // 
            txtEmpID.Location = new Point(492, 595);
            txtEmpID.Name = "txtEmpID";
            txtEmpID.Size = new Size(200, 27);
            txtEmpID.TabIndex = 4;
            txtEmpID.TextChanged += txtEmpID_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(413, 595);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 5;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(389, 653);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 6;
            label2.Text = "password";
            label2.Click += label2_Click;
            // 
            // loginbtn
            // 
            loginbtn.Location = new Point(492, 712);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(200, 30);
            loginbtn.TabIndex = 8;
            loginbtn.Text = "ログイン";
            loginbtn.UseVisualStyleBackColor = true;
            loginbtn.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(492, 653);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 27);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 890);
            Controls.Add(textBox1);
            Controls.Add(loginbtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmpID);
            Controls.Add(richTextBox2);
            Controls.Add(pictureBox1);
            Controls.Add(richTextBox1);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox2;
        private TextBox txtEmpID;
        private Label label1;
        private Label label2;
        private Button loginbtn;
        private TextBox textBox1;
    }
}