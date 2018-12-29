﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerMouse : MonoBehaviour
{
  void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
}
