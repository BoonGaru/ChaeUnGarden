using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Bouquet
{
    public string bouquetName;
    public BouquetType bouquetType;
    public SizeType sizeType;
    public ColorType colorType;
    public FlowerType flowerType;

    public Flower signatureFlower;
    public Flower[] flowers;

    public Sprite decoFrontSprite;
    public Sprite decoBackSprite;

    public int price;

    public Bouquet(
        string name, 
        BouquetType type, 
        SizeType size,
        ColorType color, 
        FlowerType flower, 
        Flower signature, 
        Flower[] flowerList,
        Sprite front,
        Sprite back,
        int value
        )
    {
        bouquetName = name;
        bouquetType = type;
        sizeType = size;
        colorType = color;
        flowerType = flower;
        signatureFlower = signature;
        flowers = flowerList;
        decoFrontSprite = front;
        decoBackSprite = back;
        price = value;
    }
}
