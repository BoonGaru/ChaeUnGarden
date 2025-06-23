using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class Item : ScriptableObject
{
    public string Name;
    public string Info;
    public ItemType ItemType;

    public bool IsLock;
    public int Amount;
    public int Price;

    public Sprite Icon;

    public int Index;

}
