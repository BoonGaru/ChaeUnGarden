using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassBouquet : MonoBehaviour
{
    [SerializeField] private OrderManager orderManager;
    [SerializeField] private OrderCompletionCheak completionCheak;
    [SerializeField] private KeepingBouquet keeper;
    [SerializeField] private BouquetSlot bouquetSlot;

    [SerializeField] private int slotIndex;

    public void PassCheak()
    {
        if(bouquetSlot.bouquet != null && keeper.IsTake)
        {
            completionCheak.CheakCompletion(bouquetSlot.bouquet);
            keeper.DeleteBouquet(slotIndex);
            keeper.IsTake = false;
        }
    }
}
