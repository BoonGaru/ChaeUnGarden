using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecorateSlot : MonoBehaviour
{
    [SerializeField] private int decoPosition;
    [SerializeField] private Image slotImage;

    public void UpdateSlot(Decorate deco)
    {
        if (deco)
        {
            slotImage.sprite = decoPosition == 1 ? deco.frontSprite : deco.backSprite;
        }
    }
}
