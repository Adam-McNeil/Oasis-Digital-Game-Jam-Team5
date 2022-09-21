using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private Rigidbody rigidbody;

    private Vector3 startPosition;

    private Vector2 changeInPosition; 
    Vector3 mousePos;

    private float speed = 0.5f;
    private GameObject ticketToPickUp = null;   // The ticket that the play would pick up if they pressed space can only be one
    private GameObject heldObject;  // The ticket that the player is holding
    private bool canMove = true;
    void Start()
    {
        startPosition = transform.position;
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckForPickUpInput();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && canMove)
        {
            mousePos = Input.mousePosition;
            changeInPosition = mousePos - camera.WorldToScreenPoint(this.transform.position);
            rigidbody.AddForce(new Vector3(changeInPosition.x, 0, changeInPosition.y).normalized * speed, ForceMode.VelocityChange);
        }
        //Debug.Log((float)Math.Asin(rigidbody.velocity.z / rigidbody.velocity.magnitude) * 180);
        //transform.eulerAngles = new Vector3(0, (float) Math.Atan(changeInPosition.x / changeInPosition.y)*180, 0);
    }

    #region Game Events

    public void OnStartGame()
    {
        canMove = true;
    }

    public void OnEndGame()
    {
        canMove = false;
    }

    public void OnResetGame()
    {
        transform.position = startPosition;
    }

    #endregion


    #region PickUp
    private void CheckForPickUpInput()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ticket"))
        {
            ticketToPickUp = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == ticketToPickUp)
        {
            ticketToPickUp = null;
        }
    }

    private void PickUp()
    {
        if (ticketToPickUp != null && ticketToPickUp.GetComponent<TicketController>().isDone)
        {
            heldObject = ticketToPickUp;
            heldObject.GetComponent<TicketController>().OnPickUp();
        }
    }

    // Will only run if heldObject is not null
    private void PutDown()
    {
        heldObject.GetComponent<TicketController>().OnPutDown();
        heldObject = null;
    }
    #endregion
}
