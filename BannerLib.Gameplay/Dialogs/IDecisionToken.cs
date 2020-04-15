using JetBrains.Annotations;

namespace BannerLib.Gameplay.Dialogs
{
    /// <summary>
    /// Represents a token which acts as an input token for multiple player dialog lines, i.e. allows multiple answers for player.
    /// </summary>
    [PublicAPI]
    public interface IDecisionToken : IPlayerDialogToken
    {
        /// <summary>
        /// Adds a player's response for current decision token.
        /// </summary>
        /// <param name="tokenName"></param>
        /// <param name="callback">this callback is called with newly created <see cref="IPlayerDialogToken"/></param>
        /// <returns>This <see cref="IDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IDecisionToken AddVariant([NotNull] string tokenName, [NotNull] DecisionVariantTokenCallback callback);
    }
}