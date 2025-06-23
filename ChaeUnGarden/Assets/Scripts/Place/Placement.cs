using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class Placement : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private PlaceManager placeManager;
    [SerializeField] private GameObject tileObject;

    [SerializeField] private UIPlantInfo uiPlant;
    [SerializeField] private GameObject placeButton;
    [SerializeField] private LayerMask layer;

    private SpriteRenderer tileRenderer;

    private Vector3 clickPos;

    private Color translucentWhite = new Color(1, 1, 1, 0.7f);
    private Color translucentRed = new Color(1, 0, 0, 0.7f);

    private bool isOverlap = false;

    void Start()
    {
        placeManager = this.GetComponent<PlaceManager>();
    }
    
    public void StartSetPlace(GameObject tile)
    {
        tileObject = Instantiate(tile, clickPos, Quaternion.identity);

        StartCoroutine(SetPlace(tileObject));
        placeButton.SetActive(true);
        placeButton.transform.position = tileObject.transform.position;
    }
    public void EndSetPlace()
    {
        if (!isOverlap)
        {
            placeManager.Placeable = false;
            tileRenderer.color = Color.white;

            if (tileObject.CompareTag("Plant"))
            {
                Plant plant = tileObject.GetComponent<Plant>();
                plant.SetUIComponenet(uiPlant);
            }

            tileObject.GetComponent<ITile>().StartAction();
            tileObject.GetComponent<ITile>().SaveTileData();

            placeManager.EndPlacement();
            placeButton.SetActive(false);
        }
    }
    public void CancelSetPlace()
    {
        placeManager.Placeable = false;

        placeManager.EndPlacement();
        placeButton.SetActive(false);

        Destroy(tileObject);
    }
    public void FlipTile()
    {
        tileRenderer.flipX = !tileRenderer.flipX;
        tileObject.transform.localScale = new Vector3(-1, 1, 1);
    }

    private IEnumerator SetPlace(GameObject plantTile)
    {
        placeManager.Placeable = true;

        tileRenderer = plantTile.GetComponent<SpriteRenderer>();
        tileRenderer.color = translucentWhite;

        while (placeManager.Placeable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPos.z = 0;

                clickPos = WorldToIso(worldPos);
                plantTile.transform.position = clickPos;

                placeButton.transform.position = clickPos;

                hit = Physics2D.Raycast(clickPos, transform.forward, layer);

                if (hit)
                {
                    if (!(hit.collider.CompareTag("Shelf") && tileObject.CompareTag("Plant")) 
                        || !hit.collider.CompareTag("ObjButton")
                        || hit.collider.tag != tileObject.tag)
                    {
                        tileRenderer.color = translucentRed;
                        isOverlap = true;
                    }
                }
                else
                {
                    tileRenderer.color = translucentWhite;
                    isOverlap = false;
                }

                tileRenderer.sortingOrder = (int)(-clickPos.y * 2);
            }

            yield return new WaitForFixedUpdate();
        }
    }
    private Vector3 WorldToIso(Vector3 worldPos)
    {
        int isoX = Mathf.RoundToInt((worldPos.x));
        float isoY = Mathf.RoundToInt((worldPos.y));

        if (Mathf.Abs(isoX) % 2 == 1) { isoY -= 0.5f; } //ISO ÁÂÇ¥ º¸Á¤

        return new Vector3(isoX, isoY + 1, 0);  
    }
}
