using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlane : Enemy
{
    protected override void move()
    {
        if (gameController.MainCamera.WorldToViewportPoint(transform.position).y < -.1)
            death();
    }

    protected override void Start()
    {
        base.Start();
        moveDir = Vector2.down;
    }
}