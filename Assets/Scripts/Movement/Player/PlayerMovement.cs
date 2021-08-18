using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float maxDistance;
    public float swipeSpeed;
    public float positionY = .5f;
    public MovementDirection direction;

    public SwipeController swipeController;
    public PlayerGroundChecker groundChecker;

    private Vector3 targetPosition;

    private Rigidbody rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        SetStatusRagdoll(false);
    }

    private void SetStatusRagdoll(bool status)
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.detectCollisions = status;
        }
    }

    void Update()
    {
        if (groundChecker.OnGround)
        {
            targetPosition = transform.position;

            rbody.velocity = new Vector3(rbody.velocity.x,0,rbody.velocity.z);

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

            transform.rotation = Quaternion.LookRotation(transform.position - targetPosition);

            transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
        }
    }

    public enum MovementDirection
    {
        X,
        Z
    }
}
