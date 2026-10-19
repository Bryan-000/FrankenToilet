using FrankenToilet.Core;
using HarmonyLib;
using UnityEngine;
using Object = UnityEngine.Object;

namespace FrankenToilet.doomahreal.patches;

[PatchOnEntry]
[HarmonyPatch]
public static class Startlevelpatch
{
    private static int _evilStartCounter = 0;

    [HarmonyPatch(typeof(PlayerTracker), "LevelStart")]
    [HarmonyPostfix]
    public static void Postfix()
    {
        if (!ConfigManager.Doomah.EnableEvilScary.value)
            return;
        
        _evilStartCounter++;
        LogHelper.LogInfo($"Evil Scary Round Start Counter: {_evilStartCounter}");
        if (_evilStartCounter < ConfigManager.Doomah.EvilScaryStartCounter.value)
            return;

        var bundle = IMLOADINGITSOHARDDDD.thegrundle;
        GameObject? prefab = bundle.LoadAsset<GameObject>("Assets/Custom/imfrakeninmykill/evilscary/round start canvas/EvilScary 1.prefab");

        // evil scary could spawn camp you so delete chaser

        if (Chaser.Instance != null)
            Object.Destroy(Chaser.Instance.gameObject);

        Object.Instantiate(prefab);
        _evilStartCounter = 0;
    }
}
