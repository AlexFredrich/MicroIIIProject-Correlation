using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{// step 1, declare variables

    [SerializeField]
    GameObject interactableObject;

    private AudioSource audioSource;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
    //step 2 Initialize variables
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Coin touched!");
        audioSource.Play();
        boxCollider2D.enabled = false;
        spriteRenderer.enabled = false; // .enabled only works on components

        Destroy(gameObject, audioSource.clip.length + 0.01f); // kill the coin once the sound bite is over.audioSource.clip.length calls the specific length of the clip.
    }
}
