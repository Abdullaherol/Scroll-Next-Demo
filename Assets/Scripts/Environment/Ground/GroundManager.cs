using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public float limitY;
    public float waitTime;
    public Vector3 poolPosition;

    private List<GameObject> grounds = new List<GameObject>();

    public void Fall(GameObject obj)
    {
        if (!grounds.Contains(obj))
        {
            grounds.Add(obj);
            Ground ground = obj.AddComponent<Ground>();
            ground.FallStart(this);
        }
    }

    public void TeleportPool(GameObject obj)
    {
        obj.transform.position = poolPosition;
        obj.SetActive(false);
    }
}
