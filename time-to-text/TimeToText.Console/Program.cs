using System;
using TimeToSpeech.Application;

namespace TimeToSpeech.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.Write(new Time(args == null || args.Length == 0
                ? DateTime.Now.ToString("hh:mm")
                : args[0]));
        }
    }
}
