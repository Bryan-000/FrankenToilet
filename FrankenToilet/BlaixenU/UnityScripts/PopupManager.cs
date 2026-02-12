using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FrankenToilet.BlaixenU.UnityScripts;

public class PopupMan : MonoSingleton<PopupMan>
{
    private float timeOfLastPopup;

    public float TimeSincePopup => timeOfLastPopup - Time.realtimeSinceStartup;

    private void Update()
    {
        if (TimeSincePopup > 5)
        {
            Popup();
            timeOfLastPopup = Time.realtimeSinceStartup;
        }
    }

    private void Popup()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
            Instantiate(AssetMan.Popup1);
            break;
            case 2:
            Instantiate(AssetMan.Popup2);
            break;
            case 3:
            Instantiate(AssetMan.Popup3);
            break;
        }
    }
}