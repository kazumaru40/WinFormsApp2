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
            pictureBox1 = new PictureBox();
            txtEmpID = new TextBox();
            label1 = new Label();
            label2 = new Label();
            loginbtn = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.high_angle_traveling_planning_process_23_2148300713;
            pictureBox1.Location = new Point(413, 284);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
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
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 13;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 12;
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
            // label3
            // 
            label3.Font = new Font("Yu Gothic UI", 14F);
            label3.Location = new Point(346, 184);
            label3.Name = "label3";
            label3.Size = new Size(426, 42);
            label3.TabIndex = 10;
            label3.Text = "10分で出来る職場のセルフストレスチェック";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Yu Gothic UI", 10F);
            label4.Location = new Point(322, 409);
            label4.Name = "label4";
            label4.Size = new Size(491, 100);
            label4.TabIndex = 11;
            label4.Text = "３つのステップで簡単な質問に答えてもらい、ストレス度をチェックします。全５７問で約１０分ほどで終了します。";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(408, 602);
            label5.Name = "label5";
            label5.Size = new Size(24, 20);
            label5.TabIndex = 14;
            label5.Text = "ID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(382, 660);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 15;
            label6.Text = "password";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 890);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(loginbtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmpID);
            Controls.Add(pictureBox1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private TextBox txtEmpID;
        private Label label1;
        private Label label2;
        private Button loginbtn;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}