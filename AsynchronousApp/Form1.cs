using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousApp
{
    public partial class Form1 : Form
    {
        private DataBase _dataBase = new DataBase();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await Task.Run(() =>  GetData());

            if (_dataBase.Iscancel)
            {
                MessageBox.Show("キャンセルされました");
            }
            else
            {
                MessageBox.Show("完了");
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            _dataBase.Cancel();
        }
    }
}
