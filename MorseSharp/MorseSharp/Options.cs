using CommandLine;

namespace MorseSharp
{
    [Verb("to", HelpText = "Convert to Morse")]
    internal sealed class ToOptions
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages")]
        public bool Verbose { get; set; }

        [Option('p', "play", Required = false, HelpText = "Play the output (Windows only)")]
        public bool Play { get; set; }

        [Option('w', "wpm", Required = false, HelpText = "WPM (words per minute)", Default = 10)]
        public int Wpm { get; set; }

        [Option('f', "freq", Required = false, HelpText = "Beep frequency", Default = 1000)]
        public ushort Frequency { get; set; }

        [Value(0, Required = true, HelpText = "Specification path")]
        public string? Input { get; set; }
    }

    [Verb("from", HelpText = "Convert from Morse")]
    internal sealed class FromOptions
    {

    }
}
