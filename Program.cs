using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BattleshipGame
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            KillPreviousInstances();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void KillPreviousInstances()
        {
            Process current = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(current.ProcessName))
            {
                if (process.Id != current.Id) process.Kill();
            }
        }
    }
}