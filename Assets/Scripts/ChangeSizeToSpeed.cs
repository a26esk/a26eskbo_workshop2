using System;
using UnityEngine;

public class ChangeSizeToSpeed : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float maxSize = 15;
    private float startSize;

    void Start()
    {
        startSize = cam.orthographicSize;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        float newSize = Mathf.Clamp(startSize - rb.linearVelocityY / 10, startSize, maxSize);
        if (rb.linearVelocityY < -15)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newSize, Time.deltaTime * 10);
            //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, maxZoom, -rb.velocity.magnitude);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, startSize, Time.deltaTime * 10);
        }
    }
}
