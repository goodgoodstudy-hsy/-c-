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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
           {
               if (textBox1.Text == "")
               {
                   MessageBox.Show("学号不能为空");
               }
               else
               {
                   string str = "server = localhost;database=mydatabase;integrated security = true";
                   SqlConnection con = new SqlConnection(str);
                   con.Open();
                   string sql = "select * from grade,st where tid = " + Form1.Form1Value+" and sid = "+ textBox1.Text;
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("学号不能为空");
                }
                else
                {
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("课程号不能为空");
                    }
                    else
                    {
                        string s1 = textBox2.Text;
                        string s2 = textBox2.Text;
                        string s3 = textBox4.Text;
                        string str = "server = localhost;database=mydatabase;integrated security = true";
                        SqlConnection con = new SqlConnection(str);
                        con.Open();
                        string sql1 = string.Format("select * from grade where "+s1+" = "+textBox2.Text + " and "+s2+" = "+textBox3.Text, s1, s2);
                        SqlCommand command = new SqlCommand(sql1, con);
                        int i = Convert.ToInt32(command.ExecuteScalar());
                        if (i >0)
                        {
                           string sql2 = "update grade set grade = "+s3+"where sid = "+s1+"and cno = "+s2;
                           SqlDataAdapter sda = new SqlDataAdapter(sql2, con);
                           MessageBox.Show("修改成功");
                           DataSet ds = new DataSet();
                           sda.Fill(ds, "t");
                           dataGridView1.DataSource = ds.Tables["t"];
                           con.Close();
                           this.Dispose();
                           Form2 F2 = new Form2();
                           F2.StartPosition = FormStartPosition.CenterScreen;
                           F2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("学号或者课程号错误");
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Form1.Form1Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("学号不能为空");
                }
                else
                {
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("课程号不能为空");
                    }
                    else
                    {
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("成绩不能为空");
                        }
                        else {
                            string s1 = textBox2.Text;
                            string s2 = textBox2.Text;
                            string s3 = textBox4.Text;
                            string str = "server = localhost;database=mydatabase;integrated security = true";
                            SqlConnection con = new SqlConnection(str);
                            con.Open();
                            string sql = "insert into grade(sid,cno,grade)value("+s1+","+s2+","+s2+")";
                            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                            DataSet ds = new DataSet();
                            sda.Fill(ds, "t");
                            dataGridView1.DataSource = ds.Tables["t"];
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        //全部查询
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                string str = "server = localhost;database=mydatabase;integrated security = true";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string sql = "select * from C,grade where tid = " + Form1.Form1Value;
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "t");
                dataGridView1.DataSource = ds.Tables["t"];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("退出成功");
            this.Dispose();
            Form1 F1 = new Form1();
            F1.StartPosition = FormStartPosition.CenterScreen;
            F1.ShowDialog();
        }


        //分类查询
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "server = localhost;database=mydatabase;integrated security = true";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                string sql = "select cname,count(sid) from C,grade where tid = " + Form1.Form1Value + "group by cno";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "t");
                dataGridView1.DataSource = ds.Tables["t"];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }
        }
    }
}
