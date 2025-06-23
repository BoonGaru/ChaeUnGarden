using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class FurnitureTile
{
    public string TileName;
    public Vector2 TilePos;

    public FurnitureTile(string tile, Vector2 tilePos)
    {
        TileName = tile; 
        TilePos = tilePos;
    }
}

public class RuleTile : MonoBehaviour, ITile
{
    public const int contact = 4;
    public TileType TileType = TileType.furniture;

    [SerializeField] private Furniture furniture;
    [SerializeField] private TileData tileData;
    [SerializeField] private SpriteRenderer furnitureSprite;
    [SerializeField] private LayerMask furnitureLayer;

    private List<RuleTile> neighborhoodTile = new List<RuleTile>();
    private Vector2[] neighborhoodTilePos = new Vector2[contact]
    {
        new Vector2(1, 0.5f), //Top
        new Vector2(-1, -0.5f), //Bottom
        new Vector2(-1, 0.5f), //Left
        new Vector2(1, -0.5f) //Right
    };
    private bool[] IsContact = new bool[contact];

    void Start()
    {
        SaveTileData();
    }
    public void StartAction()
    {
        UpdateContactSprite();
    }
    public void SaveTileData()
    {
        FurnitureTile furnitureTile = new FurnitureTile(furniture.furnitureObj.name, this.transform.position);

        tileData = TileManager.Instance.tileData;
        tileData.FurnitureTiles.Add(furnitureTile);
    }
    public void UpdateContactSprite()
    {
        neighborhoodTile.Clear();
        UpdateSprite();

        foreach (RuleTile tile in GetNeighborhood())
        {
            tile.UpdateSprite();
        }
    }
    public void UpdateSprite()
    {
        neighborhoodTile = GetNeighborhood();

        foreach (Tiling tile in furniture.tileSprites)
        {
            if (IsContact.SequenceEqual(tile.isContact))
            {
                furnitureSprite.sprite = tile.sprite;
                transform.localScale = Vector3.one;
                Debug.Log(transform.localScale);
            }
        }
    }

    private List<RuleTile> GetNeighborhood()
    {
        neighborhoodTile.Clear();
        List<RuleTile> neighborhoodTiles = new List<RuleTile>();

        for (int pos = 0; pos < contact; pos++)
        {
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position + (Vector3)neighborhoodTilePos[pos], Vector2.zero, furnitureLayer);

            if (hit)
            {
                if (hit.collider.tag == this.transform.tag)
                {
                    IsContact[pos] = true;

                    RuleTile tile = hit.collider.GetComponent<RuleTile>();
                    neighborhoodTiles.Add(tile);
                }
            }
        }
        return neighborhoodTiles;
    }
    
}
