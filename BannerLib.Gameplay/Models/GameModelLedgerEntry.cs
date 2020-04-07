using System;

namespace BannerLib.Gameplay.Models
{
    /// <summary>
    /// Describes a replacement, addition or decoration operation that took place via BannerLib.
    /// </summary>
    public class GameModelLedgerEntry
    {
        /// <summary>
        /// The base type of the replacement in question.
        /// </summary>
        public Type BaseType { get; }
        /// <summary>
        /// The original type that was replaced.
        /// </summary>
        public Type Original { get; }
        /// <summary>
        /// The replacement type.
        /// </summary>
        public Type Replacement { get; }

        internal GameModelLedgerEntry(Type original, Type replacement)
        {
            Original = original;
            Replacement = replacement;
            BaseType = original?.BaseType;
        }
    }
}