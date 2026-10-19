#pragma warning disable CS8618
using UnityEngine;
using System.IO;
using System.Reflection;

namespace FrankenToilet.duviz;

internal class Bundle : MonoBehaviour
{
    public static AssetBundle bundle;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);

        var assembly = Assembly.GetExecutingAssembly();

        string resourceName = "FrankenToilet.duviz.meow.bundle";

        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
            {
                return;
            }

            bundle = AssetBundle.LoadFromStream(stream);
        }
    }

    public void OnDestroy()
    {
        bundle?.Unload(false);
    }
}