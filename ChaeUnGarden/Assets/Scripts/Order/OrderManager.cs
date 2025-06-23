using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<Order> reservaterOrderGroup;
    public Order visitOrder;

    [SerializeField] private Order[] orderGroup;
    [SerializeField] private UIOrderTake[] NPCGroup;
    [SerializeField]
    private OrderCompletionCheak completionCheak;

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void OpenReservate(bool open)
    {
        isOpen = open;
        StartCoroutine(TakeReservate());
        StartCoroutine(ReceiptReservate());
    }

    private Order CreateOrder()
    {
        int index = SelectOrder();
        Order order = orderGroup[index]; //NPC ¼¿·º

        order.RequestType = (BouquetType)Random.Range(0, 3);
        order.RequestSize = (SizeType)Random.Range(0, 3);
        order.ColorType = (ColorType)Random.Range(0, 9);
        order.FlowerType = (FlowerType)Random.Range(0, 2);
        order.SignatureFlower = order.Orderer.SignatureFlower[
            Random.Range(0, order.Orderer.SignatureFlower.Length)];

        return order;
    }
    private int SelectOrder()
    {
        int RandIndex = 0;
        bool isNew = false;

        while (!isNew)
        {
            RandIndex = Random.Range(0, orderGroup.Length);
            isNew = false;

            foreach(var order in reservaterOrderGroup)
            {
                if(RandIndex == order.OrderIndex)
                {
                    isNew = true;
                }
            }
        }

        return RandIndex;
    }

    private IEnumerator TakeReservate()
    {
        while (isOpen)
        {
            yield return new WaitForSeconds(600);

            if (reservaterOrderGroup.Count < 5)
            {
                reservaterOrderGroup.Insert(0, CreateOrder());
                //UI
            }
        }
    }
    private IEnumerator ReceiptReservate()
    {
        while (isOpen)
        {
            yield return new WaitForSeconds(720);

            if (reservaterOrderGroup.Count > 0)
            {
                Order order = reservaterOrderGroup[reservaterOrderGroup.Count - 1];
                NPCGroup[order.Orderer.CharacterIndex].SetOrder(order);

                //UI

                reservaterOrderGroup[reservaterOrderGroup.Count - 1] = null; 
            }
        }
    }
}
