using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private TileManager tileManager;
    private TileData tileData;

    void Start()
    {
        tileManager = TileManager.Instance;
        tileManager.LoadGameData();

        tileData = TileManager.Instance.tileData;

    }
    public void SaveButton()
    {
        Debug.Log(tileData.FurnitureTiles.Count);
        tileManager.SaveGameData(tileData);
    }
}
