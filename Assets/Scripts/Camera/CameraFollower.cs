using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject target;

    public float speed;
    public float rotationSpeed;
    
    [Header("Offsets")]
    public Vector3 offset;
    public Vector3 finishOffset;
    
    [Header("Rotations")]
    public Vector3 rotation;
    public Vector3 finishRotation;

    void Update()
    {
        if(target != null)
        {
            if (!gameManager.gameFinished)
            {
                transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, speed * Time.deltaTime);

                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, rotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, target.transform.position + finishOffset, speed * Time.deltaTime);

                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, finishRotation, rotationSpeed * Time.deltaTime);
            }
            
        }
    }
}
