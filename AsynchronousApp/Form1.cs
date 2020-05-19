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
        System.Threading.CancellationTokenSource _token;
        private DataBase _dataBase = new DataBase();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _token = new System.Threading.CancellationTokenSource();
                dataGridView1.DataSource = await Task.Run(() =>  _dataBase.GetData(_token.Token), _token.Token);
                MessageBox.Show("完了");
            }
            catch (OperationCanceledException o)
            {
                MessageBox.Show("キャンセルされました");
            }
            finally
            {
                _token.Dispose();
                _token = null;
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            _token?.Cancel();
        }
    }
}
