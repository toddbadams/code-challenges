using System;
using TimeToSpeech.Application;

namespace TimeToSpeech.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write(new WrittenTimeProcessor().Process(args == null || args.Length == 0
                ? DateTime.Now.ToString("hh:mm")
                : args[0]));
        }
    }
}
