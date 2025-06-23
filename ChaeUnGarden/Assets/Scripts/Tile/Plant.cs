using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

[System.Serializable]
public class PlantTile
{
    public string TileName;
    public Plant Plant;
    public Flower Flower;
    public int CurrentTime;

    public Vector2 TilePos;

    public PlantTile(string tile, Plant plant, Flower flower, int currentTime, Vector2 tilePos)
    {
        TileName = tile;
        Plant = plant;
        Flower = flower;
        CurrentTime = currentTime;
        TilePos = tilePos;
    }
}

public class Plant : MonoBehaviour, ITile
{
    public TileType TileType = TileType.flower;

    [SerializeField] private Flower flower;
    [SerializeField] private Sapling sapling;

    //[SerializeField] private GameObject infoWindow;
    [SerializeField] private TileData tileData;
    [SerializeField] private SpriteRenderer plantSprite;

    [SerializeField] private UIPlantInfo uiPlant;

    [SerializeField] private GameObject plantPrefab;

    private int currentTime;
    private bool isCompleteGrow = false;


    void Start()
    {
        tileData = TileManager.Instance.tileData;
        currentTime = sapling.growTime;
        plantSprite = GetComponent<SpriteRenderer>();

        SaveTileData();
    }
    public void StartAction()
    {
        StartCoroutine(GrowPlant());
    }
    public void LoadTile(Flower flower, int time)
    {
        this.flower = flower;
        currentTime = time;
    }
    public void SaveTileData()
    {
        PlantTile plantTile = new PlantTile(plantPrefab.name, this, flower, currentTime, this.transform.position);

        tileData = TileManager.Instance.tileData;
        tileData.PlantTiles.Add(plantTile);
        tileData.test = plantTile;
    }
    public void SetUIComponenet(UIPlantInfo ui)
    {
        uiPlant = ui;
    }
    public int GetCurrentTime()
    {
        return currentTime;
    }

    private void CompleteGrow()
    {
        flower.Amount += flower.levelDetail[flower.flowerLevel].getAmount;
        isCompleteGrow = false;
        StartCoroutine(GrowPlant());
    }
    private IEnumerator GrowPlant()
    {
        currentTime = sapling.growTime;
        int currentStep = sapling.growSprite.Length - 1;
        int stepLength = currentStep;

        while (currentTime > 0)
        {
            currentTime--;

            if ((currentTime * stepLength) / sapling.growTime <= currentStep)
            {
                currentStep--;
                plantSprite.sprite = sapling.growSprite[currentStep];
            }

            yield return new WaitForSeconds(1);
        }
        isCompleteGrow = true;
        uiPlant.ShowUI(transform, sapling); 
    }
    private void OnMouseDown()
    {
        if (isCompleteGrow)
        {
            CompleteGrow();
        }
        else
        {
            uiPlant.ShowUI(transform, sapling);
        }
    }

}
