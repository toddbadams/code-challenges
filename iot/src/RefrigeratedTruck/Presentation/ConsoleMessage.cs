using System;

namespace RefrigeratedTruck.Presentation
{
    public class ConsoleMessage
    {
        private static void ColorMessage(string text, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void Green(string text)
        {
            ColorMessage(text, ConsoleColor.Green);
        }

        public static void Amber(string text)
        {
            ColorMessage(text, ConsoleColor.Yellow);
        }

        public static void Red(string text)
        {
            ColorMessage(text, ConsoleColor.Red);
        }
    }
}