using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIKeepingInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text infoText;

    public void SetText(Bouquet bouquet)
    {
        if(bouquet != null)
        {
            this.gameObject.SetActive(true);
            TypeDictionary dic = new TypeDictionary();

            infoText.text =
                $"�ñ״�ó �� : {bouquet.signatureFlower.Name}\r\n" +
                $"Ÿ�� : {dic.BouquetTypeToString(bouquet.bouquetType)}\r\n" +
                $"�÷� : {dic.ColorTypeToString(bouquet.colorType)}\r\n" +
                $"������ : {dic.SizeTypeToString(bouquet.sizeType)}";
        }
    }
}
