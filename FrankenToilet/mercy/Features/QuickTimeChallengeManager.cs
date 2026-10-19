using System.Diagnostics;
using UnityEngine;

namespace FrankenToilet.mercy.Features;

public sealed class QuickTimeChallengeManager : MonoBehaviour
{
    // wouldn't be a feature without one of these
    public Stopwatch stopwatch = new();
    [MercyFeature]
    public static void Activate()
    {
        _ = Plugin.manager.AddComponent<QuickTimeChallengeManager>();
    }

    private void Awake()
    {
        stopwatch.Start();
    }

    private void Update()
    {
        if (stopwatch.Elapsed.TotalSeconds >= 1 && ConfigManager.Mercy.QuickTimeChallenges.value)
        {
            if (Plugin.rand.Next(1, 120) == 1 && !Plugin.canvas.GetComponent<QuickTimeChallenge>())
            {
                QuickTimeChallenge.Activate();
            }

            stopwatch.Restart();
        }
    }
}