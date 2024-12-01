using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInvincibility : MonoBehaviour
{

    public float duration = 5f;
    public float rechargeTime = 10f;

    private Slider slider;
    private Canvas invinciblityCanvas;

    private bool isInvincible = false;
    private bool isRecharging = false;
    private float sliderValue = 1f;

    private PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        GameObject canvasObj = GameObject.FindWithTag("invincibleCanvas");
        invinciblityCanvas = canvasObj.GetComponent<Canvas>();
        slider = canvasObj.GetComponentInChildren<Slider>();

        invinciblityCanvas.enabled = false;
        slider.value = sliderValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateInvincibility()
    {
        if (isInvincible || isRecharging)
        {
            return;
        }

        isInvincible = true;
        invinciblityCanvas.enabled = true;
        StartCoroutine(InvincibilityRoutine());

    }

    private IEnumerator InvincibilityRoutine()
    {
        float elaspedTime = 0f;

        while(elaspedTime < duration)
        {
            sliderValue = Mathf.Lerp(1f, 0f, elaspedTime / duration);
            slider.value = sliderValue;
            elaspedTime += Time.deltaTime;
            yield return null;
        }

        isInvincible = false;
        startRecharge();
    }
    private void startRecharge()
    {
        isRecharging = true;    
        StartCoroutine(rechargeRoutine());
    }

    private IEnumerator rechargeRoutine()
    {
        float elapsedTime = 0f;

        while(elapsedTime < rechargeTime)
        {
            sliderValue = Mathf.Lerp(0f,1f, elapsedTime / rechargeTime);

            slider.value = sliderValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isRecharging = false;
    }

    public bool canTakeDamage()
    {
        return !isInvincible;
    }

}
