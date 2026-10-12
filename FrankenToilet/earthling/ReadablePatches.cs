using UnityEngine;
using FrankenToilet.Core;
using HarmonyLib;

namespace FrankenToilet.earthling;

[PatchOnEntry]
[HarmonyPatch(typeof(Readable))]
public static class ReadablePatches
{
    [HarmonyPostfix]
    [HarmonyPatch("Awake")]
    public static void ChenifiesYourText(Readable __instance)
    {
        if (!ConfigManager.Earthling.BookChenifier.value)
            return;

        __instance.content = """
            <size=20>
            ░░░░░░░░░░░░░░░░░▄▄▄▄▄▄
            ░░░░░░░░░░░░░▄▄▀▀░░░░░░▀▄
            ░░░░░░░░░░░▄▀░░░░░░░░░░▄▄▌░▄██▀▄
            ░░░░░░░▀▄▄▀░░░░░░░░░░░░▄▄███▀▀▌▐
            ░░░░░░▐▄▀███▄░░▄█▄▄░░▄▀▒▒▒▒▀▀▄▐░▌
            ░░░░░▄▌▀▄▐▀▒▀▄▀▀▒▒▒▀▀▄▀▄▒▒▒▒▒▒▀▄▌▀
            ░░░░▐░▌▐▄▌▒▒▒▄▀▀▄▒▒▒▐▄▒▒▒▒▒▒▒▒▒▒▐▀
            ░░░░▐▄▐▐▒▒▒▒▒▒▒▐░▌▒▒▒▌▀▄▀▀▄▒▒▒▒▒▒▌
            ░░░░▐▄▄▌▒▒▒▌▒▄▀▀▄▀▄▒▒▌▌░░░▐▄▒▒▒▒▒▐
            ░░░░▐▌▒▒▒▒▐▒▄▀░░░█░▀▄▐░▌░░▐█▐▒▒▀▄▐
            ░░░░░▌▒▒▒▒▐▀▄░░░▄█░░░▀▐▄▄███░▌▒▐▐▐
            ░░░░▐▒▒▒▒▒▌░█▄▄███▌░░░▐████▀▌▐▒▒▌▀
            ░░░░▐▒▒▒▒▒▌░████▌█▌░░░░█▀█▀░▌▐▒▒▐
            ░░░░▐█▒▒▒▒▌░▐░▀▀░▐░░░▀░░▀░░░░░▀▌▐
            ░░░░▐█▌▒▒▒▐░░░░░░▐▄▄▀▄▀░░░░░░░▄▀▌
            ▄▀▄░░██▄▒▒▒▌░░░░░░▐▄▀░░░░░░░▄▀▒█
            ▀▄▐▌░▐█▀▄▒▒▀▄░▄▄▄▄░░░▄▄▀▀▀██▒▒█
            ░▐██░░██░▀▄▐░▀▌░░░▀█▀▌░░░▐▀▐▄▀
            ░░██▌▐█▌░▐░▀▀▌▌░░▄░▌░▌▄░░▌▐    
            """;

        AudioSource audioSource = __instance.gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = FishProvider.GetFish("Chen").worldObject.GetComponentInChildren<AudioSource>().clip;
    }

    [HarmonyPostfix]
    [HarmonyPatch("StartScan")]
    public static void HonkifiesYourBook(Readable __instance)
    {
        if (ConfigManager.Earthling.BookChenifier.value)
            __instance.gameObject.GetComponent<AudioSource>().Play();
    }
}