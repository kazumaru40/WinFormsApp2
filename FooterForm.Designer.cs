namespace WinFormsApp2
{
    partial class FooterForm
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
            footerpanel = new Panel();
            button1 = new Button();
            footerlabel = new Label();
            footerpanel.SuspendLayout();
            SuspendLayout();
            // 
            // footerpanel
            // 
            footerpanel.Controls.Add(button1);
            footerpanel.Location = new Point(73, 49);
            footerpanel.Name = "footerpanel";
            footerpanel.Size = new Size(1000, 70);
            footerpanel.TabIndex = 0;
            footerpanel.Paint += footerpanel_Paint;
            // 
            // button1
            // 
            button1.Location = new Point(440, 17);
            button1.Name = "button1";
            button1.Size = new Size(125, 50);
            button1.TabIndex = 1;
            button1.Text = "テストを終了する";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // footerlabel
            // 
            footerlabel.Location = new Point(0, 0);
            footerlabel.Name = "footerlabel";
            footerlabel.Size = new Size(100, 23);
            footerlabel.TabIndex = 0;
            // 
            // FooterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 153);
            Controls.Add(footerlabel);
            Controls.Add(footerpanel);
            Name = "FooterForm";
            Text = "footer";
            Load += footer_Load;
            footerpanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel footerpanel;
        private Label footerlabel;
        private Button button1;
    }
}