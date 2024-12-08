using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CyclopsChamberTrigger : MonoBehaviour
{

    public CyclopsAI2 cyclops;

    public Collider2D chamberCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cyclops.activateCyclops();

            StartCoroutine(delayLock());
        }
    }
    private IEnumerator delayLock()
    {
        yield return new WaitForSeconds(0.5f);

        chamberCollider.isTrigger = false;

    }
}
