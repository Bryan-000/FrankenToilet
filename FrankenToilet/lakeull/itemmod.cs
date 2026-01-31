using System;
using Unity;
using UnityEngine;
using BepInEx;
using FrankenToilet.Core;
using FrankenToilet;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using BepInEx.Logging;
using System.IO;
using System.Reflection;

/*
 *   --- Public Apology ---
 * Dear all future coders of this project.
 * I deeply regret to inform you that the code in this project is fucking dogshit
 * Please find it in your heart to forgive me.
*/

namespace itemMod
{
    

    [EntryPoint]
    public class ItemModMain
    {
        private static GameObject[] packedObjects = [];
        private static AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "bundled")); // change name of "bundled" to the file name of the bundle
        private static string bundlePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "bundled");
        private static GameObject itemCanvas;
        private static GameObject itemBox;
        private static GameObject placeholderOne;
        private static GameObject placeholderTwo;
        public static bool canUseItem = false;
        
        /*
         * Todo:
         * - update
         * - add scene filtering to bundle loading
         * - go to bed
         */


        [EntryPoint]
        public static void Awake()
        {
            // scene
            SceneManager.sceneLoaded += new UnityAction<Scene, LoadSceneMode>(OnSceneLoaded);
            // Plugin startup logic
            LogHelper.LogInfo($"Lakeull's Plugin is loaded!");
            LogHelper.LogInfo(bundlePath);
        }

        public static void OnSceneLoaded(Scene scene, LoadSceneMode lsm)
        {
            LogHelper.LogInfo("loading bundle (itemMod) " + bundlePath);
            LoadBundle();
        }

        public static void LoadBundle()
        {
            canUseItem = false;
            // load bundle, find the item canvas
            packedObjects = bundle.LoadAllAssets<GameObject>();
            foreach (GameObject gameObject in packedObjects)
            {
                // grabs the name of the specific item I WANT IT!!!!!!!!!!!
                //LogHelper.LogInfo($"{gameObject.name}");
                if ($"{gameObject.name}" == "Item Canvas")
                {
                    itemCanvas = GameObject.Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);
                }
                else
                {
                    LogHelper.LogError("bundle error: item canvas name was not identified.");
                }
            }
            // gets the item box sprite
            itemBox = GameObject.Find(itemCanvas.name + "/Item Box");

            // determine whether to reposition the item box 
            if (PrefsManager.Instance.GetInt("weaponHoldPosition") == 2)
            {
                LogHelper.LogInfo("2");
                itemBox.transform.localPosition = new Vector3(-800, -380);
            }
            else
            {
                itemBox.transform.localPosition = new Vector3(800, -380);
            }
            itemBox.AddComponent<ItemModUpdates>();


            //InitialAssignPower();
            //RandomizePower(); gonna be used later
        }
    }

    public class ItemModUpdates : MonoBehaviour
    {
        public static void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z) && ItemModMain.canUseItem == true)
            {
                LogHelper.LogInfo("using power.");
                //usePower();
                //disableAllIcons();
                //StartCoroutine(Cooldown()); // counts for 30 seconds
            }
        }
    }
}