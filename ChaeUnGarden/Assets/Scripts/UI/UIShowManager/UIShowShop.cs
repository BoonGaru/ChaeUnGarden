using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIShowShop : MonoBehaviour
{
    [SerializeField] private ShopSlot[] shopSlot;
    [SerializeField] private TMP_Text priceText;

    private GameData data;

    private void Start()
    {
        data = DataManager.Instance.gameData;
    }

    public void SetWindow()
    {
        this.gameObject.SetActive(true);

        priceText.text = data.money.ToString();

        foreach (ShopSlot slot in shopSlot)
        {
            slot.IsBuy();
        }
    }
}
