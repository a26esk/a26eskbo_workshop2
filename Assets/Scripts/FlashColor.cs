using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Color> colors;
    [SerializeField] private float duration = 1.0f;
    private float timePassed = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is null");
        }

        if (colors == null)
        {
            Debug.LogError("Colors is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= duration)
        {
            timePassed = 0.0f;
            spriteRenderer.color = colors[Random.Range(0, colors.Count)];
        }
    }
}
