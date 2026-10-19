using HarmonyLib;
using FrankenToilet.Core;


namespace FrankenToilet.greycsont;


[PatchOnEntry]
[HarmonyPatch(typeof(NewMovement))]
public class NewMovementPatcher
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(NewMovement.Start))]
    public static void ChangeSSJMaxFrame(NewMovement __instance)
    {
        if (ConfigManager.Greycsont.ChangeSsjMaxFrames.value)
            __instance.ssjMaxFrames = 10f;
    }
}