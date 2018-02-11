using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    //The canvas that displays the information
    [SerializeField]
    GameObject mainInformationCanvas;
    //Assessment
    [SerializeField]
    GameObject assessment;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "PlayerOne" && col.name == "PlayerTwo")
        {
            mainInformationCanvas.SetActive(false);
            assessment.SetActive(true);
        }
    }
}
