using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Berry : MonoBehaviour
{
    public float increaseSpeed = 0.5f; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            //then "destroy" off screen
            Destroy(this.gameObject);
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
