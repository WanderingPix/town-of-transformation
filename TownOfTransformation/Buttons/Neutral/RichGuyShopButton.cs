using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Networking;
using MiraAPI.Utilities.Assets;
using Reactor.Utilities;
using TMPro;
using TownOfTransformation.Assets;
using TownOfTransformation.Options.Roles.Neutral;
using TownOfTransformation.Roles.Neutral;
using TownOfUs.Assets;
using TownOfUs.Buttons;
using TownOfUs.Options.Modifiers.Alliance;
using TownOfUs.Patches;
using TownOfUs.Utilities;
using UnityEngine;

namespace TownOfTransformation.Buttons.Neutral;

public sealed class RichGuyShopButton : TownOfUsRoleButton<RichGuyRole>
{
    public override string Name => "Shop";
    public override BaseKeybind Keybind => Keybinds.PrimaryAction;
    public override Color TextOutlineColor => TouExampleColors.Fortegreen;
    public override float Cooldown => 0.1f;
    public override LoadableAsset<Sprite> Sprite => NeutAssets.SentinelKillSprite;
    public bool ShopOpen { get; set; } = false;
    public override void CreateButton(Transform parent)
    {
        base.CreateButton(parent);
        Coroutines.Start(MiscUtils.CoMoveButtonIndex(this, false));
    }


    


    public override bool CanUse()
    {
        return base.CanUse() && Timer <= 0f;
    }

    protected override void OnClick()
    {
        if (!Role.shopui.active)
        {
            Role.shopui.SetActive(true);
            var shop = Role.shopui.transform.FindChild("Shop");
            // Money
            var money = shop.transform.FindChild("Money");
            var moneytext = money.transform.FindChild("Text (TMP)");
            var moneytextcomponent = moneytext.GetComponent<TextMeshProUGUI>();
            moneytextcomponent.text = Role.Money.ToString();
            // Extra Life Cost
            var extralife = shop.transform.FindChild("ExtraLife");
            var extralifeprice = extralife.transform.FindChild("Price");
            var extralifetext = extralifeprice.transform.FindChild("Text (TMP)");
            var extralifetextcomponent = extralifetext.GetComponent<TextMeshProUGUI>();
            extralifetextcomponent.text = Role.ExtraLifePrice.ToString();
           // Goldify Cost 
            var goldify = shop.transform.FindChild("Goldify");
            var goldifyprice = goldify.transform.FindChild("Price");
            var goldifytext = goldifyprice.transform.FindChild("Text (TMP)");
            var goldifytextcomponent = goldifytext.GetComponent<TextMeshProUGUI>();
            goldifytextcomponent.text = Role.GoldifyPrice.ToString();
            // Revealer Cost
            var revealer = shop.transform.FindChild("Revealer");
            var revealerprice = revealer.transform.FindChild("Price");
            var revealertext = revealerprice.transform.FindChild("Text (TMP)");
            var revealertextcomponent = revealertext.GetComponent<TextMeshProUGUI>();
            revealertextcomponent.text = Role.RevealerPrice.ToString();
            // Zoom Out Cost
            var zoomout = shop.transform.FindChild("ZoomOut");
            var zoomoutprice = zoomout.transform.FindChild("Price");
            var zoomouttext = zoomoutprice.transform.FindChild("Text (TMP)");
            var zoomouttextcomponent = zoomouttext.GetComponent<TextMeshProUGUI>();
            zoomouttextcomponent.text = Role.ZoomoutPrice.ToString();

        } else
        {
            Role.shopui.SetActive(false);
        }
    }
}