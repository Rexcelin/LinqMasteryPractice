using System;
namespace EventManager
{
    public class EventExample
    {
            //public delegate void delgName<T>(T m);
            //public void Display<Type>(Type msg)
            //{
            //Console.WriteLine(msg);
            //}

        public bool Check(string s)
        {
            //return string.IndexOf(ch);
            return s == new string(s.Reverse().ToArray());
        }
        public void Run()
        {
            //delgName<string> a = Display;
            //a("hello");
            Predicate<string> m = Check;
            Console.WriteLine(m("world"));
            Console.WriteLine(m("hello"));
        }
        //public void Run()
        //{
        //    Func<string, char, int> m = Check;
        //    Console.WriteLine(m("world", 'r'));
        //    Console.WriteLine(m("hello", 'z'));

        //}

    }
    }

