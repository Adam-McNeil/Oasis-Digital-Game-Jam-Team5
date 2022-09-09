using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private float topMaxPosition = 15;
    private float downMaxPosition = -15;

    private int direction = 1;
    private Vector3 maxVelocity = new Vector3(0, 0, 15f);
    private Vector3 baseVelocity = new Vector3(0, 0, 2f);
    private Vector3 velocity;

    [SerializeField] private int intialDirection;

    private void Start()
    {
        direction = intialDirection;
        velocity = baseVelocity * direction;
    }

    private void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime);
        if (this.transform.position.z > topMaxPosition)
        {
            direction *= -1;
        }
        if (this.transform.position.z < downMaxPosition)
        {
            direction *= -1;
        }
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        velocity = ((1 - ((float)ClockController.timeLeft / (float)ClockController.totalTime)) * maxVelocity + baseVelocity) * direction;
    }
}
