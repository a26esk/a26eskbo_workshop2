using System;
using System.Collections.Generic;
using UnityEngine; 

public class PartyChecker : MonoBehaviour
{
    public int DancersRequired = 2;
    public GameObject ObjToShow;
    private List<int> claimedDancers = new List<int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
      
        if (other.tag == "Dancer")
        {
            print("dancer found");
            int id = other.gameObject.GetInstanceID();
            print(id);
            if (!(claimedDancers.Contains(id)))
            {
                print("claiming");
                claimedDancers.Add(id);
            }
            if (claimedDancers.Count >= DancersRequired)
            {
                print("party");
                ObjToShow.SetActive(true);
            }
        }
    }
}
