using HarmonyLib;
using SellMultiplier;

namespace SellMultiplier.Patches
{
    [HarmonyPatch(typeof(UI_Base_21Point), nameof(UI_Base_21Point.SetPriceMulti))]
    public class SetPriceMultiPatch
    {
        static void Prefix(ref float newMulti)
        {
            newMulti *= SellMultiplierPlugin.SellMultiplier.Value;
        }
    }
}