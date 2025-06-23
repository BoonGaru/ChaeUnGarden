using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShowCrafting : MonoBehaviour
{
    [SerializeField] private Transform flowerParent;
    [SerializeField] private Transform decoParent;

    [SerializeField] private SelectFlowerSlot[] flowerSlot;
    [SerializeField] private SelectDecoSlot[] decoSlot;


    public void SetWindow()
    {
        this.gameObject.SetActive(true);

        if(flowerSlot.Length == 0 || decoSlot.Length == 0)
        {
            flowerSlot = flowerParent.GetComponentsInChildren<SelectFlowerSlot>();
            decoSlot = decoParent.GetComponentsInChildren<SelectDecoSlot>();
        }

        foreach(SelectFlowerSlot slot in flowerSlot)
        {
            slot.UpdateUI();
        }
        foreach(SelectDecoSlot slot in decoSlot)
        {
            slot.UpdateUI();
        }
    }
}
