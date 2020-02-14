using System;

namespace KijiLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Interpreter(System.Console.Out);

            interpreter.ExecuteCommand("set a 9");
            interpreter.ExecuteCommand("print a");
        }
    }
}
