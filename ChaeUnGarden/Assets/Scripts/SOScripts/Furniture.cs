using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tiling
{
    public Sprite sprite;
    public bool[] isContact = new bool[4]; //top, bottom, left, right ¼ø¼­

    public bool isFlip;
}

[CreateAssetMenu]
public class Furniture : Item
{
    public GameObject furnitureObj;
    public Tiling[] tileSprites;
}
