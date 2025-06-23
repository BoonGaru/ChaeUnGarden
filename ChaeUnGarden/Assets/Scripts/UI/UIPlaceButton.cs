using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlaceButton : MonoBehaviour
{
    [SerializeField] private Placement placement;
    [SerializeField] private int buttonIndex;

    private void OnMouseDown()
    {
        switch (buttonIndex)
        {
            case 0:
                {

                    break;
                }

            case 1:
                {
                    placement.EndSetPlace();
                    break;
                }
            case 2:
                {
                    placement.FlipTile();
                    break;
                }
            case 3:
                {
                    placement.CancelSetPlace();
                    break;
                }
        }
    }
}
