namespace FrankenToilet.Plonk;

using FrankenToilet.Config;
using FrankenToilet.Core;
using HarmonyLib;
using UnityEngine;

[PatchOnEntry]
public static class Patches
{
    [HarmonyPrefix, HarmonyPatch(typeof(NewMovement), nameof(NewMovement.Jump))]
    public static void FuckingFuckGravity()
    {
        Vector3 gravDir = new(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        if (ConfigManager.Plonk.EnableGravitySwapOnJump.value)
            MainCode.SwitchGravity(gravDir.normalized * 40f);

        MainCode.gravitySwap = Random.Range(ConfigManager.Plonk.RandomGravitySwapMinTime.value, ConfigManager.Plonk.RandomGravitySwapMaxTime.value);
    }

    public static bool EnableEnemyGravity =>
        ConfigManager.Plonk.GravitySwapType.value.HasFlag(GravitySwapTypes.EnemyOnly);

    [HarmonyPrefix, HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.OnEnable))]
    public static void AddCustomGravity(EnemyIdentifier __instance)
    {
        Rigidbody body = __instance.GetComponent<Rigidbody>();

        CustomGravity gravityComp = __instance.GetOrAddComponent<CustomGravity>();
        gravityComp.gravity = MainCode.CurrentCustomEnemyGravity;
        gravityComp.enabled = EnableEnemyGravity;

        MainCode.TrackedEnemies.Add(body);
    }

    [HarmonyPrefix, HarmonyPatch(typeof(EnemyIdentifier), nameof(EnemyIdentifier.OnDisable))]
    public static void RemoveCustomGravity(EnemyIdentifier __instance)
    {
        Object.Destroy(__instance.GetComponent<CustomGravity>());

        MainCode.TrackedEnemies.Remove(__instance.GetComponent<Rigidbody>());
    }
}