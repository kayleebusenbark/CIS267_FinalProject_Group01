using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Berry : MonoBehaviour
{
    public float increaseSpeed = 0.5f;

    private AudioSource audioSource;
    private BoxCollider2D itemColider;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        itemColider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            //then "destroy" off screen
            itemColider.enabled = false;
            spriteRenderer.enabled = false;
           // Destroy(this.gameObject);
        }
    }

    //   !this needs to go in the player script !

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Berries"))
    //    {
    //        Rigidbody rb = GetComponent<Rigidbody>();

    //        if(rb != null)
    //        {
    //            rb.velocity += rb.velocity.normalized * increaseSpeed; 
    //        }
    //    }
    //}








}
