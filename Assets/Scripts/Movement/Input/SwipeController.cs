using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public Vector2 Swipe = new Vector2();
    [Range(0,1)]
    public float sensitivity = .001f;
    private Vector3 lastPos;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            lastPos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            Swipe = (Input.mousePosition - lastPos) * sensitivity;
        }

        Swipe = Vector2.Lerp(Swipe, new Vector2(0,0),10 * Time.deltaTime);
        
    }
}

