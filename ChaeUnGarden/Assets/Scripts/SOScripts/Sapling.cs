using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Sapling : ScriptableObject
{
    public Flower flower;
    public int growTime;

    public Sprite[] growSprite;

}
