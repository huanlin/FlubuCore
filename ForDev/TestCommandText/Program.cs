using System;
using FlubuCore.Scripting;

namespace TestCommandText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engine = new FlubuEngine();
            engine.RunScript<BuildScript>(new string[] { "compile" });
        }
    }
}