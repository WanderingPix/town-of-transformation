using System.Collections;
using MiraAPI.GameOptions;
using MiraAPI.Modifiers;
using MiraAPI.Networking;
using MiraAPI.Utilities;
using Reactor.Utilities;
using Reactor.Utilities.Extensions;
using TownOfUs.Modifiers;
using TownOfUs.Networking;
using TownOfUs.Options.Roles.Impostor;
using UnityEngine;

using AmongUs.GameOptions;
using Il2CppInterop.Runtime.Attributes;
using MiraAPI.Events;

using MiraAPI.Hud;
using MiraAPI.LocalSettings;

using MiraAPI.Patches.Stubs;
using MiraAPI.Roles;

using Reactor.Networking.Attributes;

using TouExtras.Assets;
using TouExtras.Buttons.Impostor;
using TouExtras.Options.Roles.Impostor;
using TownOfUs;
using TownOfUs.Assets;
using TownOfUs.Buttons.Crewmate;
using TownOfUs.Buttons.Impostor;
using TownOfUs.Events.Crewmate;
using TownOfUs.Events.TouEvents;
using TownOfUs.Extensions;
using TownOfUs.Interfaces;

using TownOfUs.Modifiers.Crewmate;
using TownOfUs.Modifiers.Game.Universal;
using TownOfUs.Modifiers.Impostor;
using TownOfUs.Modifiers.Neutral;
using TownOfUs.Modules;
using TownOfUs.Modules.Localization;
using TownOfUs.Modules.Wiki;
using TownOfUs.Options.Roles.Crewmate;
using TownOfUs.Roles;
using TownOfUs.Roles.Crewmate;
using TownOfUs.Roles.Impostor;
using TownOfUs.Roles.Neutral;
using TownOfUs.Utilities;



namespace TouExtras.Modules;

// Code Review: Should be using a MonoBehaviour
public sealed class Muffin : IDisposable
{
    private PlayerControl? _baker;
    private GameObject? _obj;
    

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Detonate()
    {
        Coroutines.Start(CoDetonate());
    }

    private IEnumerator CoDetonate()
    {
        yield return new WaitForSeconds(0.1f);

        

        var target = GameData.Instance.GetPlayerById(targetId);

        if (MeetingHud.Instance || ExileController.Instance)
        {
            _obj.Destroy();
            yield break;
        }
        PlayerControl.LocalPlayer.RpcSpecialMurder(
                    target,
                    teleportMurderer: false,
                    showKillAnim: false,
                    causeOfDeath: "Parasite");

        _obj.Destroy();
    }

    public static Muffin CreateMuffin(PlayerControl player, Vector3 location)
    {
        return new Muffin
        {
            _obj = MiscUtils.CreateSpherePrimitive(location,
                OptionGroupSingleton<BomberOptions>.Instance.DetonateRadius),
            _baker = player
        };
    }

    public static IEnumerator MuffinShowTeammate(PlayerControl player, Vector3 location)
    {
        var muffin = CreateMuffin(player, location);

        yield return new WaitForSeconds(OptionGroupSingleton<BomberOptions>.Instance.DetonateDelay);

        try
        {
            muffin.Destroy();
        }
        catch
        {
            /* ignored */
        }
    }

    public void Destroy()
    {
        Dispose();
    }

    private void Dispose(bool disposing)
    {
        if (disposing && _obj != null)
        {
            _obj.Destroy();
        }
    }
}