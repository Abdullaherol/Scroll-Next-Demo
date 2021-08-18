using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyBasic : MonoBehaviour
{
    public GameManager gameManager;
    void Update()
    {
        EnemySettings settings = gameManager.enemySettings;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward * settings.basicSpeed, settings.basicMaxDistance);
    }
}
