using FrankenToilet.Core;
using FrankenToilet.flazhik.Components;
using HarmonyLib;
using UnityEngine;
using static UnityEngine.Object;

namespace FrankenToilet.flazhik.Patches;

[PatchOnEntry]
[HarmonyPatch(typeof(FinalPit))]
public class FinalPitPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(FinalPit), "OnTriggerEnter")]
    public static void FinalPit_OnTriggerEnter_Postfix()
    {
        if (!ConfigManager.Flazhik.EnableSanAndreas.value)
            return;
        
        var hud = FindFirstObjectByType<SanAndreasHud>(FindObjectsInactive.Include);
        if (hud == null)
            return;

        hud.gameObject.SetActive(false);
    }
}