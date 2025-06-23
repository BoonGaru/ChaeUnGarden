using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Item item;

    [SerializeField] private Image slotImage;
    [SerializeField] private TMP_Text amountText;

    [SerializeField] private Image boxItemImage;
    [SerializeField] private TMP_Text boxNameText;
    [SerializeField] private TMP_Text boxInfoText;
    [SerializeField] private Slider AmountSlider;


    public void UpdateSlot(Item item)
    {
        if (item != null)
        {
            this.item = item;

            slotImage.color = Color.white;
            slotImage.sprite = item.Icon;
            amountText.text = item.Amount.ToString();
        }
        else
        {
            slotImage.color = Color.clear;
            amountText.text = "";
        }
    }
    public void SetUIBox()
    {
        if(item != null)
        {
            boxItemImage.sprite = item.Icon;
            boxNameText.text = item.Name;
            boxInfoText.text = item.Info;
        }
    }
}
