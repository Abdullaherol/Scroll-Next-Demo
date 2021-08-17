using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private GroundManager groundManager;
    private Animator animator;
    private Rigidbody rgb;

    public void FallStart(GroundManager groundManager)
    {
        this.groundManager = groundManager;

        animator = GetComponent<Animator>();
        rgb = gameObject.AddComponent<Rigidbody>();

        StartCoroutine(WaitAndFall());
    }
    private IEnumerator WaitAndFall()
    {
        animator.Play("Fall");
        yield return new WaitForSeconds(groundManager.waitTime);
        rgb.useGravity = true;
    }

    void Update()
    {
        if(transform.position.y < groundManager.limitY)
        {
            groundManager.TeleportPool(gameObject);
        }
    }
}
