using System;
using System.IO;
using API;
using JiebaNet.Segmenter;

namespace Implements
{
    public class ImpJieba : JiebaInterface
    {
        public string[] Cut(string text)
        {
            try
            {
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                string dictPath = Path.Combine(appDir, "Resources");
                
                JiebaNet.Segmenter.ConfigManager.ConfigFileBaseDir = dictPath;
                var segmenter = new JiebaSegmenter();
                new ImpLog().Log(["分词统计", "目标文本:" + text]);
                var result = segmenter.Cut(text).ToArray();
                new ImpLog().Log(["分词结果", "分词数量:" + result.Length.ToString(), "结果:" + string.Join("|", result)]);
                return result;
            }
            catch (Exception ex)
            {
                new ImpLog().Log(["分词异常", "错误信息:" + ex.Message, "异常类型:" + ex.GetType().Name]);
                throw;
            }
        }
    }
}
