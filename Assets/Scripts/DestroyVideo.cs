using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DestroyVideo : MonoBehaviour
{
   
    private float videoLength = 96;

    private bool wasSkipVideoKeyCodePressed;
    private bool skipVideoKeyWasPressedWithinTimeRange = false;
    private KeyCode skipVidoeKeyCode = KeyCode.Escape;  // The key to skip the into video
    private float skipTimeDuration = 5f;    // How long the user has to confirm skipping after pressing the button once
    [SerializeField] private string sceneToLoadName = "Main";   // Name of the scene to load
    [SerializeField] private TextMeshProUGUI confirmSkipText;   // Refence to the text that tells the user that they can skip with the skipVideoKeyCode

    private void Start()
    {
        StartCoroutine(SceneSwitch());
        confirmSkipText.text = "Press " + skipVidoeKeyCode.ToString() + " to skip";
    }

    private void Update()
    {
        ProcessSkipVideoKeyPress();
    }

    private void ProcessSkipVideoKeyPress()
    {
        wasSkipVideoKeyCodePressed = Input.GetKeyDown(skipVidoeKeyCode);
        if (wasSkipVideoKeyCodePressed)
        {
            if (!skipVideoKeyWasPressedWithinTimeRange)
            {
                StartCoroutine(SkipTextCounter());
            }
            else
            {
                SceneManager.LoadScene(sceneToLoadName);
            }
        }
    }

    // Function to start timer to turn the skip text off after the skipTimeDuration
    IEnumerator SkipTextCounter()
    {
        confirmSkipText.gameObject.SetActive(true);
        skipVideoKeyWasPressedWithinTimeRange = true;
        yield return new WaitForSeconds(skipTimeDuration);
        skipVideoKeyWasPressedWithinTimeRange = false;
        confirmSkipText.gameObject.SetActive(false);
    }

    // Function to change scene after the video is ended
    IEnumerator SceneSwitch()
    {
        yield return new WaitForSeconds(videoLength);
        SceneManager.LoadScene(sceneToLoadName);
    }
}
