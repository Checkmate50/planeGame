using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : Enemy
{
    [SerializeField]
    protected float bounceRatio;
    [SerializeField]
    protected float whereToStop;
    [SerializeField]
    protected float stopVariation;
    protected float yStop;

    protected override void Start()
    {
        base.Start();
        moveDir = Vector2.down;
        float pixelHeight = gameController.MainCamera.pixelHeight;
        yStop = gameController.MainCamera.ScreenToWorldPoint
            (new Vector2(0, pixelHeight - 
            (whereToStop + Random.Range(0, stopVariation) * pixelHeight))).y;
    }

    protected override void Update()
    {
        base.Update();
        if (moveDir.y != 0 && transform.position.y <= yStop)
        {
            if (Random.Range(0, 2) == 0)
                moveDir = Vector2.left;
            else
                moveDir = Vector2.right;
        }
    }

    protected override void move()
    {
        int pixelWidth = gameController.MainCamera.pixelWidth;
        if (moveDir.y == 0 && gameController.MainCamera.WorldToScreenPoint(transform.position).x
            < pixelWidth * bounceRatio)
            moveDir = Vector2.right;
        if (moveDir.y == 0 && gameController.MainCamera.WorldToScreenPoint(transform.position).x
            > pixelWidth * (1 - bounceRatio))
            moveDir = Vector2.left;
    }
}