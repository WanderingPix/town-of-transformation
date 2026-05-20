using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfTransformation.Roles.Impostor;
using TownOfTransformation.Roles.Neutral;
using TownOfUs.Modules.Localization;

namespace TownOfTransformation.Options.Roles.Neutral;

public sealed class RichGuyOptions : AbstractOptionGroup<RichGuyRole>
{
    public override string GroupName => TouLocale.Get("RichGuy", "Rich Guy");

    [ModdedNumberOption("Money per task", 1f, 20f, 0.5f, MiraNumberSuffixes.None)]
    public float MoneyPerTask { get; set; } = 5f;


}