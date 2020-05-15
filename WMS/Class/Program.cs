using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
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
            //Application.Run(new WMSlogin());
            WMSlogin login = new WMSlogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new WMSnewHome(login.userName));//main窗体的构造方法
            }
        }
    }
}
