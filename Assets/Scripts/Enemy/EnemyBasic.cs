using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyBasic : MonoBehaviour
{
    //Enemy Ground Checker yazılacak
    public GameManager gameManager;
    private bool died;

    void Start()
    {
        SetStatusRagdoll(false);
    }
    void Update()
    {
        if (!died)
        {
            EnemySettings settings = gameManager.enemySettings;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward * settings.basicSpeed * Time.deltaTime, settings.basicMaxDistance);
        }
    }

    private void SetStatusRagdoll(bool status)
    {
        foreach (var item in GetComponentsInChildren<Rigidbody>())
        {
            item.detectCollisions = status;
        }
    }
}
