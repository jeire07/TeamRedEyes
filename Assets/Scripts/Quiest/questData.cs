using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questData : MonoBehaviour
{
    public string questName;
    public string questDescription;
    public string questObjective;
    public int questRewards;
    public bool isCompleted;

    public questData(string name, string description, string objective) //int rewards
    { 
        questName = name;
        questDescription = description;
        questObjective = objective;
       // questRewards = rewards;
        isCompleted = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
