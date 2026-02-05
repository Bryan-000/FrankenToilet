using FrankenToilet.Core;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.Video;
using static UnityEngine.GraphicsBuffer;

namespace FrankenToilet.prideunique;
public static class Popups
{
    private static GameObject MainPrefab;
    private static List<VideoClip> VideoClips = new List<VideoClip>();
    public static AudioClip VideoCloseSound;

    public static void Init()
    {
        if (!AssetsController.AssetsLoaded)
            return;

        if (CameraController.Instance == null)
            return;

        PopupCloser.Instance.Awake();

        MainPrefab = AssetsController.LoadAsset<GameObject>("assets/aizoaizo/popup.prefab");
        MainPrefab.SetActive(false);

        VideoCloseSound = AssetsController.LoadAsset<AudioClip>("assets/aizoaizo/pum.ogg");
        for (int i = 1; i <= 19; i++)
        {
            if (i == 14) // had problems with this one
                continue;

            VideoClips.Add(AssetsController.LoadAsset<VideoClip>("assets/aizoaizo/" + i.ToString() + ".mp4"));
        }

        CoroutineRunner.Run(PopupHandler());
    }

    private static IEnumerator PopupHandler()
    {
        while (true)
        {
            VideoClips.Shuffle();

            GameObject go = SpawnPopup(VideoClips[0]);
            
            yield return new WaitForSeconds(((float)VideoClips[0].length) * 7);
        }

        yield return null;
    }

    private static GameObject SpawnPopup(VideoClip videoClip)
    {
        GameObject go = UnityEngine.Object.Instantiate(MainPrefab);
        go.SetActive(true);

        VideoPlayer videoPlayer = go.GetComponentInChildren<VideoPlayer>();
        RawImage rawImage = go.GetComponentInChildren<RawImage>();

        rawImage.rectTransform.sizeDelta = new Vector2(videoClip.width, videoClip.height);
        Popup pu = rawImage.gameObject.AddComponent<Popup>();
        pu.Parent = go;
        pu.CloseSound = VideoCloseSound;

        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = videoClip;
        videoPlayer.SetDirectAudioVolume(0, PrefsManager.Instance.GetFloat("allVolume", 0f) / 2f);

        videoPlayer.Prepare();

        videoPlayer.prepareCompleted += (vp) => 
        {
            Vector3 dir = Random.onUnitSphere;
            Vector3 pos = dir.normalized * 512.0f;

            Follow f = go.gameObject.AddComponent<Follow>();
            f.target = CameraController.Instance.transform;
            f.mimicPosition = true;
             
            go.transform.GetChild(0).position = pos;
            go.transform.GetChild(0).LookAt(CameraController.Instance.transform.position);

            vp.Play();
        };

        return go;
    }
}
