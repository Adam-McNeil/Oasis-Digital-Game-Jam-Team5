using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private float topMaxPosition = 10;
    private float downMaxPosition = -10;

    private Vector3 velocity = new Vector3(0, 0, 2f);

    [SerializeField] private int intialDirection;

    private void Start()
    {
        velocity = velocity * intialDirection;
    }

    private void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime);
        if (this.transform.position.z > topMaxPosition)
        {
            velocity = velocity * -1;
        }
        if (this.transform.position.z < downMaxPosition)
        {
            velocity = velocity * -1;
        }
    }
}
