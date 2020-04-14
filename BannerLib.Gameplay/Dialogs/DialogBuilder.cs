using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Dialogs.DialogBuilder
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
			[PublicAPI] [NotNull] public static readonly Expressions Aggressive = new Expressions(Key.IdleBody, "aggressive");
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
			[PublicAPI] [NotNull] public static readonly Expressions IdleAngry = new Expressions(Key.IdleFace, "idle_angry");
			/// <summary>
			/// [if:idle_happy]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions IdleHappy = new Expressions(Key.IdleFace, "idle_happy");
			/// <summary>
			/// [if:idle_insulted]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions IdleInsulted = new Expressions(Key.IdleFace, "idle_insulted");
			/// <summary>
			/// [if:idle_pleased]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions IdlePleased = new Expressions(Key.IdleFace, "idle_pleased");
			/// <summary>
			/// [if:idle_despise]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions IdleDespise = new Expressions(Key.IdleFace, "idle_despise");
			/// <summary>
			/// [if:idle_cheering1]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions IdleCheering1 = new Expressions(Key.IdleFace, "idle_cheering1");
			/// <summary>
			/// [if:idle_cheering2]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions IdleCheering2 = new Expressions(Key.IdleFace, "idle_cheering2");
			/// <summary>
			/// [if:idle_sick]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions IdleSick = new Expressions(Key.IdleFace, "idle_sick");
			/// <summary>
			/// [if:convo_composed]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoComposed = new Expressions(Key.IdleFace, "convo_composed");
			/// <summary>
			/// [if:convo_nonchalant]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoNonchalant = new Expressions(Key.IdleFace, "convo_nonchalant");
			/// <summary>
			/// [if:convo_delighted]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoDelighted = new Expressions(Key.IdleFace, "convo_delighted");
			/// <summary>
			/// [if:convo_happy]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoHappy = new Expressions(Key.IdleFace, "convo_happy");
			/// <summary>
			/// [if:convo_stonefaced]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoStonefaced = new Expressions(Key.IdleFace, "convo_stonefaced");
			/// <summary>
			/// [if:convo_grave]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoGrave = new Expressions(Key.IdleFace, "convo_grave");
			/// <summary>
			/// [if:convo_irritable]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoIrritable = new Expressions(Key.IdleFace, "convo_irritable");
			/// <summary>
			/// [if:convo_mocking]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoMocking = new Expressions(Key.IdleFace, "convo_mocking");
			/// <summary>
			/// [if:convo_insidious]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoInsidious = new Expressions(Key.IdleFace, "convo_insidious");
			/// <summary>
			/// [if:convo_bent]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoBent = new Expressions(Key.IdleFace, "convo_bent");
			/// <summary>
			/// [if:convo_grim]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoGrim = new Expressions(Key.IdleFace, "convo_grim");
			/// <summary>
			/// [if:convo_charitable]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoCharitable = new Expressions(Key.IdleFace, "convo_charitable");
			/// <summary>
			/// [if:convo_merry]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoMerry = new Expressions(Key.IdleFace, "convo_merry");
			/// <summary>
			/// [if:convo_friendly]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions ConvoFriendly = new Expressions(Key.IdleFace, "convo_friendly");
			/// <summary>
			/// [if:talking_happy]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions TalkingHappy = new Expressions(Key.IdleFace, "talking_happy");
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
			[PublicAPI] [NotNull] public static readonly Expressions VeryNegative = new Expressions(Key.ReactionBody, "very_negative");
			/// <summary>
			/// [rb:negative]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions Negative = new Expressions(Key.ReactionBody, "negative");
			/// <summary>
			/// [rb:positive]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions Positive = new Expressions(Key.ReactionBody, "positive");
			/// <summary>
			/// [rb:very_positive]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions VeryPositive = new Expressions(Key.ReactionBody, "very_positive");
			/// <summary>
			/// [rb:unsure]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions Unsure = new Expressions(Key.ReactionBody, "unsure");
			/// <summary>
			/// [rb:trivial]
			/// </summary>
			[PublicAPI] [NotNull] public static readonly Expressions Trivial = new Expressions(Key.ReactionBody, "trivial");
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
			[PublicAPI] [NotNull] public static readonly Expressions VeryNegative = new Expressions(Key.ReactionFace, "very_negative");
		}
		/// <summary>
		/// Empty string (no expressions)
		/// </summary>
		[PublicAPI] public static readonly Expressions None = new Expressions("");
		/// <summary>
		/// This tags string.
		/// </summary>
		[PublicAPI] public string Tag { get; }
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

			protected DialogToken([NotNull] DialogBuilder builder, DialogToken inputToken, [NotNull]string tokenName)
			{
				_builder = builder;
				InputToken = inputToken;
				TokenName = tokenName;
				OutputToken = "close_window";
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
					throw new ArgumentException($"DialogBuilder texts parameter should have a value for \"{TokenName}\" token!");
				}
			}
			public abstract void CompileToken([NotNull]CampaignGameStarter campaign);
		}
		private class InputDialogToken : DialogToken, IInputDialogToken
		{
			public InputDialogToken([NotNull]DialogBuilder builder, [NotNull]string tokenName = "start") : base(builder, null, tokenName) { }
			public IPartnerDialogToken AddDialogLine(string tokenName, ConversationSentence.OnConditionDelegate condition = null)
			{
				var result = new PartnerDialogToken(Builder, this, tokenName);
				if (condition != null)
					result.SetCondition(condition);
				return result;
			}
			public IPlayerDialogToken AddPlayerLine(string tokenName, ConversationSentence.OnConditionDelegate condition = null)
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
			public PartnerDialogToken([NotNull]DialogBuilder builder, DialogToken inputTokenToken, [NotNull]string tokenName)
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
				campaign.AddDialogLine(TokenName, InputToken?.TokenName ?? "start", OutputToken, GetText() + Expressions?.Tag, Condition, Consequence, Priority);
			}
		}

		private class PlayerDialogToken : DialogToken, IPlayerDialogToken
		{
			internal PlayerDialogToken([NotNull]DialogBuilder builder, DialogToken inputToken, [NotNull]string tokenName)
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
				OutputToken = result.TokenName;
				return result;
			}
			public IBarterResultToken Barter(AcquireBarterablesCallback acquireBarterables)
			{
				var result = new BarterResultToken(Builder, this, acquireBarterables);
				OutputToken = result.TokenName;
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
				campaign.AddPlayerLine(TokenName, InputToken?.TokenName ?? "start", OutputToken, GetText() + Expressions?.Tag, Condition, Consequence, Priority);
			}
		}
		private class DecisionToken : PlayerDialogToken, IDecisionToken
		{
			//[NotNull] private readonly List<IPlayerDialogToken> _variants;

			public DecisionToken([NotNull]DialogBuilder builder, [NotNull]PartnerDialogToken inputToken)
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
			public override void CompileToken(CampaignGameStarter campaign) { }
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
					BarterManager.Instance?.StartBarterOffer(Hero.MainHero, Hero.OneToOneConversationHero, PartyBase.MainParty,
						MobileParty.ConversationParty?.Party, null, ContextInitializer, PersuasionCostReduction?.Invoke() ?? 0, false,
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
			public BarterResultToken([NotNull]DialogBuilder builder, [NotNull]PlayerDialogToken inputToken, [CanBeNull]AcquireBarterablesCallback acquireBarterables) : base(builder, inputToken, inputToken.TokenName + "_barter")
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
				return InputToken as IPlayerDialogToken ?? throw new InvalidOperationException($"{nameof(IBarterResultToken)} should be created with inputToken of type {nameof(IPlayerDialogToken)}!");
			}
			public override void CompileToken(CampaignGameStarter campaign)
			{
				_context.AdditionalConsequence = Consequence;
				campaign.AddDialogLine(TokenName, InputToken?.TokenName ?? "start", TokenName, "" + Expressions?.Tag, Condition, _context.Consequence);
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
		public DialogBuilder([NotNull]CampaignGameStarter campaignGameStarter, [NotNull]Dictionary<string, string> texts)
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
		public IInputDialogToken GetExistingToken([NotNull]string tokenName)
		{
			return new InputDialogToken(this, tokenName);
		}
		private void AddToken([NotNull]DialogToken token)
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
		}
	}
	/// <summary>
	/// </summary>
	/// <returns></returns>
	[NotNull] public delegate IEnumerable<Barterable> AcquireBarterablesCallback();
	/// <summary>
	/// </summary>
	/// <param name="accepted"></param>
	public delegate void BarterOfferTokenCallback([NotNull]IPartnerDialogToken accepted);
	/// <summary>
	/// </summary>
	/// <param name="variant"></param>
	public delegate void DecisionVariantTokenCallback([NotNull]IPlayerDialogToken variant);
	/// <summary>
	/// </summary>
	/// <returns></returns>
	public delegate int BarterPersuasionCostReduction();
	/// <summary>
	/// Base type for any dialog token.
	/// </summary>
	[PublicAPI]
	public interface IDialogToken
	{
		/// <summary>
		/// Complete this dialog tree and add it's lines to <see cref="ConversationManager"/>
		/// </summary>
		[PublicAPI] void Build();
	}
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
		[PublicAPI] [NotNull] IPartnerDialogToken AddDialogLine([NotNull]string tokenName, [CanBeNull]ConversationSentence.OnConditionDelegate condition = null);
		/// <summary>
		/// Creates new dialog token for player.
		/// </summary>
		/// <param name="tokenName">Unique token ID </param>
		/// <param name="condition">Condition to check whether this dialog line could appear</param>
		/// <returns>Newly created dialog token</returns>
		[PublicAPI] [NotNull] IPlayerDialogToken AddPlayerLine([NotNull]string tokenName, [CanBeNull]ConversationSentence.OnConditionDelegate condition = null);
	}
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
		[PublicAPI] [NotNull] IPlayerDialogToken SetCondition([NotNull]ConversationSentence.OnConditionDelegate condition);
		/// <summary>
		/// Sets new consequence callback delegate for this token
		/// </summary>
		/// <param name="consequence"></param>
		/// <returns>This <see cref="IPlayerDialogToken"/></returns>
		[PublicAPI] [NotNull] IPlayerDialogToken SetConsequence([NotNull]ConversationSentence.OnConsequenceDelegate consequence);
		/// <summary>
		/// Sets facial expressions for player's character (usually useless, unless you've set camera to players' character)
		/// </summary>
		/// <param name="expressions"></param>
		/// <returns>This <see cref="IPlayerDialogToken"/></returns>
		[PublicAPI] [NotNull] IPlayerDialogToken SetExpressions([NotNull]Expressions expressions);
		/// <summary>
		/// Sets new priority value for this dialog token.
		/// </summary>
		/// <param name="priority"></param>
		/// <returns>This <see cref="IPlayerDialogToken"/></returns>
		[PublicAPI] [NotNull] IPlayerDialogToken SetPriority(int priority);
		/// <summary>
		/// Opens a barter window between player and conversation partner.
		/// </summary>
		/// <param name="acquireBarterables"></param>
		/// <returns>Newly created <see cref="IBarterResultToken"/></returns>
		[PublicAPI] [NotNull] IBarterResultToken Barter([NotNull]AcquireBarterablesCallback acquireBarterables);
		/// <summary>
		/// Creates a partner's response to this player token.
		/// </summary>
		/// <param name="tokenName"></param>
		/// <returns>Newly created <see cref="IPartnerDialogToken"/></returns>
		[PublicAPI] [NotNull] IPartnerDialogToken Response([NotNull]string tokenName);
		/// <summary>
		/// Finishes this token and returns it's input <see cref="IPartnerDialogToken"/> or null.
		/// </summary>
		/// <returns><see cref="IPartnerDialogToken"/> instance by which this <see cref="IPlayerDialogToken"/> was created or null if input token has other type.</returns>
		[PublicAPI] [CanBeNull] IPartnerDialogToken End();
	}
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
		[PublicAPI] [NotNull] IBarterResultToken BarterAccept([NotNull]string tokenName, [NotNull] BarterOfferTokenCallback callback);
		/// <summary>
		/// Creates a partner's response with predefined condition if barter was rejected.
		/// </summary>
		/// <remarks>Never do call <see cref="IPartnerDialogToken.SetCondition"/> for returned instance of <see cref="IPartnerDialogToken"/>!</remarks>
		/// <param name="tokenName"></param>
		/// <param name="callback">this callback is called with newly created <see cref="IPartnerDialogToken"/></param>
		/// <returns>Newly created <see cref="IBarterResultToken"/></returns>
		[PublicAPI] [NotNull] IBarterResultToken BarterReject([NotNull]string tokenName, [NotNull] BarterOfferTokenCallback callback);
		/// <summary>
		/// Creates a partner's response after barter window is closed (whether barter was accepted or rejected).
		/// </summary>
		/// <param name="tokenName"></param>
		/// <param name="callback">this callback is called with newly created <see cref="IPartnerDialogToken"/></param>
		/// <returns>Newly created <see cref="IPartnerDialogToken"/></returns>
		[PublicAPI] [NotNull] IBarterResultToken BarterResult([NotNull]string tokenName, [NotNull] BarterOfferTokenCallback callback);
		/// <summary>
		/// Sets barter context initializer
		/// </summary>
		/// <param name="initializer"></param>
		/// <returns>This <see cref="IBarterResultToken"/></returns>
		[PublicAPI] [NotNull] IBarterResultToken ContextInitializer([NotNull]BarterManager.BarterContextInitializer initializer);
		/// <summary>
		/// Sets persuasion cost reduction value for BarterManager.
		/// </summary>
		/// <param name="callback"></param>
		/// <returns>This <see cref="IBarterResultToken"/></returns>
		[PublicAPI] [NotNull] IBarterResultToken PersuasionCostReduction([NotNull]BarterPersuasionCostReduction callback);
		/// <summary>
		/// Finishes this token and returns it's input <see cref="IPlayerDialogToken"/> or null.
		/// </summary>
		/// <returns></returns>
		[PublicAPI] [CanBeNull] IPlayerDialogToken End();
	}
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
		[PublicAPI] [NotNull] IPartnerDialogToken SetCondition([NotNull]ConversationSentence.OnConditionDelegate condition);
		/// <summary>
		/// Sets new consequence callback delegate for this token
		/// </summary>
		/// <param name="consequence"></param>
		/// <returns>This <see cref="IPartnerDialogToken"/></returns>
		[PublicAPI] [NotNull] IPartnerDialogToken SetConsequence([NotNull]ConversationSentence.OnConsequenceDelegate consequence);
		/// <summary>
		/// Sets facial expressions for partner's character.
		/// </summary>
		/// <param name="expressions"></param>
		/// <returns>This <see cref="IPartnerDialogToken"/></returns>
		[PublicAPI] [NotNull] IPartnerDialogToken SetExpressions([NotNull]Expressions expressions);
		/// <summary>
		/// Sets priority value for this dialog token.
		/// </summary>
		/// <param name="priority"></param>
		/// <returns>This <see cref="IPartnerDialogToken"/></returns>
		[PublicAPI] [NotNull] IPartnerDialogToken SetPriority(int priority);
		/// <summary>
		/// Sets output token value to "close_window" and returns this <see cref="IPartnerDialogToken"/>'s input <see cref="IPlayerDialogToken"/>.
		/// </summary>
		/// <returns><see cref="IPlayerDialogToken"/> instance by which this <see cref="IPartnerDialogToken"/> was created or null if input token has other type.</returns>
		[PublicAPI] [CanBeNull] IPlayerDialogToken CloseWindow();
		/// <summary>
		/// Creates a new decision token, which allows for multiple player's response dialog lines.
		/// </summary>
		/// <returns>Newly created <see cref="IDecisionToken"/></returns>
		[PublicAPI] [NotNull] IDecisionToken Decision();
		/// <summary>
		/// Creates a new player response line.
		/// </summary>
		/// <param name="tokenName"></param>
		/// <returns>Newly created <see cref="IPlayerDialogToken"/></returns>
		[PublicAPI] [NotNull] IPlayerDialogToken Response([NotNull]string tokenName);
		/// <summary>
		/// Finishes this token and returns it's input <see cref="IPlayerDialogToken"/> or null.
		/// </summary>
		/// <returns><see cref="IPlayerDialogToken"/> instance by which this <see cref="IPartnerDialogToken"/> was created or null if input token has other type.</returns>
		[PublicAPI] [CanBeNull] IPlayerDialogToken End();
	}
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
		[PublicAPI] [NotNull] IDecisionToken AddVariant([NotNull]string tokenName, [NotNull]DecisionVariantTokenCallback callback);
	}
}
