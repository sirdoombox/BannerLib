using System;
using TaleWorlds.Core;

namespace BannerLib.Misc
{
    /// <summary>
    /// Used to build <see cref="InquiryData"/> for <see cref="InformationManager.ShowInquiry"/>
    /// </summary>
    public class InquiryBuilder
    {
        private readonly string m_title;
        private string m_descriptionText = string.Empty;
        private const bool c_WITH_AFFIRMATIVE = true;
        private bool m_withNegative = false;
        private Action m_affirmativeAction = () => { };
        private Action m_negativeAction = () => { };
        private string m_affirmativeText = "OK";
        private string m_negativeText = "Cancel";

        private InquiryBuilder(string title)
        {
            m_title = title;
        }
        
        /// <summary>
        /// Create a new InquiryBuilder.
        /// </summary>
        /// <param name="title">The title that will be displayed at the top of the inquiry.</param>
        /// <returns>This <see cref="InquiryBuilder"/> for chaining method calls.</returns>
        public static InquiryBuilder Create(string title)
        {
            return new InquiryBuilder(title);
        }
        
        /// <summary>
        /// Adds description text to an inquiry.
        /// </summary>
        /// <param name="descriptionText">The description text that will be shown.</param>
        /// <returns>This <see cref="InquiryBuilder"/> for chaining method calls.</returns>
        public InquiryBuilder WithDescription(string descriptionText)
        {
            m_descriptionText = descriptionText;
            return this;
        }
        
        /// <summary>
        /// While every Inquiry has an Affirmative, this allows you to set what happens when it is clicked and what the text on the button is.
        /// </summary>
        /// <param name="affirmativeText">The text displayed on the affirmative button.</param>
        /// <param name="onAffirmative">Callback called when the player clicks the affirmative button.</param>
        /// <returns>This <see cref="InquiryBuilder"/> for chaining method calls.</returns>
        public InquiryBuilder WithAffirmative(string affirmativeText = "", Action onAffirmative = null)
        {
            if (!string.IsNullOrWhiteSpace(affirmativeText)) m_affirmativeText = affirmativeText;
            m_affirmativeAction = onAffirmative ?? 
                                  (() => { });
            return this;
        }
        
        /// <summary>
        /// Adds a negative button to the inquiry.
        /// </summary>
        /// <param name="negativeText">The text displayed on the negative button.</param>
        /// <param name="onNegative">Callback called when the player clicks the negative button.</param>
        /// <returns>This <see cref="InquiryBuilder"/> for chaining method calls.</returns>
        public InquiryBuilder WithNegative(string negativeText = "", Action onNegative = null)
        {
            if (!string.IsNullOrWhiteSpace(negativeText)) m_negativeText = negativeText;
            m_negativeAction = onNegative ?? 
                               (() => { });
            m_withNegative = true;
            return this;
        }
        
        /// <summary>
        /// Builds the <see cref="InquiryData"/> up for use in <see cref="InformationManager.ShowInquiry"/>
        /// </summary>
        /// <returns>The built <see cref="InquiryData"/></returns>
        public InquiryData Build()
        {
            return new InquiryData(m_title, m_descriptionText, c_WITH_AFFIRMATIVE, m_withNegative, m_affirmativeText,
                m_negativeText, m_affirmativeAction, m_negativeAction);
        }
        
        /// <summary>
        /// Builds the <see cref="InquiryData"/> and immediately displays it in-game.
        /// </summary>
        /// <param name="pauseGameActiveState">Should the game be paused whilst your inquiry is being displayed?</param>
        public void BuildAndPublish(bool pauseGameActiveState)
        {
            InformationManager.ShowInquiry(Build(), pauseGameActiveState);
        }
    }
}