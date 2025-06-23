using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSetting : MonoBehaviour
{

    [SerializeField] private ItemGroup inventory;
    //[SerializeField] private TextAsset amountTextAsset;

    private string filepath = "Asset/Resources/Data/ItemData.csv";


    void Start()
    {
        LoadItem();
    }

    private  void LoadItem()
    {
        StreamReader textData = File.OpenText(filepath);
        //string[] lines = textData.Split('\n');

        for (int index = 0; index < inventory.group.Count; index++)
        {
            /*
             if (string.IsNullOrEmpty(lines))
                continue;
            */

            string[] lines = textData.ReadLine().Split('\n');
            string[] csvSlot = lines[index].Split(',');

            inventory.group[index].IsLock = Convert.ToBoolean(csvSlot[0]);
            inventory.group[index].Amount = Int32.Parse(csvSlot[1]);
        }
    }

    public void SaveItem()
    {
        StringBuilder builder = new StringBuilder();

        for (int index = 0; index < inventory.group.Count; index++)
        {
            string level = inventory.group[index].IsLock.ToString();
            string amount = inventory.group[index].Amount.ToString();

            string itemData = $"{level},{amount}\n";

            builder.Append(itemData);
        }

        StreamWriter outStream = File.CreateText(filepath);
        outStream.Write(builder);
        outStream.Close();
    }

}
