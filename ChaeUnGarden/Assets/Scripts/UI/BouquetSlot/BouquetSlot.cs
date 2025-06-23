using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BouquetSlot : MonoBehaviour
{
    public Bouquet bouquet;

    [SerializeField] private FlowerSlot[] flowerSlot;
    [SerializeField] private Image decoFront;
    [SerializeField] private Image decoBack;
    [SerializeField] private UIKeepingInfo keepingInfo;

    [SerializeField] private Sprite clearSprite;


    public void UpdateSlot(Bouquet bouquet)
    {
        this.bouquet = bouquet;

        if (bouquet != null)
        {
            for (int i = 0; i < flowerSlot.Length; i++)
            {
                flowerSlot[i].UpdateSlot(bouquet.flowers[i]);
            }

            decoBack.sprite = bouquet.decoBackSprite;
            decoFront.sprite = bouquet.decoFrontSprite;
        }
        else
        {

            for (int i = 0; i < flowerSlot.Length; i++)
            {
                flowerSlot[i].UpdateSlot(null);
            }

            decoBack.sprite = clearSprite;
            decoFront.sprite = clearSprite;
        }

    }
    public void SetUI()
    {
        keepingInfo.SetText(bouquet);
    }
}
