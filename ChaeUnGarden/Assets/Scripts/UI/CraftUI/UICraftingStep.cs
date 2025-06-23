using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICraftingStep : MonoBehaviour
{
    [SerializeField] private CraftManager craftManager;
    [SerializeField] private CraftingBouquet crafting;

    [SerializeField] private GameObject craftWindow;
    [SerializeField] private GameObject[] stepSlot;
    [SerializeField] private GameObject decoObject;


    void Start()
    {
        craftManager = this.GetComponent<CraftManager>();
    }

    public void NextStep()
    {
        if(craftManager.stepIndex == 0)
        {
            stepSlot[craftManager.stepIndex].SetActive(false);

            craftManager.stepIndex++;
            decoObject.SetActive(true);

            stepSlot[craftManager.stepIndex].SetActive(true);
        }
        else
        {
            craftWindow.SetActive(false);
            crafting.FInishedCraft();
            craftManager.stepIndex = 0;
        }
       
    }
}
