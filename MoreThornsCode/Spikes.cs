using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.Models.Powers;

namespace MoreThorns.MoreThornsCode;

[Pool(typeof(ColorlessCardPool))]
public class Spikes()
    : CustomCardModel(0, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
    	new PowerVar<ThornsPower>(2),
		new CardsVar(1),
    ];

    protected override IEnumerable<IHoverTip> ExtraHoverTips => [
    	HoverTipFactory.FromPower<ThornsPower>(),
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
		await PowerCmd.Apply<ThornsPower>(Owner.Creature, DynamicVars["ThornsPower"].IntValue, Owner.Creature, this);
		await CardPileCmd.Draw(choiceContext, DynamicVars.Cards.IntValue, Owner);
    }

    protected override void OnUpgrade()
    {
		DynamicVars["ThornsPower"].UpgradeValueBy(1);
    }

    public override string? CustomPortraitPath => "res://MoreThorns/images/spikes.png";
}
