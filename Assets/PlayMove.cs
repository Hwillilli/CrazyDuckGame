using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour
{
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;
    public bool isDamaged;
    public float speed;

    void Update()
    {
        Move();
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }
}
