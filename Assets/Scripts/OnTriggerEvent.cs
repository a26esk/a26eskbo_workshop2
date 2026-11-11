using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
     [SerializeField] private UnityEvent onTriggerEnter;
     [SerializeField] private UnityEvent onTriggerExit;
     [SerializeField] private string tag = "Player";

     void OnTriggerEnter2D(Collider2D collision)
     {
          if (tag == "" || collision.tag == tag)
          { 
               onTriggerEnter.Invoke();
          }
     }

     void OnTriggerExit2D(Collider2D collision)
     {
          if (tag == "" || collision.tag == tag)
          { 
               onTriggerExit.Invoke();
          }
     }
}
