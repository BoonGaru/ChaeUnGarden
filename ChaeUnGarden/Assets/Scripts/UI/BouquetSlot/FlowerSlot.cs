using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerSlot : MonoBehaviour
{
    [SerializeField] private Image slotImage;
    public void UpdateSlot(Flower flower)
    {
        if (flower != null)
        {
            int index = Random.Range(0, 3);

            slotImage.color = Color.white;
            slotImage.sprite = flower.flowerImage[index];
        }
        else
        {
            slotImage.color = Color.clear;
        }
    }
}
