using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager
{
    public class Fileh
    {
        public void Run()
        {
            string? path = "demo1.txt";
            File.WriteAllText("d1.txt", "hi");
            /*
            string? content = "hello SAS , Muthu, Rex , Naga ";
            //File.WriteAllText(path, content);
            File.AppendAllText(path, content);  
            string Filedata = File.ReadAllText(path);
            Console.WriteLine(Filedata);
            */
            FileInfo f1 = new FileInfo(path);
            Console.WriteLine(f1.Exists);
            Console.WriteLine(f1.FullName);
            Console.WriteLine(f1.Name);
            Console.WriteLine(f1.DirectoryName);
            Console.WriteLine(f1.CreationTime);
            Console.WriteLine(f1.LastWriteTime);
            Console.WriteLine(f1.IsReadOnly);
            f1.CopyTo("zxcvbll.txt");
            f1.CopyTo("zxcvbll.txt", true);
            string Filedata = File.ReadAllText("zxcvbll.txt");
            Console.WriteLine(Filedata);

            f1.Refresh();


        }
    }
}
