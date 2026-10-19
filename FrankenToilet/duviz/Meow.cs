using FrankenToilet.Config;
using FrankenToilet.Core;
using FrankenToilet.duviz.commands;
using GameConsole;
using HarmonyLib;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FrankenToilet.duviz;

public class Meow : MonoBehaviour
{
    public static Meow meow;
    LevelEditsPanel LevelEdits => ConfigManager.Duviz.LevelEdits;

    float damageTimer = 0;
    float damageCooldown = 0.05f;

    public void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        meow = this;
    }

    public void Start()
    {
        Console.instance.RegisterCommand(new NotFoundReplace());

        AudioConfiguration config = AudioSettings.GetConfiguration();
        config.numRealVoices = 128 * 4;
        config.numVirtualVoices = 128 * 4;
        AudioSettings.Reset(config);
    }

    public void OnSceneLoad(Scene s, LoadSceneMode _)
    {
        if (ConfigManager.Duviz.EnableLevelEdits.value)
            StartCoroutine(WaitForLoad(SceneHelper.CurrentScene));
    }

    public IEnumerator WaitForLoad(string s)
    {
        while (SceneHelper.PendingScene != null)
            yield return null;

        yield return null;

        switch (s)
        {
            case "Level 5-4" when LevelEdits.EnableWrathDrainage.value:
                Destroy(GameObject.Find("Underwater").transform.Find("UnderwaterWater").gameObject);

                foreach (var obj in GameObject.FindObjectsOfType<GameObject>(true))
                {
                    if (obj.name == "Surface")
                    {
                        GameObject NonStuff = obj.transform.Find("Nonstuff").gameObject;
                        GameObject Stuff = obj.transform.Find("Stuff").gameObject;
                        GameObject StuffC = obj.transform.Find("Stuff(Clone)").gameObject;

                        ReplaceMaterials(NonStuff.transform.Find("SeaSurface"));
                        ReplaceMaterials(Stuff.transform.Find("Watersurface"));
                        ReplaceMaterials(Stuff.transform.Find("Watersurface (Sunken)"));
                        ReplaceMaterials(StuffC.transform.Find("Watersurface"));
                        ReplaceMaterials(StuffC.transform.Find("Watersurface (Sunken)"));

                        Destroy(Stuff.transform.Find("Boss/Leviathan/SplashBig"));
                        Destroy(StuffC.transform.Find("Boss/Leviathan/SplashBig"));
                        Stuff.transform.Find("Boss/Leviathan").GetComponent<LeviathanController>().bigSplash = null;
                        StuffC.transform.Find("Boss/Leviathan").GetComponent<LeviathanController>().bigSplash = null;
                    }
                }
            break;

            case "Level 5-3":
                if (LevelEdits.Enable5_3Spinnnning.value)
                    NewMovement.instance.gameObject.AddComponent<Lois>();

                if (LevelEdits.EnableWrathDrainage.value)
                    foreach (var obj in GameObject.FindObjectsOfType<GameObject>(true))
                    {
                        if (obj.name == "Sea" && obj.transform.parent == null)
                            ReplaceMaterials(obj.transform);
                    }
            break;

            case "Level 5-2" when LevelEdits.EnableWrathDrainage.value:
                foreach (var obj in GameObject.FindObjectsOfType<GameObject>(true))
                {
                    if (obj.name == "Sea" && obj.transform.parent == null)
                        ReplaceMaterials(obj.transform, "Environment/Layer 5/CaveRock1");

                    if (obj.name == "DeathZone (Enemies)" || obj.name == "HurtZone (Player)")
                        Destroy(obj);

                    if (obj.name == "Sea Itself")
                    Destroy(obj.GetComponent<SeaBodies>());

                    if (obj.name == "WaterTrigger")
                    {
                        Destroy(obj.GetComponent<Water>());
                        obj.GetComponent<Collider>().isTrigger = false;
                        obj.layer = LayerMask.NameToLayer("Outdoors");
                    }
                }
            break;

            case "Level 5-1" when LevelEdits.EnableWrathDrainage.value:
                foreach (var obj in GameObject.FindObjectsOfType<GameObject>(true))
                {
                    if (obj.name == "WatersDisabler" && obj.transform.parent == null)
                    {
                        obj.transform.Find("1").gameObject.SetActive(true);
                        obj.transform.Find("1").Find("2").gameObject.SetActive(true);
                        obj.transform.Find("1").Find("2").Find("3").gameObject.SetActive(true);
                        obj.transform.Find("1").Find("2").Find("3").Find("GameObject").gameObject.SetActive(true);
                    }
                }
            break;

            case "Level 4-4" when LevelEdits.Enable4_4MissingTex.value:
                StockMapInfo.Instance.levelName = "404: NOT FOUND";
                LevelNamePopup.Instance.Invoke("Start", 0);
                ReplaceEverything();
            break;

            case "Level 1-4" when LevelEdits.Enable1_4WideV2.value:
                foreach (var obj in SceneManager.GetActiveScene().GetRootGameObjects())
                {
                    if (obj.name == "V2 - Arena")
                    {
                        GameObject Stuff = obj.transform.Find("V2 Stuff").gameObject;
                        GameObject StuffC = obj.transform.Find("V2 Stuff(Clone)").gameObject;
                        Stuff.transform.Find("V2").Find("v2_combined").localScale += new Vector3(30, 0, 0);
                        StuffC.transform.Find("V2").Find("v2_combined").localScale += new Vector3(10, 0, 0);
                    }
                    if (obj.name == "Music - Versus")
                    {
                        obj.GetComponent<AudioSource>().clip = Bundle.bundle.LoadAsset<AudioClip>("wide");
                    }
                }
            break;

            case "Level 2-1" when LevelEdits.Enable2_1Transgener.value:
                RenderSettings.skybox.mainTexture = Bundle.bundle.LoadAsset<Texture>("TransLustSky");
            break;

            case "Level 1-S" when LevelEdits.Enable1_SMissingTex.value:
                var objs = GameObject.FindObjectsOfType<GameObject>(true);
                var puz = GameObject.FindObjectsOfType<PuzzleController>(true);
                foreach (var obj in objs)
                {
                    if (obj.name == "GlobalLights")
                        foreach (Transform tr in obj.transform)
                            tr.gameObject.SetActive(false);
                    if (obj.name == "Point Light (5)")
                        obj.GetComponent<Light>().intensity /= 5;
                }
                foreach (var c in puz)
                    foreach (Transform cc in c.transform)
                        if (!cc.gameObject.activeSelf)
                            cc.gameObject.SetActive(UnityEngine.Random.Range(0, 2) == 0);
                ReplaceEverything();
            break;
        }
    }

    public static void ReplaceEverything(bool includeActive = true)
    {
        var root = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var obj in root)
        {
            if (!obj.activeSelf && !includeActive) continue;
            if (obj.name == "Player" || obj.name == "Canvas") continue;
            ReplaceMaterials(obj.transform, Bundle.bundle.LoadAsset<Material>("404"));
        }
    }

    static void ReplaceMaterials(Transform tr, string path = "Environment/Layer 4/SandLarge")
    {
        foreach (Transform c in tr)
        {
            if (c.childCount > 0)
                ReplaceMaterials(c, path);
            if (c.name == "Lightning (1)" || c.GetComponent<ParticleSystem>() != null) continue;
            c.GetComponent<Renderer>()?.material = new Material(Plugin.Ass<Material>($"Assets/Materials/{path}.mat"));
            if (c.GetComponent<ScrollingTexture>() != null)
                Destroy(c.GetComponent<ScrollingTexture>());
        }
    }

    static void ReplaceMaterials(Transform tr, Material mat)
    {
        foreach (Transform c in tr)
        {
            if (c.childCount > 0)
                ReplaceMaterials(c, mat);
            if (c.name == "Lightning (1)" || c.GetComponent<ParticleSystem>() != null) continue;
            c.GetComponent<Renderer>()?.material = new Material(mat);
            if (c.GetComponent<ScrollingTexture>() != null)
                Destroy(c.GetComponent<ScrollingTexture>());
        }
    }

    public void Update()
    {
        if (!ConfigManager.Duviz.WaterDamagesU.value || NewMovement.instance == null)
            return;

        if (NewMovement.instance.touchingWaters.Count > 0)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageCooldown)
            {
                damageTimer -= damageCooldown;
                NewMovement.instance.GetHurt(1, false);
            }
        }
    }
}

[PatchOnEntry]
[HarmonyPatch(typeof(LeviathanController))]
public static class LeviathanPatch
{
    [HarmonyPrefix]
    [HarmonyPatch("Awake")]
    public static void Prefix(LeviathanController __instance)
    {
        if (!ConfigManager.Duviz.BuffLeviathan.value)
            return;

        __instance.gameObject.GetComponent<EnemyIdentifier>().sandified = true;
        if (SteamHelper.IsSlopTuber)
            __instance.gameObject.GetComponent<EnemyIdentifier>().radianceTier = float.PositiveInfinity;
    }
}

[PatchOnEntry]
[HarmonyPatch(typeof(HookPoint))]
public static class HookPointPatch
{
    [HarmonyPrefix]
    [HarmonyPatch("Start")]
    public static void Prefix(HookPoint __instance)
    {
        if (ConfigManager.Duviz.NoMoreHookpoints.value
            && __instance.type != hookPointType.Switch
            && __instance.onHook.toDisActivateObjects.Length == 0
            && __instance.onHook.toActivateObjects.Length == 0
            && __instance.onReach.toActivateObjects.Length == 0
            && __instance.onReach.toDisActivateObjects.Length == 0
            && __instance.onUnhook.toActivateObjects.Length == 0
            && __instance.onUnhook.toDisActivateObjects.Length == 0
          )
            GameObject.Destroy(__instance.gameObject);
    }
}

[PatchOnEntry]
[HarmonyPatch(typeof(SisyphusPrime))]
public static class SisyphusPrimePatch
{
    [HarmonyPrefix]
    [HarmonyPatch("Awake")]
    public static void Prefix(SisyphusPrime __instance)
    {
        if (ConfigManager.Duviz.SisyphusStealsUrGuns.value)
            GunControl.instance.NoWeapon();
    }

    [HarmonyPrefix]
    [HarmonyPatch("Update")]
    public static void PrefixUpdate(SisyphusPrime __instance)
    {
        if (ConfigManager.Duviz.SisyphusStealsUrGuns.value)
            GunControl.instance.NoWeapon();
    }
}

[PatchOnEntry]
[HarmonyPatch(typeof(SisyphusPrimeIntro))]
public static class SisyphusPrimeIntroPatch
{
    [HarmonyPrefix]
    [HarmonyPatch("Start")]
    public static void Prefix(SisyphusPrimeIntro __instance)
    {
        if (ConfigManager.Duviz.SisyphusStealsUrGuns.value)
        {
            GunControl.instance.NoWeapon();
            HudMessageReceiver.instance.SendHudMessage("Fuck you no weapons >:3");
        }
    }
}

[PatchOnEntry]
[HarmonyPatch(typeof(LevelSelectPanel))]
public static class LevelSelectPanelPatch
{
    [HarmonyPostfix]
    [HarmonyPatch("Setup")]
    public static void Prefix(LevelSelectPanel __instance)
    {
        if (__instance.name == "4-4 Panel" && ConfigManager.Duviz.LevelEdits.Enable4_4MissingTex.value)
        {
            __instance.transform.Find("Image").GetComponent<Image>().sprite = Bundle.bundle.LoadAsset<Sprite>("404 thumbnail"); ;
        }
    }
}

[PatchOnEntry]
[HarmonyPatch(typeof(TextMeshProUGUI))]
public static class TMP_TextPatch
{
    [HarmonyPrefix]
    [HarmonyPatch("Awake")]
    public static void Prefix(TextMeshProUGUI __instance)
    {
        if (__instance.text != null && ConfigManager.Duviz.LevelEdits.Enable4_4MissingTex.value)
            if (__instance.text.ToUpper() == "4-4: CLAIR DE SOLEIL")
                __instance.text = "404: NOT FOUND";
    }
}

[PatchOnEntry]
[HarmonyPatch(typeof(Revolver))]
[HarmonyPatch("Shoot")]
public class LookThisPatchIsNeeded
{
    public static void Postfix(int shotType = 1)
    {
        if (ConfigManager.Duviz.RevolverZoomGoBrrrrr.value)
        {
            CameraController.Instance.GetComponent<Camera>().fieldOfView = 10;
            Meow.meow.StartCoroutine(CameraFov());
        }
    }

    public static IEnumerator CameraFov()
    {
        yield return null;
        CameraController.Instance.GetComponent<Camera>().fieldOfView = 10;
    }
}
