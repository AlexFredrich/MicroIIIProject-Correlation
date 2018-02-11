using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{

    //Get the object that it is interacting with
    [SerializeField]
    GameObject interactableObject;

    //Either reveals or removes the object that the switch is connected to
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (interactableObject.activeSelf == true)
            {
                interactableObject.SetActive(false);
            }
            else
            {
                interactableObject.SetActive(true);
            }
        }
    }



}
