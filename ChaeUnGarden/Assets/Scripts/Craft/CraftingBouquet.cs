using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingBouquet : MonoBehaviour
{
    [SerializeField] private KeepingBouquet keepingBouquet;
    [SerializeField] private Flower[] flowers;

    private Flower signatureFlower;
    private Decorate decorate;
    private Sprite decoFront;
    private Sprite decoBack;

    private BouquetType bouquetType;
    private SizeType sizeType;
    private ColorType colorType;
    private FlowerType flowerType;

    private string bouquetName;
    private int price;

    void Start()
    {
        InitBouquet();
    }

    public void InitBouquet()
    {
        flowers = new Flower[25];
    }
    public Flower SlotFill(int index)
    {
        if (flowers[index])
        {
            return flowers[index];
        }
        else
        {
            return null;
        }
    }
    public void AddFlower(Flower flower, int index)
    {
        if(flower.Amount > 0)
        {
            flower.Amount--;
            flowers[index] = flower;
        }
    }
    public void DeleteFlower(int index)
    {
        flowers[index].Amount++;
        flowers[index] = null;
    }
    public void SelectDecorate(Decorate deco)
    {
        if (deco.Amount > 0)
        {
            if (decorate != null)
            {
                decorate.Amount++;
            }

            decorate = deco;
            decorate.Amount--;

            decoFront = decorate.frontSprite;
            decoBack = decorate.backSprite;

            bouquetType = decorate.bouquetType;
        }
    }

    public void FInishedCraft()
    {
        signatureFlower = DecideSignature();

        sizeType = DecideSize();
        colorType = DesideColor();
        flowerType = DesideFlower();

        price = DecidePrice();

        Bouquet bouquet = new Bouquet
            (
            bouquetName, 
            bouquetType, 
            sizeType,
            colorType,
            flowerType,
            signatureFlower, 
            flowers,
            decoFront,
            decoBack,
            price
            );

        keepingBouquet.AddBouquet(bouquet);

        InitBouquet();
    }

    private SizeType DecideSize()
    {
        SizeType size = SizeType.small;
        int flowerCount = 0;

        foreach(var flower in flowers)
        {
            if(flower != null)
            {
                flowerCount++;
            }
        }

        flowerCount /= 10; //십자리수 구하기

        switch (flowerCount)
        {
            case 0:
                {
                    size = SizeType.small;
                    break;
                }
            case 1:
                {
                    size = SizeType.medium;
                    break;
                }
            case 2:
                {
                    size = SizeType.large;
                    break;
                }
        }
        return size;
    }
    private ColorType DesideColor()
    {
        return signatureFlower.colorType;
    }
    private FlowerType DesideFlower()
    {
        Dictionary<FlowerType, int> flowerAmount = new Dictionary<FlowerType, int>
        {
            { FlowerType.fresh, 0 },
            { FlowerType.dry, 0}
        };

        foreach (var flower in flowers)
        {
            if (flower)
            {
                if (flower.flowerType == FlowerType.fresh)
                {
                    flowerAmount[FlowerType.fresh]++;
                }
                else
                {
                    flowerAmount[FlowerType.dry]++;
                }
            }
        }

        if(flowerAmount[FlowerType.fresh] >= flowerAmount[FlowerType.dry])
        {
            return FlowerType.fresh;
        }
        else
        {
            return FlowerType.dry;
        }
    }
    private Flower DecideSignature()
    {
        Dictionary<string, int> flowerAmount = new Dictionary<string, int>();

        string flowerName = " ";
        int maxAmount = 0;

        foreach(var flower in flowers)
        {
            if (flower)
            {
                if (!flowerAmount.ContainsKey(flower.Name))
                {
                    flowerAmount.Add(flower.Name, 1);

                }
                else {
                    flowerAmount[flower.Name]++;
                }
            }
            
        }
        foreach (var flower in flowerAmount)
        {
            if (flower.Value >= maxAmount)
            {
                maxAmount = flower.Value;
                flowerName = flower.Key;
            }
        }
        foreach (var flower in flowers)
        {
            if (flower && flower.Name == flowerName)
            {
                return flower;
            }
        }
       return null;
    }
    private int DecidePrice()
    {
        int result = 0;

        foreach(var flower in flowers)
        {
            if (flower)
            {
                result += flower.Price;
            }
        }

        return result;
    }

}
