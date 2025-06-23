using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCompletionCheak : MonoBehaviour
{
    public Order order;

    [SerializeField] private OrderManager orderManager;
    [SerializeField] private UIOrderInfo uiOrderInfo;
    [SerializeField] private GameObject orderTakeWindow;

    [SerializeField] private KeepingBouquet keeper;
    [SerializeField] private GameObject keepingWindow;

    [SerializeField] private MoneyText moneyText;

    private GameData data;

    void Start()
    {
        data = DataManager.Instance.gameData;
    }
    public void MeetOrderer(Order receivedOrder)
    {
        order = receivedOrder;

        uiOrderInfo.SetUIOrder(order);
        orderTakeWindow.SetActive(true);
    }
    public void FinishReceipt(int price)
    {
        uiOrderInfo.SuccessReceipt();
        keepingWindow.SetActive(false);
        keeper.IsTake = false;

        data.money += price;
        moneyText.SetMoneyText();
    }

    public void CheakCompletion(Bouquet bouquet)
    {

        Debug.Log("체크시작");
        int price = bouquet.price;
        int bonus = 0;

        if(order.RequestType == bouquet.bouquetType)
        {
            bonus++;
        }
        if(order.RequestSize == bouquet.sizeType)
        {
            bonus++;
        }
        if(order.ColorType == bouquet.colorType)
        {
            bonus++;
        }
        if(order.FlowerType == bouquet.flowerType)
        {
            bonus++;
        }
        if (order.SignatureFlower == bouquet.signatureFlower)
        {
            bonus++;
        }

        price += (bouquet.price / 10) * bonus;

        FinishReceipt(price);
    }

    public void ShowKeepingWindow()
    {
        keepingWindow.SetActive(true);
        keeper.IsTake = true;
    }
}
