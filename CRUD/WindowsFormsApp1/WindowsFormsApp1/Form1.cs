using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        AboutSQL aboutSQL;
        public Form1()
        {
            InitializeComponent();
            aboutSQL = new AboutSQL();
            aboutSQL.Connect();
            aboutSQL.CreateDB();
            aboutSQL.CreateTable();
            //dataGridView1.DataSource = aboutSQL.SelectTable();
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aboutSQL.SelectTable();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            aboutSQL.InsertTable(Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value.ToString()),
                Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value.ToString()),
                Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value.ToString()),
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[3].Value.ToString(),
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[4].Value.ToString()
                );
          
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            aboutSQL.UpdataTable(dataTable);
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                aboutSQL.DeleteTable(temp);
                dataGridView1.DataSource = aboutSQL.SelectTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show("삭제하기 원하시는 행을 클릭한 뒤 버튼을 눌러주세요.\n");
            }
        }
    }
}
