using System;
using TMPro;
using UnityEngine;

public class GloopHandler : MonoBehaviour
{
    [SerializeField] private Dialogue mainDancerDialogue;
    [SerializeField] private int gloopsCollected = 0;
    [SerializeField] private TextMeshPro gloopsCollectedText;
    [SerializeField] private TextMeshPro victoryText;
    
    [SerializeField] private int winGloopsNeeded;
    [SerializeField] private AudioSource audioSource;


    public void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void AddOneGloop()
    {
        gloopsCollected++;
        audioSource.Play();
    }

    void Update()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        UpdateGloopText();
    }
    
    public void UpdateGloopText()
    {
        gloopsCollectedText.text = "Gloops Collected: " + gloopsCollected;
        if (gloopsCollected < winGloopsNeeded && gloopsCollected > 0)
        {
            victoryText.text = "Barely a party";
            //if (mainDancerDialogue.allowDialogueSwitch) mainDancerDialogue.useDialogue2 = true;
        }
        else
        {
            victoryText.text = "Great fucking party!!!!!";
            //if (mainDancerDialogue.allowDialogueSwitch) mainDancerDialogue.useDialogue3 = true;
            
        }
    }
}
