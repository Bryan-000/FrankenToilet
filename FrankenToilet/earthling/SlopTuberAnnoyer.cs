using System;
using UnityEngine.SceneManagement;
using FrankenToilet.Core;
using UnityEngine;

namespace FrankenToilet.earthling;

[EntryPoint]
public static class SlopTuberAnnoyer
{
    [EntryPoint]
    public static void AnnoySlopTuber()
    {
        SceneManager.sceneLoaded += (scene, lcm) => {
            if (HudMessageReceiver.Instance != null && SceneHelper.CurrentScene != "Main Menu")
            {
                try
                {
                    if (SteamHelper.IsSlopTuber)
                    {
                        Debug.LogError("THE SUN IS LEAKING");
                        HudMessageReceiver.Instance.SendHudMessage("THE SUN IS LEAKING");
                    }
                }
                catch { }
            }
        };
    }
}
