using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory;

    [SerializeField] private ItemGroup itemGroup;
    [SerializeField] private InventorySlot[] slots;
    [SerializeField] private Transform slotParent;

    private void Start()
    {
        inventory = new List<Item>(itemGroup.group);
        slots = slotParent.GetComponentsInChildren<InventorySlot>();
        UpdateInventory();
    }
    public void UpdateInventory()
    {
        InitInventory();

        for (int index = 0; index < slots.Length; index++)
        {
            slots[index].UpdateSlot(null);
        }

        for (int index = 0; index < inventory.Count && index < slots.Length; index++)
        {
            if (inventory[index].Amount > 0)
            {
                slots[index].UpdateSlot(inventory[index]);
            }
        }
    }
    public void AddInventory(Item item)
    {
        inventory.Add(item);
        UpdateInventory();
    }
    private void InitInventory()
    {
        for(int item = inventory.Count - 1; item >= 0; item--)
        {
            if (inventory[item].Amount <= 0)
            {
                inventory.Remove(inventory[item]);
            }
            else Debug.Log(inventory[item].Name);
        }
    }

    //¹öÆ°
    public void SortIndex()
    {

    }
    public void SortAlphabet()
    {

    }
    public void SortAmount()
    {

    }
}
