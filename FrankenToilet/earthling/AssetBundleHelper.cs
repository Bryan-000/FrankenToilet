using System;
using System.IO;
using System.Reflection;
using FrankenToilet.Core;
using UnityEngine;
using System.Collections.Generic;
using Object = System.Object;

namespace FrankenToilet.earthling;

[EntryPoint]
public static class AssetBundleHelper
{
    private static AssetBundle? bundle;
    private static Dictionary<string, Object> assetCache = new Dictionary<string, Object>();

    [EntryPoint]
    public static void Init()
    {
        LogHelper.LogInfo("Loading assets");

        try
        {
            const string resourceName = "FrankenToilet.earthling.toiletonfire.bundle";

            Assembly assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new FileNotFoundException($"Could not find embedded resource '{resourceName}'.");

            bundle = AssetBundle.LoadFromStream(stream);

            if (bundle != null)
            {
                LogHelper.LogInfo("Loaded assets");
                FishProvider.LoadFishes();
            }
            else
            {
                LogHelper.LogError("Error loading bundle");
            }

        }
        catch (Exception ex)
        {
            LogHelper.LogError("Error loading assets: " + ex.Message);
        }
    }

    public static T? LoadAsset<T>(string asset)
    {
        if (bundle == null) return default(T);

        if (assetCache.ContainsKey(asset))
        {
            if (!(assetCache[asset] == null) && !assetCache[asset].Equals(null))
            {
                return (T)assetCache[asset];
            }
            assetCache.Remove(asset);
        }
        Object loadedAsset = bundle.LoadAsset(asset);
        assetCache.Add(asset, loadedAsset);
        return (T)loadedAsset;
    }
}
