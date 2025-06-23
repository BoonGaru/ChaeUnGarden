using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyText : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text shopMoneyText;

    private GameData data;

    void Start()
    {
        data = DataManager.Instance.gameData;
        SetMoneyText();
    }
    public void SetMoneyText()
    {
        moneyText.text = string.Format("{0:#,0}", data.money) + "G";
        shopMoneyText.text = string.Format("{0:#,0}", data.money) + "G";
    }
}
