using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Dialogs
{
    /// <summary>
    /// Represents a player's response dialog line.
    /// </summary>
    [PublicAPI]
    public interface IPlayerDialogToken : IDialogToken
    {
        /// <summary>
        /// Sets new condition callback delegate for this token
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>This <see cref="IPlayerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IPlayerDialogToken SetCondition([NotNull] ConversationSentence.OnConditionDelegate condition);

        /// <summary>
        /// Sets new consequence callback delegate for this token
        /// </summary>
        /// <param name="consequence"></param>
        /// <returns>This <see cref="IPlayerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IPlayerDialogToken SetConsequence([NotNull] ConversationSentence.OnConsequenceDelegate consequence);

        /// <summary>
        /// Sets facial expressions for player's character (usually useless, unless you've set camera to players' character)
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns>This <see cref="IPlayerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IPlayerDialogToken SetExpressions([NotNull] Expressions expressions);

        /// <summary>
        /// Sets new priority value for this dialog token.
        /// </summary>
        /// <param name="priority"></param>
        /// <returns>This <see cref="IPlayerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IPlayerDialogToken SetPriority(int priority);

        /// <summary>
        /// Opens a barter window between player and conversation partner.
        /// </summary>
        /// <param name="acquireBarterables"></param>
        /// <returns>Newly created <see cref="IBarterResultToken"/></returns>
        [PublicAPI]
        [NotNull]
        IBarterResultToken Barter([NotNull] AcquireBarterablesCallback acquireBarterables);

        /// <summary>
        /// Creates a partner's response to this player token.
        /// </summary>
        /// <param name="tokenName"></param>
        /// <returns>Newly created <see cref="IPartnerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IPartnerDialogToken Response([NotNull] string tokenName);

        /// <summary>
        /// Sets custom output token to current token and finish this token, returning to it's input <see cref="IPartnerDialogToken"/> or null.
        /// </summary>
        /// <param name="outputToken">Output token name, which should be set to this token</param>
        /// <returns><see cref="IPartnerDialogToken"/> instance by which this <see cref="IPlayerDialogToken"/> was created or null if input token has other type.</returns>
        [PublicAPI]
        [CanBeNull]
        IPartnerDialogToken SetOutputAndEnd([NotNull] string outputToken);

        /// <summary>
        /// Finishes this token and returns it's input <see cref="IPartnerDialogToken"/> or null.
        /// </summary>
        /// <returns><see cref="IPartnerDialogToken"/> instance by which this <see cref="IPlayerDialogToken"/> was created or null if input token has other type.</returns>
        [PublicAPI]
        [CanBeNull]
        IPartnerDialogToken End();
    }
}