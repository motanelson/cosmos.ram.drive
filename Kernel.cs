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
            filesystem.cats("xxx.txt");
            while (true) {; };
            Console.WriteLine();
            var input = Console.ReadLine();
            
        }
    }
    class filesystem 
    {
        static String  cantainer = "";
        public static String[] uses(String strings, String separator)
        {
            String[] s = { };
            int i = 0;
            String ss = strings;
            while (true)
            {
                i = ss.IndexOf(separator);
                if (i == -1)
                {
                    Array.Resize(ref s, s.Length + 1);
                    s[s.Length - 1] = ss;
                    break;
                }

                Array.Resize(ref s, s.Length + 1);
                s[s.Length - 1] = ss.Substring(0, i);
                if (i + separator.Length >= ss.Length - 1) break;
                ss = ss.Substring(i + separator.Length);




            }


            return s;



        }


        public static void addFile(String files, String s) 
        {
            cantainer = cantainer + files + "\x04\x03\x02\x01" + s + "\x05\x03\x02\x01";
        }
        public static void ls() 
        { 
        String[] filex= uses(cantainer,"\x05\x03\x02\x01");
            foreach (var f in filex) 
            {
                String[] ff = uses(f,"\x04\x03\x02\x01");
                ff[0]=ff[0].Trim();
                if (ff[0]!="")Console.WriteLine(ff[0]);
            
            
            }
        
        }
        public static void cats(String files)
        {
            String[] filex = uses(cantainer, "\x05\x03\x02\x01");
            foreach (var f in filex)
            {
                String[] ff = uses(f, "\x04\x03\x02\x01");
                ff[0] = ff[0].Trim();
                if (ff[0] != "") 
                {
                    if (ff[0].Trim()==files.Trim())Console.WriteLine(ff[1]);
                
                } 


            }

        }


    }



}
