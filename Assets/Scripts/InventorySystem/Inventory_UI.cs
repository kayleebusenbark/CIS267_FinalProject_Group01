using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryBox;

    public PlayerController player; 

    public List<SlotsUI> slots = new List<SlotsUI>();

    private void Start()
    {
        inventoryBox.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if(!inventoryBox.activeSelf)
        {
            inventoryBox.SetActive(true);
            SetUp();
        }
        else
        {
            inventoryBox.SetActive(false);
        }
    }

    private void SetUp()
    {
        //if (slots.Count == player.inventory.slots.Count)
        //{
        //    for (int i = 0; i < slots.Count; i++)
        //    {
        //        if (player.inventory.slots[i] != Level01Berry.NONE)
        //    }
        //}    
    }


}
