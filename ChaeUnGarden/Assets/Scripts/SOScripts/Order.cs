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
    public string[] OrderDetail; //�ñ״�ó, ��ǰŸ��, 0, �÷�, 1, ������, 2, ����, 3
    [TextArea]
    public string[] TakeDetail; // 0, �ñ״�ó, ��ǰŸ��, 1, �÷�, ������ 2
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
