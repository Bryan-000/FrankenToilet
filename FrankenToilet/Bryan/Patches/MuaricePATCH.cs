namespace FrankenToilet.Bryan.Patches;

using FrankenToilet.Core;
using HarmonyLib;
using UnityEngine;

/// <summary> die </summary>
[PatchOnEntry] [HarmonyPatch(typeof(MaliciousFace))]
public static class MuaricePATCH
{
    /// <summary> low quality </summary>
    [HarmonyPrefix] [HarmonyPatch("Awake")]
    public static void lowquality(MaliciousFace __instance)
    {
        if (!ConfigManager.Bryan.ReplaceMauriceModel.value)
            return;
        
        SkinnedMeshRenderer mr = __instance.transform.Find("MaliciousFace/MaliciousFace").GetComponent<SkinnedMeshRenderer>();
        mr.enabled = false;

        GameObject mauriceBad = Object.Instantiate(Assets.MauriceBad, mr.transform);
        foreach (Material mat in mauriceBad.GetComponent<MeshRenderer>().materials)
            mat.shader = DefaultReferenceManager.Instance.masterShader;
    }
}