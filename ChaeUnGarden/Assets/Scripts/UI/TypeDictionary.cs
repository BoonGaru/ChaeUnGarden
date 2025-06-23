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
        //��ǰ Ÿ��
        bouquetType.Add(BouquetType.bouquet, "�ɴٹ�");
        bouquetType.Add(BouquetType.basket, "�ɹٱ���");
        bouquetType.Add(BouquetType.box, "�ɻ���");

        //�÷�
        colorType.Add(ColorType.white, "���");
        colorType.Add(ColorType.red, "������");
        colorType.Add(ColorType.orange, "��Ȳ��");
        colorType.Add(ColorType.yellow, "�����");
        colorType.Add(ColorType.green, "�ʷϻ�");
        colorType.Add(ColorType.blue, "�Ķ���");
        colorType.Add(ColorType.purple, "�����");
        colorType.Add(ColorType.pink, "��ȫ��");
        colorType.Add(ColorType.black, "������");

        //������
        sizeType.Add(SizeType.small, "���� ũ��");
        sizeType.Add(SizeType.medium, "�߰� ũ��");
        sizeType.Add(SizeType.large, "ū ũ��");

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
