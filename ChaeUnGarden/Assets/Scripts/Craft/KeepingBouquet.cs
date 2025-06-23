using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepingBouquet : MonoBehaviour
{
    public bool IsTake;

    [SerializeField] private List<Bouquet> bouquets = new List<Bouquet>();
    [SerializeField] private BouquetSlot[] slots;
    [SerializeField] private GameObject slotParent;

    void Start()
    {
        slots = slotParent.GetComponentsInChildren<BouquetSlot>();
        this.gameObject.SetActive(false);
    }
    
    public void AddBouquet(Bouquet bouquet)
    {
        bouquets.Add(bouquet);
        Debug.Log(bouquets.Count);
        UpdateBouquets();
    }
    public void DeleteBouquet(int index)
    {
        if(bouquets.Count > index)
        {
            bouquets.Remove(bouquets[index]);
        }
        UpdateBouquets();
    }
    private void UpdateBouquets()
    {
        for (int index = 0; index < slots.Length 
            && index < bouquets.Count; index++)
        {
            slots[index].UpdateSlot(bouquets[index]);
        }

        if (bouquets.Count <= 0)
        {
            slots[0].UpdateSlot(null);
        }
    }

}
