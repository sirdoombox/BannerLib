using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Dialogs
{
    /// <summary>
    /// Base type for any dialog token.
    /// </summary>
    [PublicAPI]
    public interface IDialogToken
    {
        /// <summary>
        /// Complete this dialog tree and add it's lines to <see cref="ConversationManager"/>
        /// </summary>
        [PublicAPI]
        void Build();
    }
}