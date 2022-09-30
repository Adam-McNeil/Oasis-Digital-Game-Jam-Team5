using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    static private List<WallObject> wallObjects = new List<WallObject>();
    WallObject wallObject;

    private float topMaxPosition = 15;
    private float downMaxPosition = -15;

    private int direction = 1;
    private Vector3 maxVelocity = new Vector3(0, 0, 15f);
    private Vector3 baseVelocity = new Vector3(0, 0, 2f);
    private Vector3 velocity;

    [SerializeField] private int intialDirection;

    private void Start()
    {
        wallObject = new WallObject(gameObject, GetComponent<WallController>());
        wallObjects.Add(wallObject);
        direction = intialDirection;
        velocity = baseVelocity * direction;
    }

    private void Update()
    {
        if (wallObject.shouldMove)
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
    }

    private void UpdateSpeed()
    {
        velocity = ((1 - ((float)ClockController.timeLeft / (float)ClockController.totalTime)) * maxVelocity + baseVelocity) * direction;
    }

    private void SetShouldMove(bool newValue)
    {
        wallObject.shouldMove = newValue;
    }

    #region Game Events

    static public void OnStartGame()
    {
        foreach (WallObject wallObject in wallObjects)
        {
            wallObject.wallController.SetShouldMove(true);
        }
    }

    static public void OnEndGame()
    {
        foreach (WallObject wallObject in wallObjects)
        {
            wallObject.wallController.SetShouldMove(false);
        }
    }

    static public void OnResetGame()
    {
    
    }

    #endregion

    struct WallObject
    {
        public WallObject(GameObject gameObject, WallController wallController)
        {
            this.gameObject = gameObject;
            this.wallController = wallController;
            transform = gameObject.transform;
            startPosition = transform.position;
            shouldMove = false;
        }

        public GameObject gameObject;
        public WallController wallController;
        public Transform transform;
        public Vector3 startPosition;
        public bool shouldMove;
    }
}
