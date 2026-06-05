using System;
using System.Windows.Forms;
using UI;
using Implements;
using Microsoft.VisualBasic.Logging;
class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
