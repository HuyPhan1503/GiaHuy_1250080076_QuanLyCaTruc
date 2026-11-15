using System;
using System.Windows.Forms;
using QuanLyCaVanHanh.Forms;

namespace QuanLyCaVanHanh
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var dangNhap = new FrmDangNhap())
            {
                if (dangNhap.ShowDialog() != DialogResult.OK) return;
            }
            Application.Run(new FrmMain());
        }
    }
}