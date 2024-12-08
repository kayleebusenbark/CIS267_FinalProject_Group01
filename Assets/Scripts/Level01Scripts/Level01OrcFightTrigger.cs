using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01OrcFightTrigger : MonoBehaviour
{
    public OrcAi orc;
    public Collider2D bossCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            orc.activateOrc();
            StartCoroutine(delayLock()); 

        }
    }

    private IEnumerator delayLock()
    {
        yield return new WaitForSeconds(0.5f);
        bossCollider.isTrigger = false; 
    }
}
