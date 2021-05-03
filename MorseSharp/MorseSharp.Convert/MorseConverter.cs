using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MorseSharp.Core
{
    public static class MorseConverter
    {
        private static readonly ImmutableSortedDictionary<char, MorseSymbol[]> _alphabet = new Dictionary<char, MorseSymbol[]>() {
            { 'A' , new[] { MorseSymbol.Dit, MorseSymbol.Dah } },
            { 'B' , new[] { MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit } },
            { 'C' , new[] { MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dit } },
            { 'D' , new[] { MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dit } },
            { 'E' , new[] { MorseSymbol.Dit } },
            { 'F' , new[] { MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dit } },
            { 'G' , new[] { MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dit } },
            { 'H' , new[] { MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit } },
            { 'I' , new[] { MorseSymbol.Dit, MorseSymbol.Dit } },
            { 'J' , new[] { MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah } },
            { 'K' , new[] { MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dah } },
            { 'L' , new[] { MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dit } },
            { 'M' , new[] { MorseSymbol.Dah, MorseSymbol.Dah } },
            { 'N' , new[] { MorseSymbol.Dah, MorseSymbol.Dit } },
            { 'O' , new[] { MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah } },
            { 'P' , new[] { MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dit } },
            { 'Q' , new[] { MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dah } },
            { 'R' , new[] { MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dit } },
            { 'S' , new[] { MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit } },
            { 'T' , new[] { MorseSymbol.Dah } },
            { 'U' , new[] { MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dah } },
            { 'V' , new[] { MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dah } },
            { 'W' , new[] { MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dah } },
            { 'X' , new[] { MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dah } },
            { 'Y' , new[] { MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dah } },
            { 'Z' , new[] { MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dit } },
            { '0' , new[] { MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah } },
            { '1' , new[] { MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah } },
            { '2' , new[] { MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah } },
            { '3' , new[] { MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dah, MorseSymbol.Dah } },
            { '4' , new[] { MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dah } },
            { '5' , new[] { MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit } },
            { '6' , new[] { MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit } },
            { '7' , new[] { MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dit, MorseSymbol.Dit } },
            { '8' , new[] { MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dit, MorseSymbol.Dit } },
            { '9' , new[] { MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dah, MorseSymbol.Dit } },
        }.ToImmutableSortedDictionary();


        public static IReadOnlyList<MorseSymbol> ToMorse(char c) 
            => _alphabet.TryGetValue(char.ToUpper(c), out MorseSymbol[]? code) ? code : throw new ArgumentException($"No translation present for: {c}");

        public static IReadOnlyList<IReadOnlyList<MorseSymbol>> ToMorse(string input)
            => input.ToUpperInvariant().Select(ToMorse).ToList().AsReadOnly();
    }
}
