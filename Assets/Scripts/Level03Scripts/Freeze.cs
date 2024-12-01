using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class Freeze: MonoBehaviour
{

    public Canvas canvas;
    public Slider slider;
    public float duration = 10f;
    public float rechargeRate = 1f;

    private bool isInvincible = false;
    private bool canActivate = false;

    public KeyCode activeKey = KeyCode.F;


    private void Start()
    {
        canvas = GetComponent<Canvas>();    
        canvas.enabled = false;

        slider = canvas.GetComponentInChildren<Slider>();
        slider.maxValue = 100f;
        slider.value = 100f;
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

            if (Input.GetKeyUp(activeKey) && slider.value >= slider.maxValue)
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
    }

    private void endPowerUp()
    {
        isInvincible = false;
    }

}
