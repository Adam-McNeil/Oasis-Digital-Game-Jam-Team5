using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private PlayerController playerController;
    private ClockController clockController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        clockController = GameObject.Find("Clock").GetComponent<ClockController>();
    }

    #region Game Events
    public void OnStartGame()
    {
        playerController.OnStartGame();
        TicketController.OnStartGame();
        clockController.OnStartGame();
    }

    public void OnEndGame()
    {
        playerController.OnEndGame();
        TicketController.OnEndGame();
        clockController.OnEndGame();
    }

    public void OnResetGame()
    {
        this.OnEndGame();
        playerController.OnResetGame();
        TicketController.OnResetGame();
        clockController.OnResetGame();
    }

    #endregion

}
