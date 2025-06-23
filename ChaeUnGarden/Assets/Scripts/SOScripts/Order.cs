using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Order : ScriptableObject
{
    public Character Orderer;
    public Sprite[] OrdererImage;
    public string OrderName;
    [TextArea]
    public string[] OrderDetail; //시그니처, 상품타입, 0, 컬러, 1, 사이즈, 2, 예산, 3
    [TextArea]
    public string[] TakeDetail; // 0, 시그니처, 상품타입, 1, 컬러, 사이즈 2
    [TextArea]
    public string[] ReactionDetail;

    public BouquetType RequestType;
    public SizeType RequestSize;
    public ColorType ColorType;
    public FlowerType FlowerType;

    public Flower SignatureFlower;

    public int Budget;

    public int OrderIndex;
}
