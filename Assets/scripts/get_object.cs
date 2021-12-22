using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_object : MonoBehaviour
{
    // public Camera getCamera;
    // private RaycastHit hit;

    public Vector2 MousePosition;
    Camera Camera;

    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);
        }
    }
}
