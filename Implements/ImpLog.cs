using System;
using API;
namespace Implements
{
    public class ImpLog : LogInterface
    {
        // public static string JointDir()
        // {
        //     for(int i=0;i<10;i++)
        //     {
        //         string address=AppContext.BaseDirectory;
        //         if (Directory.Exists(address + "Log"))
        //         {
        //             return address;
        //         }
        //         else
        //         {
        //             address+="..";
        //             Console.WriteLine(address);
        //         }
        //     }
        //     return ".";
        // }
        public void Log(string[] text)
        {
            DateTime dateTime = DateTime.Now;
            tiaozhuan:
            if(Directory.Exists("./Log")){
                if(File.Exists("./Log/"+dateTime.ToString("yyyy-MM-dd")+".txt")){
                    File.AppendAllText("./Log/"+dateTime.ToString("yyyy-MM-dd")+".txt","\n["+dateTime.ToString("HH:mm:ss")+"]"+text[0]);
                    for(int i=1;i<text.Length;i++){
                        File.AppendAllText("./Log/"+dateTime.ToString("yyyy-MM-dd")+".txt"," "+text[i]);
                    }
                }
                else{
                    File.WriteAllText("./Log/"+dateTime.ToString("yyyy-MM-dd")+".txt","["+dateTime.ToString("HH:mm:ss")+"]"+text[0]);
                    for(int i=1;i<text.Length;i++){
                        File.AppendAllText("./Log/"+dateTime.ToString("yyyy-MM-dd")+".txt"," "+text[i]);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory("./Log");
                goto tiaozhuan;
            }
        }
    }
}