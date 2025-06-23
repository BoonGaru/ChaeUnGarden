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
                $"시그니처 꽃 : {bouquet.signatureFlower.Name}\r\n" +
                $"타입 : {dic.BouquetTypeToString(bouquet.bouquetType)}\r\n" +
                $"컬러 : {dic.ColorTypeToString(bouquet.colorType)}\r\n" +
                $"사이즈 : {dic.SizeTypeToString(bouquet.sizeType)}";
        }
    }
}
