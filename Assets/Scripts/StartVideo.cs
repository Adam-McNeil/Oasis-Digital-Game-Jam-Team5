using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
 
public class StartVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "gameJamIntroVideo.mp4");
        videoPlayer.Play();
    }
}