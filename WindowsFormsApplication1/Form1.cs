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
    public partial class Form1 : Form

    {
        public void sj() { 

        }

        public static string Form1Value;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           Form3 f3 = new Form3();
           f3.ShowDialog(this);
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form1Value = textBox1.Text;
                MessageBox.Show("登陆成功");
                this.Dispose();
                Form2 F2 = new Form2();
                F2.StartPosition = FormStartPosition.CenterScreen;
                F2.ShowDialog();

            }
            if (radioButton2.Checked)
            {
                Form1Value = textBox1.Text;
                MessageBox.Show("登陆成功");
                this.Dispose();
                Form3 F3 = new Form3();
                F3.StartPosition = FormStartPosition.CenterScreen;
                F3.ShowDialog();
            }


            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("用户名不能为空");
                }
                else
                {
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("密码不能为空");
                    }
                    else
                    {
                        string sno = textBox1.Text;
                        string spassword = textBox2.Text;
                        string s = "student";
                        string s1 = "sid";
                        string s2 = "spw";
                        string str = "server = localhost;database=mydatabase;integrated security = true";
                        SqlConnection con = new SqlConnection(str);
                        con.Open();
                        if (radioButton1.Checked)
                        {
                            s = "student";
                            s1 = "sid";
                            s2 = "spw";

                        }
                        if (radioButton2.Checked)
                        {
                            s = "teacher";
                            s1 = "tid";
                            s2 = "tpw";
                        }
                        string sql = string.Format("select * from "+s+" where "+s1+" = "+textBox1.Text + " and "+s2+" = "+textBox2.Text, sno, spassword);
                        SqlCommand command = new SqlCommand(sql, con);
                        int i = Convert.ToInt32(command.ExecuteScalar());
                        if (i >0)
                        {
                           
                            if (radioButton1.Checked)
                            {
                                Form1Value = textBox1.Text;
                                MessageBox.Show("登陆成功");
                                this.Dispose();
                                Form2 F2 = new Form2();
                                F2.StartPosition = FormStartPosition.CenterScreen;
                                F2.ShowDialog();

                            }
                            if (radioButton2.Checked)
                            {
                                Form1Value = textBox1.Text;
                                MessageBox.Show("登陆成功");
                                this.Dispose();
                                Form3 F3 = new Form3();
                                F3.StartPosition = FormStartPosition.CenterScreen;
                                F3.ShowDialog();
                            }


                            

                        }
                        else
                        {
                            MessageBox.Show("用户名或者密码错误");
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }





            /*string str = @"server=127.0.0.1;port=3306;user=root;password=;database=chengjichaxun;SqlMode = none;charset=utf8";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from student where textBox1 = sid and textBox2 = spw",con);
            cmd.ExecuteNonQuery();
            dataGridView1.DataSource = cmd.ExecuteNonQuery().ToString();
             * 
             * string s = ds.ToString();
            if (s.Length > 0) {
                Form2 f2 = new Form2();
                f2.ShowDialog(this);
            }

             * 
             * string str = "server = localhost;database=mydatabase;integrated security = true";
            SqlConnection con = new SqlConnection(str);
            string sql = "select * from student where sid = "+textBox1.Text + "and spw = "+textBox2.Text;
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "t");
            dataGridView1.DataSource = ds.Tables["t"];
            string s = ds.ToString();
            int i = Convert.Tolnt32
            if (s!=0)
            {
                Form2 f2 = new Form2();
                f2.ShowDialog(this);
            }

             * 
            

            Form2 f2 = new Form2();
            f2.ShowDialog(this);
            this.Close();*/
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

    }
}
