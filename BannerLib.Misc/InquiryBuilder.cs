using System;
using TaleWorlds.Core;

namespace BannerLib
{
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

        public static InquiryBuilder Create(string title)
        {
            return new InquiryBuilder(title);
        }

        public InquiryBuilder WithDescription(string descriptionText)
        {
            m_descriptionText = descriptionText;
            return this;
        }

        public InquiryBuilder WithAffirmative(Action onAffirmative, string affirmativeText = "")
        {
            if (!string.IsNullOrWhiteSpace(affirmativeText)) m_affirmativeText = affirmativeText;
            m_affirmativeAction = onAffirmative ?? 
                                  throw new ArgumentException("Action should not be null.", nameof(onAffirmative));
            return this;
        }

        public InquiryBuilder WithNegative(Action onNegative, string negativeText = "")
        {
            if (!string.IsNullOrWhiteSpace(negativeText)) m_negativeText = negativeText;
            m_negativeAction = onNegative ?? 
                               throw new ArgumentException("Action should not be null.", nameof(onNegative));
            m_withNegative = true;
            return this;
        }

        public InquiryData Build()
        {
            return new InquiryData(m_title, m_descriptionText, c_WITH_AFFIRMATIVE, m_withNegative, m_affirmativeText,
                m_negativeText, m_affirmativeAction, m_negativeAction);
        }

        public void BuildAndPublish(bool pauseGameActiveState)
        {
            InformationManager.ShowInquiry(Build(), pauseGameActiveState);
        }
    }
}