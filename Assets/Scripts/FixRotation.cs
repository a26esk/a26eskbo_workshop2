using UnityEngine;

public class FixRotation : MonoBehaviour
{
    private Quaternion initialRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = initialRotation;
    }
}