using MiraAPI.Utilities.Assets;
using Reactor.Utilities;
using TMPro;
using UnityEngine;
namespace TownOfTransformation.Assets;

public static class ExampleAssets
{
    public static readonly AssetBundle Bundle = AssetBundleManager.Load("tot-bundle");
    private const string ShortPath = "TownOfTransformation.Resources";
    public static LoadableAsset<Sprite> Banner { get; } = new LoadableResourceAsset($"{ShortPath}.ExampleBanner.png");
        public static LoadableBundleAsset<AnimationClip> LilGuyAnimation { get; } = new("lil guy.anim", Bundle);
    
}
