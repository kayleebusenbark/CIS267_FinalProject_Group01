using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public Image sword;
    public Image shield;
    public Image fruit;
    public Image scroll;
    public Image emerald;
    public Image sapphire;
    public Image ruby;

    //for the berry 
    public int fruitCount;
    public TextMeshProUGUI fruitCountText;
    public PlayerController player;
    public Level01Berry berry; 
    public float speedIncrease = 0.5f;
    private AudioSource audioSource;


    void Start()
    {
        sword.enabled = false;
        shield.enabled = false;
        fruit.enabled = false;
        scroll.enabled = false;
        emerald.enabled = false;
        sapphire.enabled = false;
        ruby.enabled = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        fruitCountText.text = fruitCount.ToString();

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            UseFruit();
        }

    }

    public void showSwordandShield()
    {
        sword.enabled=true;
        shield.enabled=true;
    }

    public void showFruit()
    {
        fruit.enabled=true;
    }

    public void showScroll()
    {
        scroll.enabled=true;
    }

    public void showEmerald()
    {
        emerald.enabled=true;
    }

    public void showSapphire()
    {
        sapphire.enabled=true;
    }

    public void showRuby()
    {
        ruby.enabled=true;
    }

    public void hideFruit()
    {
        if(fruitCount == 0)
        {
            fruit.enabled=false;
        }
    }

    public void UseFruit()
    {
        if(fruitCount > 0)
        {
            fruitCount--;
            player.movementSpeed(speedIncrease);
            audioSource.Play();

            UpdateFruitCountUI();
        }
    }

    private void UpdateFruitCountUI()
    {
        fruitCountText.text = fruitCount.ToString(); 
    }

}
