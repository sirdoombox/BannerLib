using JetBrains.Annotations;

namespace BannerLib.Gameplay.Dialogs
{
    /// <summary>
    /// Represents expression animations tags.
    /// </summary>
    public class Expressions
    {
        /// <summary>
        /// Tags group
        /// </summary>
        public enum Key
        {
            /// <summary>
            /// Tags starting with "ib:"
            /// </summary>
            IdleBody,

            /// <summary>
            /// Tags starting with "if:"
            /// </summary>
            IdleFace,

            /// <summary>
            /// Tags starting with "rb:"
            /// </summary>
            ReactionBody,

            /// <summary>
            /// Tags starting with "rf:"
            /// </summary>
            ReactionFace,
        }

        /// <summary>
        /// Expressions from tags group "ib:"
        /// </summary>
        public static class IdleBody
        {
            /// <summary>
            /// [ib:aggressive]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions Aggressive = new Expressions(Key.IdleBody, "aggressive");

            /// <summary>
            /// [ib:closed]
            /// </summary>
            [PublicAPI] [NotNull] public static readonly Expressions Closed = new Expressions(Key.IdleBody, "closed");

            /// <summary>
            /// [ib:normal]
            /// </summary>
            [PublicAPI] [NotNull] public static readonly Expressions Normal = new Expressions(Key.IdleBody, "normal");

            /// <summary>
            /// [ib:warrior]
            /// </summary>
            [PublicAPI] [NotNull] public static readonly Expressions Warrior = new Expressions(Key.IdleBody, "warrior");

            /// <summary>
            /// [ib:demure]
            /// </summary>
            [PublicAPI] [NotNull] public static readonly Expressions Demure = new Expressions(Key.IdleBody, "demure");
        }

        /// <summary>
        /// Expressions from tags group "if:"
        /// </summary>
        public static class IdleFace
        {
            /// <summary>
            /// [if:idle_angry]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions IdleAngry = new Expressions(Key.IdleFace, "idle_angry");

            /// <summary>
            /// [if:idle_happy]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions IdleHappy = new Expressions(Key.IdleFace, "idle_happy");

            /// <summary>
            /// [if:idle_insulted]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions IdleInsulted = new Expressions(Key.IdleFace, "idle_insulted");

            /// <summary>
            /// [if:idle_pleased]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions IdlePleased = new Expressions(Key.IdleFace, "idle_pleased");

            /// <summary>
            /// [if:idle_despise]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions IdleDespise = new Expressions(Key.IdleFace, "idle_despise");

            /// <summary>
            /// [if:idle_cheering1]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions IdleCheering1 = new Expressions(Key.IdleFace, "idle_cheering1");

            /// <summary>
            /// [if:idle_cheering2]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions IdleCheering2 = new Expressions(Key.IdleFace, "idle_cheering2");

            /// <summary>
            /// [if:idle_sick]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions IdleSick = new Expressions(Key.IdleFace, "idle_sick");

            /// <summary>
            /// [if:convo_composed]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoComposed = new Expressions(Key.IdleFace, "convo_composed");

            /// <summary>
            /// [if:convo_nonchalant]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoNonchalant = new Expressions(Key.IdleFace, "convo_nonchalant");

            /// <summary>
            /// [if:convo_delighted]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoDelighted = new Expressions(Key.IdleFace, "convo_delighted");

            /// <summary>
            /// [if:convo_happy]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoHappy = new Expressions(Key.IdleFace, "convo_happy");

            /// <summary>
            /// [if:convo_stonefaced]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoStonefaced = new Expressions(Key.IdleFace, "convo_stonefaced");

            /// <summary>
            /// [if:convo_grave]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoGrave = new Expressions(Key.IdleFace, "convo_grave");

            /// <summary>
            /// [if:convo_irritable]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoIrritable = new Expressions(Key.IdleFace, "convo_irritable");

            /// <summary>
            /// [if:convo_mocking]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoMocking = new Expressions(Key.IdleFace, "convo_mocking");

            /// <summary>
            /// [if:convo_insidious]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoInsidious = new Expressions(Key.IdleFace, "convo_insidious");

            /// <summary>
            /// [if:convo_bent]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoBent = new Expressions(Key.IdleFace, "convo_bent");

            /// <summary>
            /// [if:convo_grim]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoGrim = new Expressions(Key.IdleFace, "convo_grim");

            /// <summary>
            /// [if:convo_charitable]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoCharitable = new Expressions(Key.IdleFace, "convo_charitable");

            /// <summary>
            /// [if:convo_merry]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoMerry = new Expressions(Key.IdleFace, "convo_merry");

            /// <summary>
            /// [if:convo_friendly]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions ConvoFriendly = new Expressions(Key.IdleFace, "convo_friendly");

            /// <summary>
            /// [if:talking_happy]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions TalkingHappy = new Expressions(Key.IdleFace, "talking_happy");

            /// <summary>
            /// [if:happy]
            /// </summary>
            [PublicAPI] [NotNull] public static readonly Expressions Happy = new Expressions(Key.IdleFace, "happy");
        }

        /// <summary>
        /// Expressions from tags group "rb:"
        /// </summary>
        public static class ReactionBody
        {
            /// <summary>
            /// [rb:very_negative]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions VeryNegative = new Expressions(Key.ReactionBody, "very_negative");

            /// <summary>
            /// [rb:negative]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions Negative = new Expressions(Key.ReactionBody, "negative");

            /// <summary>
            /// [rb:positive]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions Positive = new Expressions(Key.ReactionBody, "positive");

            /// <summary>
            /// [rb:very_positive]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions VeryPositive = new Expressions(Key.ReactionBody, "very_positive");

            /// <summary>
            /// [rb:unsure]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions Unsure = new Expressions(Key.ReactionBody, "unsure");

            /// <summary>
            /// [rb:trivial]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions Trivial = new Expressions(Key.ReactionBody, "trivial");
        }

        /// <summary>
        /// Expressions from tags group "rf:"
        /// </summary>
        public static class ReactionFace
        {
            /// <summary>
            /// [rf:happy]
            /// </summary>
            [PublicAPI] [NotNull] public static readonly Expressions Happy = new Expressions(Key.ReactionFace, "happy");

            /// <summary>
            /// [rf:very_negative]
            /// </summary>
            [PublicAPI] [NotNull]
            public static readonly Expressions VeryNegative = new Expressions(Key.ReactionFace, "very_negative");
        }

        /// <summary>
        /// Empty string (no expressions)
        /// </summary>
        [PublicAPI] public static readonly Expressions None = new Expressions("");

        /// <summary>
        /// This tags string.
        /// </summary>
        [PublicAPI]
        public string Tag { get; }

        /// <summary>
        /// Creates new tag (with custom tag group and tag name)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="animationName"></param>
        [PublicAPI]
        public Expressions(string key, string animationName)
        {
            Tag = $"[{(string.IsNullOrEmpty(key) ? key + ':' : "")}{animationName}]";
        }

        /// <summary>
        /// Creates new tag (with predefined tag group and custom tag name)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="animationName"></param>
        [PublicAPI]
        public Expressions(Key key, string animationName)
        {
            string keyText;
            switch (key)
            {
                case Key.IdleBody:
                    keyText = "ib";
                    break;
                case Key.IdleFace:
                    keyText = "if";
                    break;
                case Key.ReactionBody:
                    keyText = "rb";
                    break;
                case Key.ReactionFace:
                    keyText = "rf";
                    break;
                default:
                    keyText = null;
                    break;
            }

            Tag = $"[{(string.IsNullOrEmpty(keyText) ? keyText + ':' : "")}{animationName}]";
        }

        private Expressions(string tag)
        {
            Tag = tag;
        }

        /// <summary>
        /// Combines two tags together.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Expressions operator |(Expressions a, Expressions b)
        {
            return new Expressions((a?.Tag ?? "") + (b?.Tag ?? ""));
        }

        //  ib is idle animations (body, I guess?)
        // if is facial idle
        // rb is idle reaction
        // rf ???
    }
}