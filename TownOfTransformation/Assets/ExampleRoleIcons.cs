using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace TownOfTransformation.Assets;

public static class ExampleRoleIcons
{
    // THIS FILE SHOULD ONLY HOLD ROLE ICONS

    private const string ShortPath = "TownOfTransformation.Resources";

    // Neutrals
    public static LoadableAsset<Sprite> Sentinel { get; } = new LoadableResourceAsset($"{ShortPath}.RoleIcons.Sentinel.png", 200);
}