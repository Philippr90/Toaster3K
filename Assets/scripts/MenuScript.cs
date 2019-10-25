using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject dropdownLabel;

    public void StartGame()
    {        
        Text dropdownText = dropdownLabel.GetComponent<Text>();
        string dropdownValue = dropdownText.text;

        // "Stage1" is the name of the first scene we created.
        if (dropdownValue == "Plane")
        {
            Application.LoadLevel("Stage1");
        }
        else
        {
            Application.LoadLevel("Stage2");
        }
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
