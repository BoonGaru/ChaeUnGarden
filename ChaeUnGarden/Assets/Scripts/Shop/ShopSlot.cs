using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private PlaceManager placeManager;

    [SerializeField] private UIShopSlot uiSlot;
    [SerializeField] private GameObject tile;

    [SerializeField] private MoneyText moneyText;

    private GameData data;
    void Start()
    {
        data = DataManager.Instance.gameData;
        uiSlot = GetComponent<UIShopSlot>();

        uiSlot.SetUIShopSlot(item);
        IsBuy();
    }

    public void BuyItem()
    {
        if (IsBuy())
        {
            data.money -= item.Price;
            moneyText.SetMoneyText();

            item.Amount++;
            item.IsLock = false;

            if (tile != null)
            {
                placeManager.StartPlacement(tile, 2);
            }
        }
    }
    public bool IsBuy()
    {
        if (data.money >= item.Price && !item.IsLock)
        {
            uiSlot.SetButtonColor(1);
            return true;
        }
        else
        {
            uiSlot.SetButtonColor(0);
            return false;
        }
    }
}
