using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level01Berry : MonoBehaviour
{
    public float increaseSpeed = 0.5f;
    public float speed = 1f;
    
    private BoxCollider2D itemColider;
    private SpriteRenderer spriteRenderer;
   
    private void Start()
    {
        
        itemColider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            
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
