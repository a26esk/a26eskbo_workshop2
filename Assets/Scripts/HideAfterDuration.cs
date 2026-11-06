using UnityEngine;

public class HideAfterDuration : MonoBehaviour
{
    [SerializeField] private float time = 4.0f;
    private float timePassed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= time)
        {
            gameObject.SetActive(false);
        }
    }
}
