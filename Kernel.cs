using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace Cosmosfilesystem
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
            String[] s = { "texta.txt","my.txt","xxx.txt","the.xxx"  };
            String[] s2 = {"hello world" };
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            foreach (var ss in s) 
            
            {
                filesystem.addFile(ss, s2[0]);
            
            
            
            }
            filesystem.ls();
            while (true) {; };
            Console.WriteLine();
            var input = Console.ReadLine();
            
        }
    }
    class filesystem 
    {
        static String  cantainer = "";
        public static void addFile(String files, String s) 
        {
            cantainer = cantainer + files + "\x02" + s + "\x01";
        }
        public static void ls() 
        { 
        String[] filex= cantainer.Split('\x01');
            foreach (var f in filex) 
            {
                String[] ff = f.Split('\x02');
                ff[0]=ff[0].Trim();
                if (ff[0]!="")Console.WriteLine(ff[0]);
            
            
            }
        
        }
    
    
    }



}
