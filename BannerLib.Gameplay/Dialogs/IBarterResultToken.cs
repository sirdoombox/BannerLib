using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Dialogs
{
    /// <summary>
    /// Represents a barter during dialog.
    /// </summary>
    [PublicAPI]
    public interface IBarterResultToken : IDialogToken
    {
        /// <summary>
        /// Creates a partner's response with predefined condition if barter was accepted.
        /// </summary>
        /// <remarks>Never do call <see cref="IPartnerDialogToken.SetCondition"/> for returned instance of <see cref="IPartnerDialogToken"/>!</remarks>
        /// <param name="tokenName"></param>
        /// <param name="callback">this callback is called with newly created <see cref="IPartnerDialogToken"/></param>
        /// <returns>Newly created <see cref="IBarterResultToken"/></returns>
        [PublicAPI]
        [NotNull]
        IBarterResultToken BarterAccept([NotNull] string tokenName, [NotNull] BarterOfferTokenCallback callback);

        /// <summary>
        /// Creates a partner's response with predefined condition if barter was rejected.
        /// </summary>
        /// <remarks>Never do call <see cref="IPartnerDialogToken.SetCondition"/> for returned instance of <see cref="IPartnerDialogToken"/>!</remarks>
        /// <param name="tokenName"></param>
        /// <param name="callback">this callback is called with newly created <see cref="IPartnerDialogToken"/></param>
        /// <returns>Newly created <see cref="IBarterResultToken"/></returns>
        [PublicAPI]
        [NotNull]
        IBarterResultToken BarterReject([NotNull] string tokenName, [NotNull] BarterOfferTokenCallback callback);

        /// <summary>
        /// Creates a partner's response after barter window is closed (whether barter was accepted or rejected).
        /// </summary>
        /// <param name="tokenName"></param>
        /// <param name="callback">this callback is called with newly created <see cref="IPartnerDialogToken"/></param>
        /// <returns>Newly created <see cref="IPartnerDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        IBarterResultToken BarterResult([NotNull] string tokenName, [NotNull] BarterOfferTokenCallback callback);

        /// <summary>
        /// Sets barter context initializer
        /// </summary>
        /// <param name="initializer"></param>
        /// <returns>This <see cref="IBarterResultToken"/></returns>
        [PublicAPI]
        [NotNull]
        IBarterResultToken ContextInitializer([NotNull] BarterManager.BarterContextInitializer initializer);

        /// <summary>
        /// Sets persuasion cost reduction value for BarterManager.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns>This <see cref="IBarterResultToken"/></returns>
        [PublicAPI]
        [NotNull]
        IBarterResultToken PersuasionCostReduction([NotNull] BarterPersuasionCostReduction callback);

        /// <summary>
        /// Finishes this token and returns it's input <see cref="IPlayerDialogToken"/> or null.
        /// </summary>
        /// <returns></returns>
        [PublicAPI]
        [CanBeNull]
        IPlayerDialogToken End();
    }
}