using System;
using API;
namespace Implements
{
    public class ImpLog : LogInterface
    {
        public void Log(string[] text)
        {
            DateTime dateTime = DateTime.Now;
            if(File.Exists($"./Log/{dateTime:yyyy-MM-dd}.txt")){
                File.AppendAllText($"./Log/{dateTime:yyyy-MM-dd}.txt","\n["+dateTime.ToString("HH:mm:ss")+"]"+text[0]);
                for(int i=1;i<text.Length;i++){
                    File.AppendAllText($"./Log/{dateTime:yyyy-MM-dd}.txt"," "+text[i]);
                }
            }
            else{
                File.WriteAllText($"./Log/{dateTime:yyyy-MM-dd}.txt","["+dateTime.ToString("HH:mm:ss")+"]"+text[0]);
                for(int i=1;i<text.Length;i++){
                    File.AppendAllText($"./Log/{dateTime:yyyy-MM-dd}.txt"," "+text[i]);
                }
            }
        }
    }
}