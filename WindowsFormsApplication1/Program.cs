using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 F1 = new Form1();
            F1.StartPosition = FormStartPosition.CenterScreen;
            F1.ShowDialog();

            Form2 F2 = new Form2();
            F2.StartPosition = FormStartPosition.CenterScreen;

            Form3 F3 = new Form3();
            F3.StartPosition = FormStartPosition.CenterScreen;

        }
    }
}
