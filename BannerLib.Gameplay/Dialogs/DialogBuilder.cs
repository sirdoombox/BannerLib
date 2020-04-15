using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Dialogs
{
    /// <summary>
    /// Builder for new dialog token lines.
    /// </summary>
	public class DialogBuilder
	{
		private abstract class DialogToken : IDialogToken
		{
			[NotNull] private readonly DialogBuilder _builder;

			[NotNull] protected DialogBuilder Builder => _builder;

			[CanBeNull] public DialogToken InputToken { get; }
			[NotNull] public string TokenName { get; }
			[NotNull] protected string OutputToken { get; set; }
			protected int Priority { get; set; }
			[CanBeNull] protected ConversationSentence.OnConditionDelegate Condition { get; set; }
			[CanBeNull] protected ConversationSentence.OnConsequenceDelegate Consequence { get; set; }
			[CanBeNull] protected Expressions Expressions { get; set; }

			protected DialogToken([NotNull] DialogBuilder builder, DialogToken inputToken, [NotNull] string tokenName)
			{
				_builder = builder;
				InputToken = inputToken;
				TokenName = tokenName;
				OutputToken = TokenName;
				Builder.AddToken(this);
			}

			public void Build()
			{
				_builder.Build();
			}

			protected string GetText()
			{
				try
				{
					return Builder.Texts[TokenName];
				}
				catch (KeyNotFoundException)
				{
                    throw new ArgumentException(
                        $"DialogBuilder texts parameter should have a value for \"{TokenName}\" token!");
				}
			}

            public abstract void CompileToken([NotNull] CampaignGameStarter campaign);
		}

		private class InputDialogToken : DialogToken, IInputDialogToken
		{
            public InputDialogToken([NotNull] DialogBuilder builder, [NotNull] string tokenName = "start") : base(
                builder, null, tokenName)
			{
            }

            public IPartnerDialogToken AddDialogLine(string tokenName,
                ConversationSentence.OnConditionDelegate condition = null)
            {
				var result = new PartnerDialogToken(Builder, this, tokenName);
                if (condition != null)
					result.SetCondition(condition);
				return result;
			}

            public IPlayerDialogToken AddPlayerLine(string tokenName,
                ConversationSentence.OnConditionDelegate condition = null)
			{
				var result = new PlayerDialogToken(Builder, this, tokenName);
				if (condition != null)
					result.SetCondition(condition);
				return result;
			}

			public override void CompileToken(CampaignGameStarter campaign)
			{
				// This is a start token, we don't need to actually do anything
			}
		}

		private class PartnerDialogToken : DialogToken, IPartnerDialogToken
		{
            public PartnerDialogToken([NotNull] DialogBuilder builder, DialogToken inputTokenToken,
                [NotNull] string tokenName)
                : base(builder, inputTokenToken, tokenName)
			{
			}

			public IPartnerDialogToken SetCondition(ConversationSentence.OnConditionDelegate condition)
			{
				Condition = condition;
				return this;
			}

			public IPartnerDialogToken SetConsequence(ConversationSentence.OnConsequenceDelegate consequence)
			{
				Consequence = consequence;
				return this;
			}

			public IPlayerDialogToken CloseWindow()
			{
				OutputToken = "close_window";
				return InputToken as IPlayerDialogToken;
			}

			public IDecisionToken Decision()
			{
				var result = new DecisionToken(Builder, this);
				this.OutputToken = result.TokenName;
				return result;
			}

			public IPlayerDialogToken Response(string tokenName)
			{
				return new PlayerDialogToken(Builder, this, tokenName);
			}

			public IPlayerDialogToken SetOutputAndEnd(string outputToken)
			{
				OutputToken = outputToken;
				return End();
			}

			public IPartnerDialogToken SetExpressions(Expressions expressions)
			{
				Expressions = expressions;
				return this;
			}

			public IPartnerDialogToken SetPriority(int priority)
			{
				Priority = priority;
				return this;
			}

			public IPlayerDialogToken End()
			{
				if (InputToken is IBarterResultToken)
					return InputToken.InputToken as IPlayerDialogToken;
				return InputToken as IPlayerDialogToken;
			}

			public override void CompileToken(CampaignGameStarter campaign)
			{
				var inputToken = InputToken?.TokenName ?? "start";
				if (InputToken is IBarterResultToken)
					inputToken += "_result";
				if (InputToken is IInputDialogToken)
					inputToken = InputToken.TokenName;
				campaign.AddDialogLine(TokenName, inputToken, OutputToken, GetText() + Expressions?.Tag, Condition, Consequence, Priority);
			}
		}

		private class PlayerDialogToken : DialogToken, IPlayerDialogToken
		{
			internal PlayerDialogToken([NotNull]DialogBuilder builder, DialogToken inputToken,
				[NotNull]string tokenName)
				[NotNull] string tokenName)
				: base(builder, inputToken, tokenName)
			{
			}

			public IPlayerDialogToken SetConsequence(ConversationSentence.OnConsequenceDelegate consequence)
			{
				Consequence = consequence;
				return this;
			}

			public IPlayerDialogToken SetExpressions(Expressions expressions)
			{
				Expressions = expressions;
				return this;
			}

			public IPlayerDialogToken SetPriority(int priority)
			{
				Priority = priority;
				return this;
			}

			public IPartnerDialogToken Response(string tokenName)
			{
				var result = new PartnerDialogToken(Builder, this, tokenName);
				return result;
			}

			public IPartnerDialogToken SetOutputAndEnd(string outputToken)
			{
				OutputToken = outputToken;
				return End();
			}

			public IBarterResultToken Barter(AcquireBarterablesCallback acquireBarterables)
			{
				var result = new BarterResultToken(Builder, this, acquireBarterables);
				OutputToken += "_barter";
				return result;
			}

			public IPartnerDialogToken End()
			{
				return InputToken as IPartnerDialogToken;
			}

			public IPlayerDialogToken SetCondition(ConversationSentence.OnConditionDelegate condition)
			{
				Condition = condition;
				return this;
			}

			public override void CompileToken(CampaignGameStarter campaign)
			{
				campaign.AddPlayerLine(TokenName, InputToken?.TokenName ?? "start", OutputToken,
					 GetText() + Expressions?.Tag, Condition, Consequence, Priority);
			}
		}

		private class DecisionToken : PlayerDialogToken, IDecisionToken
		{
			//[NotNull] private readonly List<IPlayerDialogToken> _variants;

            public DecisionToken([NotNull] DialogBuilder builder, [NotNull] PartnerDialogToken inputToken)
				: base(builder, inputToken, inputToken.TokenName + "_decision")
			{
				//_variants = new List<IPlayerDialogToken>();
			}

			public IDecisionToken AddVariant(string tokenName, DecisionVariantTokenCallback callback)
			{
				var token = new PlayerDialogToken(Builder, this, tokenName);
				//_variants.Add(token);
				callback(token);
				return this;
			}

            public override void CompileToken(CampaignGameStarter campaign)
            {
		}
        }

		private class BarterResultToken : DialogToken, IBarterResultToken
		{
			// We don't need DialogToken instance reference in callback, so instead we should use class with everything essential to initialize barter.
			private class BarterContext
			{
				private readonly AcquireBarterablesCallback _acquireBarterables;

				public ConversationSentence.OnConsequenceDelegate AdditionalConsequence;
				public BarterManager.BarterContextInitializer ContextInitializer;
				public BarterPersuasionCostReduction PersuasionCostReduction;

				public BarterContext(AcquireBarterablesCallback acquireBarterables)
				{
					_acquireBarterables = acquireBarterables;
				}

				public void Consequence()
				{
					AdditionalConsequence?.Invoke();
                    BarterManager.Instance?.StartBarterOffer(Hero.MainHero, Hero.OneToOneConversationHero,
                        PartyBase.MainParty,
                        MobileParty.ConversationParty?.Party, null, ContextInitializer,
                        PersuasionCostReduction?.Invoke() ?? 0, false,
						_acquireBarterables?.Invoke());
				}

				public bool IsAccepted()
				{
					return BarterManager.Instance?.LastBarterIsAccepted ?? false;
				}

				public bool IsRejected()
				{
					return (!BarterManager.Instance?.LastBarterIsAccepted) ?? false;
				}
			}

			[NotNull] private readonly BarterContext _context;

            public BarterResultToken([NotNull] DialogBuilder builder, [NotNull] PlayerDialogToken inputToken,
                [CanBeNull] AcquireBarterablesCallback acquireBarterables) : base(builder, inputToken,
                inputToken.TokenName + "_barter")
			{
				_context = new BarterContext(acquireBarterables);
			}

			public IBarterResultToken BarterAccept(string tokenName, BarterOfferTokenCallback callback)
			{
				var token = new PartnerDialogToken(Builder, this, tokenName).SetCondition(_context.IsAccepted);
				callback(token);
				return this;
			}

			public IBarterResultToken BarterReject(string tokenName, BarterOfferTokenCallback callback)
			{
				var token = new PartnerDialogToken(Builder, this, tokenName).SetCondition(_context.IsRejected);
				callback(token);
				return this;
			}

			public IBarterResultToken BarterResult(string tokenName, BarterOfferTokenCallback callback)
			{
				var token = new PartnerDialogToken(Builder, this, tokenName);
				callback(token);
				return this;
			}

			public IBarterResultToken ContextInitializer(BarterManager.BarterContextInitializer initializer)
			{
				_context.ContextInitializer = initializer;
				return this;
			}

			public IBarterResultToken PersuasionCostReduction(BarterPersuasionCostReduction callback)
			{
				_context.PersuasionCostReduction = callback;
				return this;
			}

			public IPlayerDialogToken End()
			{
                return InputToken as IPlayerDialogToken ?? throw new InvalidOperationException(
                    $"{nameof(IBarterResultToken)} should be created with inputToken of type {nameof(IPlayerDialogToken)}!");
			}

			public override void CompileToken(CampaignGameStarter campaign)
			{
				_context.AdditionalConsequence = Consequence;
				campaign.AddDialogLine(TokenName, InputToken?.TokenName + "_barter", TokenName+"_result", "" + Expressions?.Tag, Condition, _context.Consequence);
			}
		}

		[NotNull] private readonly CampaignGameStarter _campaignGameStarter;
		[NotNull] private Dictionary<string, string> Texts { get; }
		[NotNull] private readonly List<DialogToken> _tokens;

		/// <summary>
		/// initializes new instance of DialogBuilder.
		/// </summary>
		/// <param name="campaignGameStarter"></param>
		/// <param name="texts">Map translating token ID to dialog text value.</param>
        public DialogBuilder([NotNull] CampaignGameStarter campaignGameStarter,
            [NotNull] Dictionary<string, string> texts)
		{
			_campaignGameStarter = campaignGameStarter;
			Texts = texts;
			_tokens = new List<DialogToken>();
		}

		/// <summary>
		/// Creates input token with id "start".
		/// </summary>
		/// <returns>Newly created <see cref="IInputDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
		public IInputDialogToken GetStartToken()
		{
			return new InputDialogToken(this);
		}

		/// <summary>
		/// Creates input token with id "event_triggered
		/// </summary>
		/// <returns>Newly created <see cref="IInputDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
		public IInputDialogToken GetEventTriggeredToken()
		{
			return new InputDialogToken(this, "event_triggered");
		}

		/// <summary>
		/// Creates input token with id "member_chat"
		/// </summary>
		/// <returns>Newly created <see cref="IInputDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
		public IInputDialogToken GetMemberChatToken()
		{
			return new InputDialogToken(this, "member_chat");
		}

		/// <summary>
		/// Creates input token with id "prisoner_chat"
		/// </summary>
		/// <returns>Newly created <see cref="IInputDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
		public IInputDialogToken GetPrisonerChatToken()
		{
			return new InputDialogToken(this, "prisoner_chat");
		}

		/// <summary>
		/// Creates input token with custom id.
		/// </summary>
		/// <param name="tokenName"></param>
		/// <returns>Newly created <see cref="IInputDialogToken"/></returns>
        [PublicAPI]
        [NotNull]
        public IInputDialogToken GetExistingToken([NotNull] string tokenName)
		{
			return new InputDialogToken(this, tokenName);
		}

        private void AddToken([NotNull] DialogToken token)
		{
			if (token is IInputDialogToken)
				return;
			if (_tokens.Exists(t => token.TokenName == t?.TokenName))
				throw new ApplicationException("Token with same name already defined!");
			_tokens.Add(token);
		}

		private void Build()
		{
			foreach (var dialogToken in _tokens)
			{
				dialogToken.CompileToken(_campaignGameStarter);
			}
			_tokens.Clear();
		}
	}

    /// <summary>
    /// </summary>
    /// <returns></returns>
    [NotNull]
    public delegate IEnumerable<Barterable> AcquireBarterablesCallback();

    /// <summary>
    /// </summary>
    /// <param name="accepted"></param>
    public delegate void BarterOfferTokenCallback([NotNull] IPartnerDialogToken accepted);

    /// <summary>
    /// </summary>
    /// <param name="variant"></param>
    public delegate void DecisionVariantTokenCallback([NotNull] IPlayerDialogToken variant);

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public delegate int BarterPersuasionCostReduction();
}