using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardChamberTrigger : MonoBehaviour
{
    public WizardAI wizard;

    public Collider2D chamberCollider;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            wizard.activateWizard();

            StartCoroutine(delayLock());
        }
    }
    private IEnumerator delayLock()
    {
        yield return new WaitForSeconds(0.3f);

        chamberCollider.isTrigger = false;

    }

}
