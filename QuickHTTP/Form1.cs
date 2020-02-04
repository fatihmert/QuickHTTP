using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;

namespace QuickHTTP
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        Dictionary<string, string> headers = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();

            this.customInit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        public void loadParameters()
        {

            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow param in dataGridView1.Rows)
                {
                    if (param.Cells[0].Value != null && param.Cells[1].Value != null)
                    {
                        this.parameters.Add(param.Cells[0].Value.ToString(), param.Cells[1].Value.ToString());
                    }
                }
            }

            
        }

        public void loadHeaders()
        {
            if (dataGridView2.Rows.Count > 0)
            {
                foreach (DataGridViewRow param in dataGridView2.Rows)
                {
                    if (param.Cells[0].Value != null && param.Cells[1].Value != null)
                    {
                        this.headers.Add(param.Cells[0].Value.ToString(), param.Cells[1].Value.ToString());
                    }
                }
            }
        }


        private void customInit()
        {
            this.dataGridView2.Rows.Add("Content-Type", "application/x-www-form-urlencoded");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string requestMethod = comboBox1.SelectedItem.ToString();
            string url = textBox1.Text.ToString();

            this.loadParameters();
            this.loadHeaders();

            using (var wb = new WebClient())
            {
                foreach (var kvp in this.parameters)
                {
                    wb.QueryString.Add(kvp.Key.ToString(), kvp.Value.ToString());
                }

                foreach (var kvp in this.headers)
                {
                    wb.Headers.Add(kvp.Key.ToString(), kvp.Value.ToString());
                }
                               

                textBox2.Text = wb.DownloadString(url);
            }


        }
    }
}
