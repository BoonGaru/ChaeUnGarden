using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectDecoSlot : MonoBehaviour
{
    [SerializeField] private Decorate decorate;
    [SerializeField] private CraftingBouquet craftingBouquet;

    [SerializeField] private DecorateSlot decoFront;
    [SerializeField] private DecorateSlot decoBack;

    [SerializeField] private TMP_Text amountText;

    public void SelectDecorate()
    {
        craftingBouquet.SelectDecorate(decorate);

        decoFront.UpdateSlot(decorate);
        decoBack.UpdateSlot(decorate);
    }
    public void UpdateUI()
    {
        amountText.text = decorate.Amount.ToString();
    }
}
