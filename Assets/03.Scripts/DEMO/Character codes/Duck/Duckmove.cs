﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckmove : MonoBehaviour
{
    private Camera cameraa;
    private Animator animator;

    private bool isMove;
    private Vector3 destination;

    private void Awake()
    {
        cameraa = Camera.main;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            Debug.Log(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(cameraa.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }

        Move();
    }

    private void SetDestination(Vector3 dest)
    {
        destination = dest;
        isMove = true;
        animator.SetBool("isMove", true);
    }

    private void Move()
    {
        if (isMove)
        {
            var dir = destination - transform.position;
            transform.position += dir.normalized * Time.deltaTime * 5f;
        }

        if (Vector3.Distance(transform.position, destination) <= 0.1f)
        {
            isMove = false;
            animator.SetBool("isMove", false);
        }
    }
}
