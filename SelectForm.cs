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

namespace WinFormsApp2
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                using var sql = Rdb.Conn.CreateCommand();
                sql.CommandText = "SELECT TOP 1 Q_TEXT FROM QUESTION WHERE Q_CATEGORY = 'A' ORDER BY Q_NO;";

                using var reader = sql.ExecuteReader();
                if (reader.Read())
                {
                    label1.Text = reader.ToString(); 

                }
            }
            catch (SqlException ex)
            {
                Rdb.ErrorMessage(ex);
            }
        }
    }
}
