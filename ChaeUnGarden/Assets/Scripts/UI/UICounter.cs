using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICounter : MonoBehaviour
{
    [SerializeField] private UIShowCrafting craftingWindow;
    [SerializeField] private UIOrderTake takeNPC;
    [SerializeField] private PlaceManager placeManager;

    private void OnMouseDown()
    {
        if (!placeManager.Placeable)
        {
            if (takeNPC != null)
            {
                takeNPC.VisitCounter();
                takeNPC.ComeBack();
            }
            else
            {
                craftingWindow.SetWindow();
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            takeNPC = collision.GetComponent<UIOrderTake>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            takeNPC = null;
        }
    }
}
