using System;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] private Camera theCamera;

    private void Awake()
    {
        if (theCamera == null)
        {
            theCamera = Camera.main;
        }
    }

    private void Update()
    {
        var mousePos = Input.mousePosition;
        transform.position = theCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
    }
}