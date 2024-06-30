﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<-groundHorizontalLength)
        {
            RepossiontBackground();
        }
    }
    private void RepossiontBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength*2 , 0);
        transform.position = (Vector2) transform.position+groundOffset;
            }
}
