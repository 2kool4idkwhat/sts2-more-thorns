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
public class AbrasiveArmor()
    : CustomCardModel(2, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [
        new PowerVar<PlatingPower>(6),
    	new PowerVar<ThornsPower>(6),
    ];

    protected override IEnumerable<IHoverTip> ExtraHoverTips => [
		HoverTipFactory.FromPower<PlatingPower>(),
    	HoverTipFactory.FromPower<ThornsPower>(),
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
		await PowerCmd.Apply<PlatingPower>(Owner.Creature, DynamicVars["PlatingPower"].IntValue, Owner.Creature, this);
		await PowerCmd.Apply<ThornsPower>(Owner.Creature, DynamicVars["ThornsPower"].IntValue, Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
		DynamicVars["PlatingPower"].UpgradeValueBy(2);
		DynamicVars["ThornsPower"].UpgradeValueBy(2);
    }

    public override string? CustomPortraitPath => "res://MoreThorns/images/abrasive-armor.png";
}

