using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrderTake : MonoBehaviour
{
    public Order order;

    [SerializeField] private OrderCompletionCheak completionCheak;
    [SerializeField] private NPCMovement movement;

   void Start()
    {

    }
    public void SetOrder(Order newOrder)
    {
        order = newOrder;

        this.gameObject.SetActive(true);
        movement.GoCounter();
    }
    public void VisitCounter()
    {
        completionCheak.MeetOrderer(order);
    }
    public void ComeBack()
    {
        this.gameObject.SetActive(false);
    }
}
