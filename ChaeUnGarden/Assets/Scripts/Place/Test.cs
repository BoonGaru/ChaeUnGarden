using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IPointerDownHandler
{
    public Grid _Grid;
    public Tilemap _ChangedDisplayMap;
    public GameObject _Tile;
    public Transform miri;

    Vector3 ClickPos;
    bool isEnd = true;


    public void OnPointerDown(PointerEventData eventData)
    {
        //if (eventData.pointerCurrentRaycast.gameObject.tag == "TileObj")
        Debug.Log("클릭됨");
    }
    void Start()
    {
        _Grid = GameObject.Find("Grid").GetComponent<Grid>();
        //miri = GameObject.Find("newmiri").transform;
    }
    void Update()
    {
        if (!isEnd)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;

            ClickPos = WorldToIso(worldPos);
            miri.position = ClickPos;

            if (Input.GetMouseButtonDown(0) && !isEnd)
            {
                Instantiate(_Tile, ClickPos, Quaternion.identity);
                isEnd = true;
            }
        }
        
    }
    Vector3 WorldToIso(Vector3 worldPos)
    {
        int isoX = Mathf.RoundToInt((worldPos.x));
        float isoY = Mathf.RoundToInt((worldPos.y));

        if (Mathf.Abs(isoX )% 2 == 1) { isoY -= 0.5f; }

        return new Vector3(isoX, isoY, 0);  // Z는 2D 환경에서 0으로 설정
    }
    public void ended()
    {
        isEnd = true;
    }

}
