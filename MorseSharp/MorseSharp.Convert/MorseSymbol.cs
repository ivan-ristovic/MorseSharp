namespace MorseSharp.Core
{
    public enum MorseSymbol
    {
        Dit,
        Dah,
    }

    public static class MorseSymbolExtensions
    {
        public static char ToMorseChar(this MorseSymbol symbol)
        {
            return symbol switch {
                MorseSymbol.Dit => '.',
                MorseSymbol.Dah => '-',
                _ => '?',
            };
        }

        public static int Duration(this MorseSymbol symbol)
        {
            return symbol switch {
                MorseSymbol.Dit => 1,
                MorseSymbol.Dah => 3,
                _ => '?',
            };
        }
    }
}
