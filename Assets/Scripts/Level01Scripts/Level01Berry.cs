using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level01Berry : MonoBehaviour
{

    public Canvas canvas;
    public Slider slider;
    public float duration = 2f;
    public float rechargeRate = 5f;

    private bool isInvincible = false;
    private bool canActivate = false;

    public AudioSource audioSource;
    private PlayerHealth playerHealth;


    private void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

        slider = canvas.GetComponentInChildren<Slider>();
        slider.maxValue = 100f;
        slider.value = 100f;
    
        playerHealth = FindObjectOfType<PlayerHealth>();
        audioSource.mute = true;

    }

    private void Update()
    {
        if (isInvincible)
        {
            slider.value -= (100f / duration) * Time.deltaTime;

            if (slider.value <= 0)
            {
                endPowerUp();
            }

        }

        else if (canActivate)
        {
            if (slider.value < slider.maxValue)
            {
                slider.value += rechargeRate * Time.deltaTime;
            }

            if ((Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.JoystickButton4)) && slider.value >= slider.maxValue)
            {
                activePowerUp();
            }
        }
    }

    public void showCanvas()
    {
        canvas.enabled = true;
        canActivate = true;
    }

    private void activePowerUp()
    {
        isInvincible = true;
        audioSource.mute = false;
        audioSource.Play();

        playerHealth.setInvincible(true);
    }

    private void endPowerUp()
    {
        isInvincible = false;
        playerHealth.setInvincible(false);
    }
}
