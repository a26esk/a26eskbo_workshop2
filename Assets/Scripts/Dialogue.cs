using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private List<string> dialogueLines;
    [SerializeField] private TMPro.TextMeshProUGUI text;
    [Header("Range")]
    [Tooltip("Add a TriggerCollider to only display button if player is close")]
    [SerializeField] private bool ranged = true;
    [Tooltip("What is set_active when 'tag' is in TriggerCollider")]
    [SerializeField] private GameObject dialogueContainer;
    [SerializeField] private string tag = "Player";
    
    [Header("Events")]
    [SerializeField] private UnityEvent onDialogueStart;
    [SerializeField] private UnityEvent onDialogueEnd;

    private string startText; // Sets text to this when dialogue is finished
    private int currentIndex = -1;

    void Start()
    {
        startText = text.text;
        if (ranged && GetComponent<Collider2D>())
        {
            if (dialogueContainer == gameObject)
            {
                Debug.LogError("Dialogue container can't be the same game object as Dialogue");
            }
            else
            {
                dialogueContainer.SetActive(false);
            }
        }
    }
    
    public void NextDialogue()
    {
        if (currentIndex < 0)
        {
            onDialogueStart.Invoke();
        }

        currentIndex++;
        if (currentIndex < dialogueLines.Count)
        {
            text.text = dialogueLines[currentIndex];
        }
        else
        {
            text.text = startText;
            currentIndex = -1;
            onDialogueEnd.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("OnTriggerEnter2D");
        if (ranged && other.tag == tag)
        {
            print("hello");
            dialogueContainer.SetActive(true);
        }
            
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (ranged && other.tag == tag)
        {
            dialogueContainer.SetActive(false);
        }
    }
}
