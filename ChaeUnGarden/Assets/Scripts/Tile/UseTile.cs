using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTile : MonoBehaviour
{
    public Furniture item;

    [SerializeField] private PlaceManager placemanager;

    public void UseItem()
    {
        item.Amount--;
        placemanager.StartPlacement(item.furnitureObj, 1);
        this.gameObject.SetActive(false);
    }
}
