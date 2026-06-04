
using System;
using API;
using JiebaNet.Segmenter;
namespace Implements
{
    public class ImpJieba : JiebaInterface
    {
        public string[] Cut(string text)
        {
            var segmenter = new JiebaSegmenter();
            new ImpLog().Log(["分词统计","目标文本:"+text]);
            return segmenter.Cut(text).ToArray();
        }
    }
}
