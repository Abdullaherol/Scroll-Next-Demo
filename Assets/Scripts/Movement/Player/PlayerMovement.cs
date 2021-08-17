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
            targetPosition = transform.position + transform.forward * maxDistance;

            Vector2 swipe = swipeController.Swipe * swipeSpeed;

            switch (direction)
            {
                case MovementDirection.X:
                    targetPosition += new Vector3(swipe.x, 0, 0);
                    
                    break;
                case MovementDirection.Y:
                    targetPosition += new Vector3(0, swipe.x,0);
                    break;
                case MovementDirection.Z:
                    targetPosition += new Vector3(0, 0, swipe.x);
                    break;
                default:
                    break;
            }

            transform.position = Vector3.Lerp(targetPosition, targetPosition, speed * Time.deltaTime);
        }
    }

    public enum MovementDirection
    {
        X,
        Y,
        Z
    }
}
