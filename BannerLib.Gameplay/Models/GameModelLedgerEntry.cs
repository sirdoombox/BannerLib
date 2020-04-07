using System;

namespace BannerLib.Gameplay.Models
{
    public class GameModelLedgerEntry
    {
        public Type BaseType { get; }
        public Type Original { get; }
        public Type Replacement { get; }

        public GameModelLedgerEntry(Type original, Type replacement)
        {
            Original = original;
            Replacement = replacement;
            BaseType = original?.BaseType;
        }
    }
}