
using FrankenToilet.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using static FrankenToilet.Core.LogHelper;

namespace FrankenToilet.BlaixenU;

// Organization? I barely know nation!

public static class AssetMan
{

    private static AssetBundle _assets;

    public static bool AssetsLoaded = false;

    public static GameObject Popup1 => _assets.LoadAsset<GameObject>("popup1");
    public static GameObject Popup3 => _assets.LoadAsset<GameObject>("popup2"); // 2 and 3 prefab variants
    public static GameObject Popup2 => _assets.LoadAsset<GameObject>("popup3");


    public static void Load()
    {
        LogInfo("Loading assets");
        byte[] data;
        try
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = $"FrankenToilet.BlaixenU.assetblaixundle";
            var s = assembly.GetManifestResourceStream(resourceName);
            s = s ?? throw new FileNotFoundException($"Could not find embedded resource '{resourceName}'.");
            using var ms = new MemoryStream();
            s.CopyTo(ms);
            data = ms.ToArray();
        }
        catch (Exception ex)
        {
            LogError($"Error loading assets: " + ex.Message);
            return;
        }

        SceneManager.sceneLoaded += (scene, lcm) =>
        {
            if (_assets != null) return;

            _assets = AssetBundle.LoadFromMemory(data);
            AssetsLoaded = true;
            LogInfo("Loaded assets");
        };
    }
}

[EntryPoint]
public static class Main
{
    [EntryPoint]
    public static void Start()
    {
        AssetMan.Load();
    }
}