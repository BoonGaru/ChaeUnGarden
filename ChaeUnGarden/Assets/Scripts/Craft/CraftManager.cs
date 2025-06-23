using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public Flower selectFlower;
    public SelectFlowerSlot FlowerSlot;
    public int stepIndex;

    [SerializeField] CraftingBouquet crafting;

    public void SetFlower(Flower flower, SelectFlowerSlot slot)
    {
        selectFlower = flower;
        FlowerSlot = slot;
    }
}
