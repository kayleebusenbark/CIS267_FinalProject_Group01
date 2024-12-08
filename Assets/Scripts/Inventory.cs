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
    public Image scroll;
    public Image emerald;
    public Image sapphire;
    public Image ruby;


    void Start()
    {
        sword.enabled = false;
        shield.enabled = false;
        scroll.enabled = false;
        emerald.enabled = false;
        sapphire.enabled = false;
        ruby.enabled = false;
    }


    public void showSwordandShield()
    {
        sword.enabled=true;
        shield.enabled=true;
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



}
