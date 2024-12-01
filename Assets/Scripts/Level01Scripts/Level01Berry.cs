using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Berry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }







}
