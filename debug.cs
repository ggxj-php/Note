using System;
using Implements;

class Debug
{
    public static void Main()
    {
        Console.WriteLine("=== 文本批量去重工具 ===");
        Console.Write("请输入源文件夹路径: ");
        string sourceDir = Console.ReadLine();

        Console.Write("请输入目标文件夹路径: ");
        string targetDir = Console.ReadLine();

        Console.WriteLine("\n开始批量去重...");
        new ImpReplace().BatchRemoveDup(sourceDir, targetDir);
    }
}
