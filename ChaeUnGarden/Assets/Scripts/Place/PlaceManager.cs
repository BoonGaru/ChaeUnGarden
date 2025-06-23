using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    public bool Placeable = false;

    [SerializeField] private GameObject[] UI;
    [SerializeField] private Placement placement;

    private int callUIIndex;

    void Start()
    {
        placement = this.GetComponent<Placement>();
    }

    public void StartPlacement(GameObject tile, int callDir)
    {
        foreach (var ui in UI)
        {
            ui.SetActive(false);
        }
        placement.StartSetPlace(tile);
    }
    public void EndPlacement()
    {
        UI[0].SetActive(true);
        UI[callUIIndex].SetActive(true);
    }
}
