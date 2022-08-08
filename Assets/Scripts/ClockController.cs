using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour
{

    private int totalTiime = 180;
    private int timeLeft;
    private TextMeshProUGUI clockText;

    void Start()
    {
        clockText = GetComponentInChildren<TextMeshProUGUI>();
        timeLeft = totalTiime;
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
            return minutes + ":" + seconds;
        }
    }
}
