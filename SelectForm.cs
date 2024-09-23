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

            FooterForm footerForm = new FooterForm(); // hooterフォーム
            footerForm.TopLevel = false;
            footerForm.Dock = DockStyle.Bottom;
            this.Controls.Add(footerForm);
            footerForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SelectForm_Load(object sender, EventArgs e)
        {

            try
            {
                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT TOP 1 Q_TEXT FROM QUESTION WHERE Q_CATEGORY = 'A' ORDER BY Q_NO;";


                using var reader = sql.ExecuteReader();
                if (reader.Read())
                {
                    label1.Text = reader["Q_TEXT"].ToString();  //Q_TEXTを表示

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
    }
}
