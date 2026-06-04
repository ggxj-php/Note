using System;
using Implements;
using JiebaNet.Segmenter;

class Debug
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("请选择模式:\n1.文本批量去重\n2.文本分词\n0.退出\n-----------------");
            string pardon = Console.ReadLine();
            if(pardon=="0")
            {
                break;
            }
            else if(pardon=="1")
            {
                Console.Write("请输入源文件夹路径: ");
                string sourceDir = Console.ReadLine();
                Console.Write("请输入目标文件夹路径: ");
                string targetDir = Console.ReadLine();
                Console.WriteLine("\n开始批量去重...");
                new ImpReplace().BatchRemoveDup(sourceDir, targetDir);
            }
            else if(pardon=="2")
            {
                Console.Write("请输入待分词的文本: ");
                string text = Console.ReadLine();
                Console.WriteLine("\n开始分词...");
                string[] words = new ImpJieba().Cut(text);
                Console.WriteLine("分词结果: " + string.Join("\n", words));
            }
        }
    }
}
