using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketController : MonoBehaviour
{
    static private GameObject player;
    private Vector3 offset = new Vector3(0, 1.5f, 0);
    private bool isPickedUp;

    private void Start()
    {
        if (player == null)
            player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (isPickedUp)
        {
            this.transform.position = player.transform.position + offset;
        }
    }

    public void OnPickUp()
    {
        isPickedUp = true;
    }

    public void OnPutDown()
    {
        isPickedUp = false;
    }
}
