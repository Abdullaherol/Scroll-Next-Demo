using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float maxDistance;
    public float swipeSpeed;
    public MovementDirection direction;

    public SwipeController swipeController;
    public PlayerGroundChecker groundChecker;

    private Vector3 targetPosition;

    void Update()
    {
        if (groundChecker.OnGround)
        {
            targetPosition = transform.position;

            Vector2 swipe = swipeController.Swipe * swipeSpeed;

            switch (direction)
            {
                case MovementDirection.X:
                    targetPosition += new Vector3(maxDistance, 0, swipe.x);
                    break;
                case MovementDirection.Z:
                    targetPosition += new Vector3(swipe.x, 0, maxDistance);
                    break;
                default:
                    break;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.LookAt(targetPosition);
        }
    }

    public enum MovementDirection
    {
        X,
        Z
    }
}
