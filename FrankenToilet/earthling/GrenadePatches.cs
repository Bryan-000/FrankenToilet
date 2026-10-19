using UnityEngine;
using FrankenToilet.Core;
using HarmonyLib;

namespace FrankenToilet.earthling;

[PatchOnEntry]
[HarmonyPatch(typeof(Grenade))]
public static class GrenadePatches
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Grenade.PlayerRideStart))]
    public static void NoRocketRidesForYouBuddy(Grenade __instance)
    {
        if (!ConfigManager.Earthling.NoRocketsForYou.value)
            return;

        __instance.superExplosion = GameObject.Instantiate(__instance.superExplosion);

        var boom = __instance.superExplosion.transform.GetChild(0).GetComponent<Explosion>();
        boom.canHit = AffectedSubjects.PlayerOnly;
        boom.damage = 50;
        boom.maxSize = 100;

        __instance.Explode(true, false, true, 3f, false, null);
    }
}
