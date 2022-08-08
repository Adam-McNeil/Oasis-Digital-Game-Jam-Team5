using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rigidbody;

    private float xInput;
    private float yInput;

    private float speed = 3f;
    private bool spaceWasPressed;
    private GameObject ticketToPickUp = null;
    private GameObject heldObject;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            if (heldObject == null)
            {
                PickUp();
            }
            else
            {
                PutDown();
            }
        }
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(xInput, 0, yInput).normalized * speed, ForceMode.VelocityChange);
    }

    #region PickUp
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ticket"))
        {
            ticketToPickUp = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ticket") && other.gameObject == ticketToPickUp)
        {
            ticketToPickUp = null;
        }
    }

    private void PickUp()
    {
        if (ticketToPickUp != null && ticketToPickUp.GetComponent<TicketController>().isDone)
        {
            Debug.Log("Ticket picked up");
            heldObject = ticketToPickUp;
            heldObject.GetComponent<TicketController>().OnPickUp();
        }
    }

    private void PutDown()
    {
        Debug.Log("Ticket Put Down");
        heldObject.GetComponent<TicketController>().OnPutDown();
        heldObject = null;

    }
    #endregion
}
