namespace FrankenToilet.Plonk;

using FrankenToilet.Config;
using FrankenToilet.Core;
using System.Collections.Generic;
using UnityEngine;

[EntryPoint]
public static class MainCode
{
    [EntryPoint]
    public static void Start()
    {
        GameObject obj = new("dont fucking touch this please it controls the player gravity");
        obj.AddComponent<Penis>();

        obj.hideFlags = HideFlags.HideAndDontSave;
        Object.DontDestroyOnLoad(obj);
    }

    public static float gravitySwap = float.MaxValue;
    public class Penis : MonoBehaviour
    {
        public void Update()
        {
            gravitySwap -= Time.deltaTime;
            if (gravitySwap <= 0 && ConfigManager.Plonk.EnableRandomGravitySwapOnTime.value)
                SwitchGravity(new(0, -40, 0));
        }
    }

    public static List<Rigidbody> TrackedEnemies = [];
    public static Vector3 CurrentCustomEnemyGravity;

    public static void SwitchGravity(Vector3 direction)
    {
        CurrentCustomEnemyGravity = direction;
        GravitySwapTypes swapType = ConfigManager.Plonk.GravitySwapType.value;

        if (swapType.HasFlag(GravitySwapTypes.PlayerOnly))
            NewMovement.Instance?.SwitchGravity(direction);

        bool enemyCustomGravity = swapType.HasFlag(GravitySwapTypes.EnemyOnly);
        for (int i = 0; i < TrackedEnemies.Count; i++)
        {
            Rigidbody body = TrackedEnemies[i];

            if (body)
            {
                body.useGravity = !enemyCustomGravity;
                body.SetCustomGravityMode(enemyCustomGravity);
                body.SetCustomGravity(direction);
            }
            else
            {
                TrackedEnemies.RemoveAt(i--);
            }
        }
    }
}