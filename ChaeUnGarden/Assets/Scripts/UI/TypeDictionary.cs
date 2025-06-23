using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TypeDictionary
{
    private Dictionary<BouquetType, string> bouquetType = new Dictionary<BouquetType, string>();
    private Dictionary<ColorType, string> colorType = new Dictionary<ColorType, string>();
    private Dictionary<SizeType, string> sizeType = new Dictionary<SizeType, string>();

    public TypeDictionary()
    {
        //상품 타입
        bouquetType.Add(BouquetType.bouquet, "꽃다발");
        bouquetType.Add(BouquetType.basket, "꽃바구니");
        bouquetType.Add(BouquetType.box, "꽃상자");

        //컬러
        colorType.Add(ColorType.white, "흰색");
        colorType.Add(ColorType.red, "빨간색");
        colorType.Add(ColorType.orange, "주황색");
        colorType.Add(ColorType.yellow, "노란색");
        colorType.Add(ColorType.green, "초록색");
        colorType.Add(ColorType.blue, "파란색");
        colorType.Add(ColorType.purple, "보라색");
        colorType.Add(ColorType.pink, "분홍색");
        colorType.Add(ColorType.black, "검은색");

        //사이즈
        sizeType.Add(SizeType.small, "작은 크기");
        sizeType.Add(SizeType.medium, "중간 크기");
        sizeType.Add(SizeType.large, "큰 크기");

    }

    public string BouquetTypeToString(BouquetType type)
    {
        return bouquetType[type];
    }
    public string ColorTypeToString(ColorType type)
    {
        return colorType[type];
    }
    public string SizeTypeToString(SizeType type)
    {
        return sizeType[type];
    }

}
