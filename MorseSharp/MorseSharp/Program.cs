using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CommandLine;
using MorseSharp.Core;

namespace MorseSharp
{
    internal class Program
    {
        internal static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<FromOptions, ToOptions>(args)
                .MapResult(
                    (FromOptions o) => ConvertFromMorse(o),
                    (ToOptions o) => ConvertToMorse(o),
                    errs => 1
                );
        }


        private static int ConvertToMorse(ToOptions o)
        {
            if (string.IsNullOrWhiteSpace(o.Input))
                Exit("Input missing.");

            int ditDuration = (int)(60.0 / (50.0 * o.Wpm) * 1000.0);
            if (o.Verbose)
                Console.WriteLine($"dit duration = {ditDuration}");

            IReadOnlyList<IReadOnlyList<MorseSymbol>> code = MorseConverter.ToMorse(o.Input!);
            foreach ((IReadOnlyList<MorseSymbol> Morse, char Char) in code.Zip(o.Input!)) {
                if (o.Verbose) {
                    Console.Write(Char);
                    Console.Write(": ");
                }
                Console.Write(string.Join("", Morse.Select(m => m.ToMorseChar())));
                if (o.Verbose)
                    Console.WriteLine();
                if (o.Play) {
                    foreach (MorseSymbol s in Morse) {
                        AudioPlayer.PlayBeep(o.Frequency, s.Duration() * ditDuration);
                        Thread.Sleep((s.Duration() + 1) * ditDuration);
                    }
                    Thread.Sleep(3 * ditDuration);
                }
            }

            return 0;
        }

        private static int ConvertFromMorse(FromOptions o)
        {
            throw new NotImplementedException();
        }

        private static void Exit(string? s, int exCode = 1)
        {
            if (!string.IsNullOrWhiteSpace(s)) {
                Console.Write(s);
                Console.WriteLine(". Press any key to continue...");
            }
            Console.ReadKey();
            Environment.Exit(exCode);
        }
    }
}
