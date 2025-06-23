using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;

    [SerializeField] private Vector2 counterPos;
    private Vector2 direction;
    void Start()
    {
        direction = Vector2.zero;
        GoCounter();
    }

    void FixedUpdate()
    {
        rigid.velocity = direction * 0.2f;

        if ((Vector3)counterPos == this.transform.position)
        {
            direction = Vector2.zero;
        }
    }
    public void GoCounter()
    {
        direction = (Vector3)counterPos - this.transform.position;

        
    }
}
