using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public string CharacterName;
    public string CharacterInfo;
    public int CharacterIndex;

    public int FriendShip;

    public Flower[] SignatureFlower;
    public Sprite FaceSprite;

    public Order Order;

    public GameObject CharacterModel;
}
