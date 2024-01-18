using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questUI : MonoBehaviour
{
    public Text questTitleText;
    public Text questDescriptionText;

    public void UpdateQuestUI(string title, string description)
    { 
        questTitleText.text = title;
        questDescriptionText.text = description;
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
