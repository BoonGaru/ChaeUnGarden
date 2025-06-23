using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFurnitureSlot : MonoBehaviour
{
    [SerializeField] private InventorySlot slot;
    [SerializeField] private PlaceManager placeManager;
    [SerializeField] private GameObject useButton;

    [SerializeField] private UseTile useTile;

    public void SetUIBoxFurniture()
    {
        if(slot.item is Furniture)
        {
            useButton.SetActive(true);
            useTile.item = (Furniture)slot.item;
        }
    }
}
