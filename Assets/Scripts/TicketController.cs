using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketController : MonoBehaviour
{
    static private GameObject player;
    private Vector3 offset = new Vector3(0, 1.5f, 0);
    private bool isPickedUp;

    public bool isDone = true;

    [SerializeField] private Material notDoneMaterial;
    [SerializeField] private Material doneMaterial;


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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Right") || other.CompareTag("Middle"))
        {
            StartCoroutine(StartTicket());
            isDone = false;
            this.GetComponentInChildren<Renderer>().material = notDoneMaterial;
        }
    }

    IEnumerator StartTicket()
    {
        yield return new WaitForSeconds(5);
        isDone = true;
        this.GetComponentInChildren<Renderer>().material = doneMaterial;
    }
}
