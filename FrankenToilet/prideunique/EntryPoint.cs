using BepInEx;
using FrankenToilet.Core;
using UnityEngine.SceneManagement;
using static FrankenToilet.Core.LogHelper;

namespace FrankenToilet.prideunique;

[EntryPoint]
public static class EntryPoint
{
    [EntryPoint]
    public static void Start()
    {
        LogInfo("Loading");

        AssetsController.Init();

        SceneManager.sceneLoaded += (scene, lcm) =>
        {
            if (SceneHelper.CurrentScene == "Intro")
            {
                AudioClipsAddressableLoader.LoadSoundAndMusicAddressables();
            }

            if (SceneHelper.CurrentScene != "Bootstrap"
                && SceneHelper.CurrentScene != "Intro")
            {
                CoroutineRunner.RunDelayed(0.1f, () =>
                {
                    if (SceneHelper.CurrentScene != "Main Menu")
                        Popups.Init();
                    SoundRandomizer.SwitchSounds();
                });
            }
        };

        LogInfo("Loaded");
    }
}