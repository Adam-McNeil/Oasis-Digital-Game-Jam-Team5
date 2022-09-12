using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVideo : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer videoPlayer; 

    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "gameJamIntoVideo.mp4");
    }
}
