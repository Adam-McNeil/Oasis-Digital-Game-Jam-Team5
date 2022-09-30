using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private PlayerController playerController;
    private ClockController clockController;
    private TextMeshProUGUI startTimerText;
    

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        clockController = GameObject.Find("Clock").GetComponent<ClockController>();
        startTimerText = GameObject.Find("Start Timer").GetComponent<TextMeshProUGUI>();
    }

    #region Start Timer
    
    IEnumerator StartTimer()
    {
        startTimerText.gameObject.SetActive(true);
        startTimerText.text = "3";
        yield return new WaitForSeconds(1);
        startTimerText.text = "2";
        yield return new WaitForSeconds(1);
        startTimerText.text = "1";
        yield return new WaitForSeconds(1);
        startTimerText.text = "Go";
        this.StartGame();
        yield return new WaitForSeconds(1);
        startTimerText.gameObject.SetActive(false);
    }

    #endregion

    #region Game Events
    public void RestartGame()
    {
        ResetGame();
        StartCoroutine(StartTimer());
    }

    private void StartGame()
    {
        playerController.OnStartGame();
        TicketController.OnStartGame();
        WallController.OnStartGame();
        clockController.OnStartGame();
    }

    public void EndGame()
    {
        playerController.OnEndGame();
        TicketController.OnEndGame();
        WallController.OnEndGame();
        clockController.OnEndGame();
    }

    public void ResetGame()
    {
        EndGame();
        playerController.OnResetGame();
        TicketController.OnResetGame();
        WallController.OnResetGame();
        clockController.OnResetGame();
    }

    #endregion

}
