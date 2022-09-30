using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour
{

    static public int totalTime = 180;  // The total time of the game
    static public int timeLeft;
    static public GameController gameController;
    private TextMeshProUGUI clockText;  // Refence to the text gameobject that displays the time

    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        clockText = GetComponentInChildren<TextMeshProUGUI>();
    }

    IEnumerator Clock()
    {
        yield return new WaitForSeconds(1f);
        timeLeft--;
        clockText.text = FormatTime(timeLeft);
        if (timeLeft > 0)
        {
            StartCoroutine(Clock());
        }
        else
        {
            gameController.EndGame();
        }
    }

    // Resets the clock and starts the clock incrementing
    void StartClock()
    {
        ResetClock();
        StartCoroutine(Clock());
    }

    void ResetClock()
    {
        timeLeft = totalTime;
        clockText.text = FormatTime(timeLeft);
    }

    #region Game Events
    public void OnStartGame()
    {
        StartCoroutine(Clock());
    }

    public void OnResetGame()
    {
        ResetClock();
        StopAllCoroutines();
    }

    public void OnEndGame()
    {

    }
    #endregion

    // return a string given a int with the correct number of zero and colon so that the time is correctly displayed
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
