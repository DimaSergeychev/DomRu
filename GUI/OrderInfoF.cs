using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceCenter.Logic;
using ServiceCenter.DataClasses;

namespace ServiceCenter.GUI
{
    public partial class OrderInfoF : Form
    {
        public Staff master;
        public DataClasses.Application app;

        public OrderInfoF(Staff master, DataClasses.Application appl)
        {
            InitializeComponent();
            this.master = master;
            setMaster();
            this.app = appl;
            richTextBox1.Text = appl.client.surname + " " + appl.client.name + " " + appl.client.patronymic;
            richTextBox2.Text = appl.date.Date.ToShortDateString();
            richTextBox3.Text = appl.client.phoneNum;
            richTextBox4.Text = appl.order.address;

            foreach (Service it in appl.order.services)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["id"].Value = it.id;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["name"].Value = it.name;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["description"].Value = it.description;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["price"].Value = it.price;
            }
            countSum();

        }

        private void countSum()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells["price"].Value);
            }

            richTextBox8.Text = sum + " руб.";
        }

        public void setMaster()
        {
            label1.Text += master.surname + " " + master.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainFMaster f = new(master);
            f.Show();
            Close();
        }
    }
}
