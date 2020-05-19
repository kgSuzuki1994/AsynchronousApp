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
        private bool _isCancel = false;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _isCancel = false;
            dataGridView1.DataSource = await Task.Run(() =>  GetData());

            if (_isCancel)
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
            _isCancel = true;
        }

        private List<DTO> GetData()
        {
            var result = new List<DTO>();
            for (int i = 0; i < 5; i++)
            {
                if (_isCancel)
                {
                    return null;
                }
                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO(i.ToString(), "Name" + i));
            }

            return result;
        }
    }
}
