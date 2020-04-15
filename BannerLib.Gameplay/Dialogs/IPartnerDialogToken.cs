using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Dialogs
{
    /// <summary>
    /// Represents a dialog partner's response line.
    /// </summary>
    [PublicAPI]
    public interface IPartnerDialogToken : IDialogToken
    {
        /// <summary>
        /// Sets new condition callback delegate for this token
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>This <see cref="IPartnerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IPartnerDialogToken SetCondition([NotNull] ConversationSentence.OnConditionDelegate condition);

        /// <summary>
        /// Sets new consequence callback delegate for this token
        /// </summary>
        /// <param name="consequence"></param>
        /// <returns>This <see cref="IPartnerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IPartnerDialogToken SetConsequence([NotNull] ConversationSentence.OnConsequenceDelegate consequence);

        /// <summary>
        /// Sets facial expressions for partner's character.
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns>This <see cref="IPartnerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IPartnerDialogToken SetExpressions([NotNull] Expressions expressions);

        /// <summary>
        /// Sets priority value for this dialog token.
        /// </summary>
        /// <param name="priority"></param>
        /// <returns>This <see cref="IPartnerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IPartnerDialogToken SetPriority(int priority);

        /// <summary>
        /// Sets output token value to "close_window" and returns this <see cref="IPartnerDialogToken"/>'s input <see cref="IPlayerDialogToken"/>.
        /// </summary>
        /// <returns><see cref="IPlayerDialogToken"/> instance by which this <see cref="IPartnerDialogToken"/> was created or null if input token has other type.</returns>
        [PublicAPI]
        [CanBeNull]
        IPlayerDialogToken CloseWindow();

        /// <summary>
        /// Creates a new decision token, which allows for multiple player's response dialog lines.
        /// </summary>
        /// <returns>Newly created <see cref="IDecisionToken"/></returns>
        [PublicAPI]
        [NotNull]
        IDecisionToken Decision();

        /// <summary>
        /// Creates a new player response line.
        /// </summary>
        /// <param name="tokenName"></param>
        /// <returns>Newly created <see cref="IPlayerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IPlayerDialogToken Response([NotNull] string tokenName);

        /// <summary>
        /// Sets custom output token to current token and finish this token, returning to it's input <see cref="IPlayerDialogToken"/> or null.
        /// </summary>
        /// <param name="outputToken">Output token name, which should be set to this token</param>
        /// <returns><see cref="IPlayerDialogToken"/> instance by which this <see cref="IPartnerDialogToken"/> was created or null if input token has other type.</returns>
        [PublicAPI]
        [CanBeNull]
        IPlayerDialogToken SetOutputAndEnd([NotNull] string outputToken);

        /// <summary>
        /// Finishes this token and returns it's input <see cref="IPlayerDialogToken"/> or null.
        /// </summary>
        /// <returns><see cref="IPlayerDialogToken"/> instance by which this <see cref="IPartnerDialogToken"/> was created or null if input token has other type.</returns>
        [PublicAPI]
        [CanBeNull]
        IPlayerDialogToken End();
    }
}