using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftAddSlot : MonoBehaviour
{
    [SerializeField] private CraftManager craftManager;
    [SerializeField] private CraftingBouquet craftingBouquet;
    [SerializeField] private FlowerSlot slot;

    [SerializeField] private int slotIndex;

    void Start()
    {
        slot = this.GetComponent<FlowerSlot>();
    }
    public void AddFlowerSlot()
     {
        
        if(craftingBouquet.SlotFill(slotIndex) != null)
        {
            craftingBouquet.DeleteFlower(slotIndex);
            slot.UpdateSlot(null);
        }
        else
        {
            if (craftManager.selectFlower.Amount > 0)
            {
                Flower flower = craftManager.selectFlower;

                craftingBouquet.AddFlower(flower, slotIndex);
                slot.UpdateSlot(flower);
            }
        }
        craftManager.FlowerSlot.UpdateUI();
     }
}
