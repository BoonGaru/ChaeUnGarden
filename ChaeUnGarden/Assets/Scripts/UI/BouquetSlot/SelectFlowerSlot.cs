using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectFlowerSlot : MonoBehaviour
{
    [SerializeField] private Flower flower;
    [SerializeField] private CraftManager craftManager;

    [SerializeField] private TMP_Text amountText;

    public void SelectFlower()
    {
        craftManager.SetFlower(flower, this);
    }
    public void UpdateUI()
    {
        amountText.text = flower.Amount.ToString();
    }
}