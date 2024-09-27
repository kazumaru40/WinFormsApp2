namespace WinFormsApp2
{
    partial class ResultForm
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
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(400, 309);
            label1.Name = "label1";
            label1.Size = new Size(327, 128);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(463, 513);
            button1.Name = "button1";
            button1.Size = new Size(200, 50);
            button1.TabIndex = 1;
            button1.Text = "ストレス対策サイト";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1182, 853);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "ResultForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ResultForm";
            Load += ResultForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
    }
}