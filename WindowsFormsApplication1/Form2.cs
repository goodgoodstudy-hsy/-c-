using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Form1.Form1Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("退出成功");
            this.Dispose();
            Form1 F1 = new Form1();
            F1.StartPosition = FormStartPosition.CenterScreen;
            F1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("课程名不能为空");
                }
                else
                {
                    string str = "server = localhost;database=mydatabase;integrated security = true";
                    SqlConnection con = new SqlConnection(str);
                    con.Open();
                    string sql = "select * from grade where sid = " + Form1.Form1Value+" and cno = "+ textBox1.Text;
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "t");
                    dataGridView1.DataSource = ds.Tables["t"];
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("课程名不能为空");
                }
                else
                {
                    string str = "server = localhost;database=mydatabase;integrated security = true";
                    SqlConnection con = new SqlConnection(str);
                    con.Open();
                    string sql = "select * from grade where sid = " + Form1.Form1Value;
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "t");
                    dataGridView1.DataSource = ds.Tables["t"];
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
