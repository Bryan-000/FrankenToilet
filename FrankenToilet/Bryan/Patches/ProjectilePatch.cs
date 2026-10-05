namespace FrankenToilet.Bryan.Patches;

using FrankenToilet.Core;
using HarmonyLib;

[PatchOnEntry] [HarmonyPatch(typeof(Projectile))]
public static class ProjectilePatch
{
    /// <summary> Add a projectile fucker to the projectile and that will handle all the fancy shit </summary>
    [HarmonyPrefix] [HarmonyPatch("Start")]
    public static void meow(Projectile __instance)
    {
        if (!__instance.GetComponent<ProjectileFucker>() && ConfigManager.Bryan.DuplicateProjectiles.value)
            __instance.gameObject.AddComponent<ProjectileFucker>();
    }
}