using System;
using Beep.Module;
using NullLib.ArgsAnalysis;
using NullLib.ArgsAnalysis.Analyzers;

namespace Beep
{
    class Program
    {
        static StartupArgs args;
        static void Main(string[] sysargs)
        {
            InitializeApplication(sysargs);
            if (args.Beep)
            {
                Console.Beep(37, 1000);
            }
            else if (args.Help)
            {

            }
            else
            {

            }
        }
        static void InitializeApplication(string[] sysargs)
        {
            NArgsAnalyzer argsAnalyzers = new NArgsAnalyzer()
            {
                new CommandAnalyzer()
                {
                    new FieldAnalyzer()
                }
            };
            argsAnalyzers.IgnoreCases = true;
            argsAnalyzers.Analysis(sysargs);
            args = argsAnalyzers.ToObject<StartupArgs>();
        }
    }
}
