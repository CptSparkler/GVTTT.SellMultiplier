using System.Collections.Generic;
using System.Runtime.InteropServices;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace SellMultiplier
{
    [BepInPlugin("com.cptsparkler.sellmultiplier", "Sell Multiplier", "1.0.0")]
    [BepInProcess("GoblinVyke.exe")]
    public class SellMultiplierPlugin : BaseUnityPlugin
    {
        public const string ModGuid = "com.cptsparkler.sellmultiplier";
        public const string ModName = "Sell Multiplier";
        public const string ModVersion = "1.0.0";

        public static ConfigEntry<float> SellMultiplier;

        void Awake()
        {
            SellMultiplier = Config.Bind(
                "Sell Price Multiplier",
                "SellMultiplier",
                1f,
                new ConfigDescription(
                    "Multiplier applied to trader prices. 1 = normal, 2 = double, 0.5 = half price.",
                    new AcceptableValueRange<float>(0.1f, 10f)
                )
            );

            SellMultiplier.SettingChanged += (sender, args) =>
            {
                Logger.LogInfo($"Sell Multiplier changed to {SellMultiplier.Value}");
            };

            new Harmony("com.cptsparkler.sellmultiplier").PatchAll();
            Logger.LogInfo($"{ModName} v{ModVersion} loaded!");

        }
    }
}