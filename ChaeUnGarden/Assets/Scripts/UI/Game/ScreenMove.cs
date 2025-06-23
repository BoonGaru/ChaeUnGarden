using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMove : MonoBehaviour
{
    //private float zoomSpeed = 0.008f;

    [SerializeField] private float moveSpeed;

    private Vector3 _tmpClickPos;
    private Vector3 _tempCameraPos;

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _tmpClickPos = Input.mousePosition;
            _tempCameraPos = Camera.main.transform.position;
        }

        else if (Input.GetMouseButton(0))
        {
            Vector3 movePos = Camera.main.ScreenToViewportPoint(_tmpClickPos - Input.mousePosition);
            Camera.main.transform.position = _tempCameraPos + (movePos * moveSpeed);
        }
    }

}
