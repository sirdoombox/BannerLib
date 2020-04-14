using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Dialogs
{
    /// <summary>
    /// Input token with value "start", does not represents any actual dialog line, just an input token name.
    /// </summary>
    [PublicAPI]
    public interface IInputDialogToken : IDialogToken
    {
        /// <summary>
        /// Creates new dialog token for dialog partner.
        /// </summary>
        /// <param name="tokenName">Unique token ID</param>
        /// <param name="condition">Condition to check whether this dialog line could appear</param>
        /// <returns>Newly created dialog token</returns>
        [PublicAPI]
        [NotNull]
        IPartnerDialogToken AddDialogLine([NotNull] string tokenName,
            [CanBeNull] ConversationSentence.OnConditionDelegate condition = null);

        /// <summary>
        /// Creates new dialog token for player.
        /// </summary>
        /// <param name="tokenName">Unique token ID </param>
        /// <param name="condition">Condition to check whether this dialog line could appear</param>
        /// <returns>Newly created dialog token</returns>
        [PublicAPI]
        [NotNull]
        IPlayerDialogToken AddPlayerLine([NotNull] string tokenName,
            [CanBeNull] ConversationSentence.OnConditionDelegate condition = null);
    }
}