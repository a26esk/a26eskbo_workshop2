using TMPro;
using UnityEngine;

public class GloopHandler : MonoBehaviour
{
    [SerializeField] private int gloopsCollected = 0;
    [SerializeField] private TextMeshPro gloopsCollectedText;
    [SerializeField] private TextMeshPro victoryText;

    public void AddOneGloop()
    {
        gloopsCollected++;
    }

    void Update()
    {
        UpdateGloopText();
    }
    
    public void UpdateGloopText()
    {
        gloopsCollectedText.text = "Gloops Collected: " + gloopsCollected;
        if (gloopsCollected < 10 && gloopsCollected > 0)
        {
            victoryText.text = "Barely a party";
        }
        else
        {
            victoryText.text = "Great fucking party!!!!!";
        }
    }
}
