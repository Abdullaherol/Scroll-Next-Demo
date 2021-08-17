using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
    public bool OnGround;

    public GroundManager groundManager;
    public Vector3 offset;
    public float maxDistance;
    public LayerMask layer;
    public string groundTag;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + offset, transform.up * -1, out hit, maxDistance, layer))
        {
            OnGround = true;

            if (hit.transform.CompareTag(groundTag))
                groundManager.Fall(hit.transform.gameObject);

        }else 
            OnGround = false;

    }
}
