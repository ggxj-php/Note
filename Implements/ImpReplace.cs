using System;
using System.IO;
using System.Collections.Generic;
using API;
using System.Collections;

namespace Implements
{
    public class ImpReplace : ReplaceInterface
    {
        public void BatchRemoveDup(string sourceDir, string targetDir)
        {
            if (!Directory.Exists(sourceDir))
            {
                new ImpLog().Log(new string[] { "批量去重", "错误", "源目录不存在:" + sourceDir });
                Console.WriteLine("错误：源目录不存在");
                return;
            }

            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
                new ImpLog().Log(new string[] { "批量去重", "创建目标目录:" + targetDir });
            }

            new ImpLog().Log(new string[] { "批量去重", "开始", "源目录:" + sourceDir, "目标目录:" + targetDir });

            CopyAndRemoveDup(sourceDir, targetDir);

            new ImpLog().Log(new string[] { "批量去重", "完成", "源目录:" + sourceDir, "目标目录:" + targetDir });
            Console.WriteLine("批量去重完成");
        }

        private void CopyAndRemoveDup(string source, string target)
        {
            foreach(string file in Directory.GetFiles(source))
            {
                string fileName = Path.GetFileName(file);
                string targetFile = Path.Combine(target, fileName);
                string content = File.ReadAllText(file);
                string result = RemoveDup(content);
                File.WriteAllText(targetFile, result);
                new ImpLog().Log(new string[] { "批量去重", "处理:" + file });
                Console.WriteLine("处理: " + file);
            }

            foreach(string dir in Directory.GetDirectories(source))
            {
                string dirName = Path.GetFileName(dir);
                string targetDir = Path.Combine(target, dirName);
                if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);
                CopyAndRemoveDup(dir, targetDir);//递归进入子文件夹去重
            }
        }

        private string RemoveDup(string content)
        {
            HashSet<string> result = new HashSet<string>();
            foreach(string line in content.Split(new[]{'\n','\r'})){
                if(line!=""){
                    result.Add(line);
                }
            }
            string res="";
            foreach(string line in result){
                res+=line+"\n";
            }
            return res;
        }
    }
}
