using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketController : MonoBehaviour
{
    static private GameObject player;
    static private PointController pointController;
    static private BeltControler beltController;
    private Vector3 startPosition;
    private Vector3 offset = new Vector3(1.5f, 2f, 0);
    private bool isPickedUp;
    private int pointsOfLastAreaEntered;

    public bool isDone = true;
    static private int totalPoints;

    [SerializeField] private Material notDoneMaterial;
    [SerializeField] private Material doneMaterial;


    private void Start()
    {
        startPosition = transform.position;

        if (player == null)
            player = GameObject.Find("Player");

        if (pointController == null)
            pointController = GameObject.Find("Point Canvas").GetComponent<PointController>();

        if (beltController == null)
            beltController = GameObject.Find("Belt Sign").GetComponent<BeltControler>();
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
        StartTicket();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Right"))
        {
            pointsOfLastAreaEntered = 20;
        }
        if (other.CompareTag("Middle"))
        {
            pointsOfLastAreaEntered = 10;
        }
    }

    void StartTicket()
    {
        if (pointsOfLastAreaEntered != 0)
        {
            StartCoroutine(StartTicketCoroutine(pointsOfLastAreaEntered));
            isDone = false;
            this.GetComponentInChildren<Renderer>().material = notDoneMaterial;
        }
    }

    IEnumerator StartTicketCoroutine(int points)
    {
        yield return new WaitForSeconds(5);
        isDone = true;
        this.GetComponentInChildren<Renderer>().material = doneMaterial;
        totalPoints += points;
        pointController.UpdatePoints(totalPoints);
        beltController.UpdateColor(totalPoints);
        pointsOfLastAreaEntered = 0;
    }

    public void OnResetGame()
    {
        transform.position = startPosition;
        totalPoints = 0;
        pointController.UpdatePoints(totalPoints);
        beltController.UpdateColor(totalPoints);
    }
}
