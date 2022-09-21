using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketController : MonoBehaviour
{
    static private GameObject player;
    static private PointController pointController;
    static private BeltControler beltController;
    static private List<TicketObject> tickets = new List<TicketObject>();
    static private int ticketsLength = 0;
    static private Vector3 offset = new Vector3(1.5f, 2f, 0);
    static private int totalPoints;
    static private Color notDoneColor = new Color(1, 0, 0, 1);
    static private Color doneColor = new Color(0, 1, 0, 1);

    public bool isDone = true;
    private TicketObject ticketObject;


    private void Start()
    {
        ticketObject = new TicketObject(this.gameObject, this.GetComponent<TicketController>());
        tickets.Add(ticketObject);
        ticketsLength++;
        if (player == null)
            player = GameObject.Find("Player");

        if (pointController == null)
            pointController = GameObject.Find("Point Canvas").GetComponent<PointController>();

        if (beltController == null)
            beltController = GameObject.Find("Belt Sign").GetComponent<BeltControler>();
    }
    
    private void Update()
    {
        if (ticketObject.isPickedUp)
        {
            this.transform.position = player.transform.position + offset;
        }
    }

    public void OnPickUp()
    {
        ticketObject.isPickedUp = true;
    }

    public void OnPutDown()
    {
        ticketObject.isPickedUp = false;
        StartTicket();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Right"))
        {
            ticketObject.pointsOfLastAreaEntered = 20;
        }
        if (other.CompareTag("Middle"))
        {
            ticketObject.pointsOfLastAreaEntered = 10;
        }
    }

    void StartTicket()
    {
        if (ticketObject.pointsOfLastAreaEntered != 0)
        {
            StartCoroutine(StartTicketCoroutine());
            isDone = false;
            this.GetComponentInChildren<Renderer>().material.color = notDoneColor;
        }
    }

    IEnumerator StartTicketCoroutine()
    {
        yield return new WaitForSeconds(5);
        isDone = true;
        this.GetComponentInChildren<Renderer>().material.color = doneColor;
        totalPoints += ticketObject.pointsOfLastAreaEntered;
        pointController.UpdatePoints(totalPoints);
        beltController.UpdateColor(totalPoints);
        ticketObject.pointsOfLastAreaEntered = 0;
    }

    private void OnGameEndTicket()
    {
        StopAllCoroutines();
    }

    #region Game Events

    static public void OnStartGame()
    {

    }

    static public void OnEndGame()
    {
        // This ensures that the player can not gain any points after the game ended
        foreach (TicketObject ticket in tickets)
        {
            ticket.ticketController.OnGameEndTicket();
        }
    }

    static public void OnResetGame()
    {
        // This resets the position of every ticket
        foreach (TicketObject ticket in tickets)
        {
            ticket.transform.position = ticket.startPosition;
            ticket.gameObject.GetComponentInChildren<Renderer>().material.color = doneColor;
        }
        
        totalPoints = 0;
        pointController.UpdatePoints(totalPoints);
        beltController.UpdateColor(totalPoints);
    }

    #endregion

    struct TicketObject
    {
        public TicketObject (GameObject gameObject, TicketController ticketController)
        {
            this.gameObject = gameObject;
            this.ticketController = ticketController;
            transform = gameObject.transform;
            startPosition = transform.position;
            isPickedUp = false;
            pointsOfLastAreaEntered = 0;
        }
        
        public GameObject gameObject;
        public TicketController ticketController;
        public Transform transform;
        public Vector3 startPosition;
        public bool isPickedUp;
        public int pointsOfLastAreaEntered;
    }
}
