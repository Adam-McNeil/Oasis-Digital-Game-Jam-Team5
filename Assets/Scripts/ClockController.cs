using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour
{

    static public int totalTime = 10;
    static public int timeLeft;
    private TextMeshProUGUI clockText;

    void Start()
    {
        clockText = GetComponentInChildren<TextMeshProUGUI>();
        timeLeft = totalTime;
        clockText.text = FormatTime(timeLeft);
        StartCoroutine(Clock());
    }

    IEnumerator Clock()
    {
        yield return new WaitForSeconds(1f);
        timeLeft--;
        clockText.text = FormatTime(timeLeft);
        StartCoroutine(Clock());
    }

    string FormatTime(int time)
    {
        int minutes = time / 60;
        int seconds = time % 60;
        if (seconds < 10)
        {
            return minutes + ":0" + seconds;
        }
        else
        {
            return minutes + ":" + seconds;

        }
    }
}
