using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIOrderInfo : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text orderText;
    [SerializeField] private GameObject[] buttons;

    private Order order;

    public void SetUIOrder(Order takeOrder)
    {
        TypeDictionary dic = new TypeDictionary();
        order = takeOrder;

        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
        buttons[2].SetActive(false);

        characterImage.sprite = order.OrdererImage[0];

        orderText.text = $"{order.TakeDetail[0]}" +
            $"{order.SignatureFlower.Name}" +
            $"{dic.BouquetTypeToString(order.RequestType)}" +
            $"{order.TakeDetail[1]}" +
            $"{dic.ColorTypeToString(order.ColorType)}" +
            $"{order.TakeDetail[2]}" +
            $"{dic.SizeTypeToString(order.RequestSize)}" +
            $"{order.TakeDetail[3]}" +
            $"{dic.BouquetTypeToString(order.RequestType)}" +
            $"{order.TakeDetail[4]}";
        // 0, 시그니처, 상품타입, 1, 컬러, 2 사이즈 3 타입, 4
    }
    public void SuccessReceipt()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(true);

        orderText.text = order.ReactionDetail[0];
        characterImage.sprite = order.OrdererImage[1];

    }
    public void FailReceipt()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(true);

        orderText.text = order.ReactionDetail[1];
        characterImage.sprite = order.OrdererImage[2];
    }
}
