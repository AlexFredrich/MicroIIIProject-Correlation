using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    //Get the object that it is interacting with
    [SerializeField]
    GameObject interactableObject;

    private void Start()
    {
        //step 2 Initialize variables
        
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


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

        
        boxCollider2D.enabled = false;
        spriteRenderer.enabled = false; // .enabled only works on components

        Destroy(gameObject);
    }



}
