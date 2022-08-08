using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private float topMaxPosition = 10;
    private float downMaxPosition = -10;

    private Vector3 maxVelocity = new Vector3(0, 0, 15f);
    private Vector3 baseVelocity = new Vector3(0, 0, 1f);
    private Vector3 velocity;

    [SerializeField] private int intialDirection;

    private void Start()
    {
        velocity = maxVelocity;
        velocity = velocity * intialDirection;
        baseVelocity = baseVelocity * intialDirection;
        maxVelocity = maxVelocity * intialDirection;
    }

    private void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime);
        if (this.transform.position.z > topMaxPosition)
        {
            velocity = velocity * -1;
            maxVelocity = maxVelocity * -1;
            baseVelocity = baseVelocity * -1;
        }
        if (this.transform.position.z < downMaxPosition)
        {
            velocity = velocity * -1;
            maxVelocity = maxVelocity * -1;
            baseVelocity = baseVelocity * -1;

        }
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        velocity = (1 - (float)ClockController.timeLeft / (float)ClockController.totalTime) * maxVelocity + baseVelocity;
    }
}
