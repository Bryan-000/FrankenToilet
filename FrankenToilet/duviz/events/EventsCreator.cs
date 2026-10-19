using FrankenToilet.Config;
using System.Collections;
using UnityEngine;

namespace FrankenToilet.duviz.events;

public class EventsCreator : MonoBehaviour
{
    public void Start()
    {
        EventsPanel events = ConfigManager.Duviz.Events;

        EventsManager.AddEvent("Explode").AddListener(() =>
        {
            if (events.Explode.value)
            {
                GameObject obj = Plugin.Ass<GameObject>("Assets/Prefabs/Attacks and Projectiles/Explosions/Explosion.prefab");
                StartCoroutine(SpawnWithWarning(obj));
            }
        });

        EventsManager.AddEvent("Not Found").AddListener(() =>
        {
            if (events.NotFound.value)
                Meow.ReplaceEverything(false);
        });

        EventsManager.AddEvent("Minos").AddListener(() =>
        {
            if (events.Minos.value)
            {
                GameObject obj = Plugin.Ass<GameObject>("Assets/Prefabs/Enemies/MinosPrime.prefab");
                GameObject inst = Instantiate(obj, NewMovement.Instance.transform.position, Quaternion.identity);
                inst.AddComponent<DestroyOnCheckpointRestart>();
            }
        });

        EventsManager.AddEvent("Bouncy Ball").AddListener(() =>
        {
            if (events.Balls.value)
                for (int i = 0; i < Random.Range(5, 11); i++)
                {
                    GameObject obj = Instantiate(Bundle.bundle.LoadAsset<GameObject>("BouncyBall"));
                    obj.transform.position = NewMovement.instance.transform.position;
                    obj.transform.localScale *= 3;
                    obj.GetComponent<Renderer>().material = new Material(obj.GetComponent<Renderer>().material);
                    obj.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
                    obj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0, 100f), Random.Range(0, 100f), Random.Range(0, 100f));
                }
        });

        EventsManager.AddEvent("BSOD").AddListener(() =>
        {
            if (events.BlueScreen.value)
            {
                GameObject obj = Instantiate(Bundle.bundle.LoadAsset<GameObject>("BSODCanvas"));
                obj.AddComponent<DestroyInTime>();
            }
        });

        EventsManager.AddEvent("No weapons").AddListener(() =>
        {
            if (events.NoWeapons.value)
                GunControl.instance.NoWeapon();
        });

        EventsManager.AddEvent("Reset percentage").AddListener(() =>
        {
            if (events.ResetHP.value)
                HealthRemover.percentage = 0;
        });

        EventsManager.AddEvent("Add percentage").AddListener(() =>
        {
            if (events.AddHP.value)
                HealthRemover.percentage += 100;
        });

        EventsManager.AddEvent("Spin").AddListener(() =>
        {
            if (events.Spin.value)
                SpinEvent.Play();
        });

        EventsManager.AddEvent("Go away").AddListener(() =>
        {
            if (events.GoAway.value)
                NewMovement.instance.rb.velocity *= -10;
        });

        EventsManager.AddEvent("Pause").AddListener(() =>
        {
            if (events.Pause.value)
                OptionsManager.instance.Pause();
        });

        EventsManager.AddEvent("nO STAMINA").AddListener(() =>
        {
            if (events.nOSTAMINA.value)
                NewMovement.instance.EmptyStamina();
        });

        EventsManager.AddEvent("Imagine").AddListener(() =>
        {
            if (events.Imagine.value)
                NewMovement.instance.rb.velocity = new Vector3(0, 1000, 0);
        });

        EventsManager.AddEvent("God is angry at you").AddListener(() =>
        {
            if (events.GodIsAngi.value)
                StartCoroutine(God());
        });
    }

    IEnumerator SpawnWithWarning(GameObject obj)
    {
        HudMessageReceiver.instance.SendHudMessage("");
        yield return null;
        HudMessageReceiver.instance.ClearMessage();
        yield return new WaitForSeconds(0.5f);
        GameObject inst = Instantiate(obj, NewMovement.Instance.transform.position, Quaternion.identity);
    }

    IEnumerator God()
    {
        GameObject beam = Plugin.Ass<GameObject>("Assets/Prefabs/Enemies/Virtue.prefab");
        for (int i = 0; i < 10; i++)
        {
            GameObject o = Instantiate(beam);
            o.transform.position = NewMovement.instance.transform.position;
            o.AddComponent<DestroyOnCheckpointRestart>();
            yield return new WaitForSeconds(0.05f);
        }
    }
}