using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    static GameObject container;

    static TileManager instance;
    public static TileManager Instance
    {
        get
        {
            if (!instance)
            {
                container = new GameObject();
                container.name = "TileManager";
                instance = container.AddComponent(typeof(TileManager))as TileManager;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }

    string TileDataFileName = "TileData.json";

    public TileData tileData = new TileData();
    public bool isNew = true;

    // 불러오기
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + TileDataFileName;

        if (File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            tileData = JsonUtility.FromJson<TileData>(FromJsonData);
            Debug.Log("불러오기 완료");
            isNew = false;

            LoadTile();
        }
        else
        {
            Debug.Log("불러오기 실패");
            isNew = true;
        }
    }

    public void SaveGameData(TileData tileData)
    {
        SaveTile(tileData);

        foreach (FurnitureTile tile in tileData.FurnitureTiles)
        {
            //tile.CurrentTime = tile.Plant.GetCurrentTime();
            Debug.Log(tile.TilePos);

        }

        string ToJsonData = JsonUtility.ToJson(tileData, true);
        Debug.Log(ToJsonData);
        string filePath = Application.persistentDataPath + "/" + TileDataFileName;

        //string jsonString = JsonConvert.SerializeObject(tileData);

        File.WriteAllText(filePath, ToJsonData);

        
    }
    public void DeleteGameData()
    {
        string filePath = Application.persistentDataPath + "/" + TileDataFileName;
        System.IO.File.Delete(filePath);

    }

    private void LoadTile()
    {
        
        foreach (PlantTile tile in tileData.PlantTiles)
        {
            GameObject setTile = Resources.Load<GameObject>("TilePrefab/" + tile.TileName);

            if(setTile != null)
            {
                Instantiate(setTile, tile.TilePos, Quaternion.identity);
                tile.Plant = setTile.GetComponent<Plant>();
            }
            tile.Plant.LoadTile(tile.Flower, tile.CurrentTime);
        }
        
        foreach (FurnitureTile tile in tileData.FurnitureTiles)
        {
            GameObject setTile = Resources.Load<GameObject>("TilePrefab/" + tile.TileName);
            Debug.Log(tile.TileName);
            if (setTile != null)
            {
                Instantiate(setTile, tile.TilePos, Quaternion.identity);
            }
        }
    }
    public void SaveTile(TileData data)
    {
        foreach (PlantTile tile in instance.tileData.PlantTiles)
        {
            tile.CurrentTime = tile.Plant.GetCurrentTime();
        }
        Debug.Log(tileData.FurnitureTiles.Count + "SaveTile");
    }

}
