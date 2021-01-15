using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppingPlane : BasePlane
{
    [SerializeField]
    protected float yStop;
    [SerializeField]
    protected float stopTime;

    protected enum MoveState { movingDown, stopped, movingOut }

    protected MoveState moveState;
    protected float stoppingTime;

    protected override void Start()
    {
        base.Start();
        moveState = MoveState.movingDown;
        stoppingTime = stopTime;
    }

    protected override void move()
    {
        base.move();
        if (moveState == MoveState.movingDown &&
            gameController.MainCamera.WorldToViewportPoint(transform.position).y < yStop)
        {
            moveDir = Vector2.zero;
            moveState = MoveState.stopped;
        }
        if (moveState == MoveState.stopped)
        {
            stoppingTime -= Time.deltaTime;
            if (stoppingTime <= 0)
            {
                moveState = MoveState.movingOut;
                baseSpeed *= 3;
                speed *= 3;
                if (gameController.MainCamera.WorldToViewportPoint(transform.position).x < .5)
                    moveDir = Vector2.left;
                else
                    moveDir = Vector2.right;
            }
        }
        if (moveState == MoveState.movingOut) {
            var curX = gameController.MainCamera.WorldToViewportPoint(transform.position).x;
            if (curX < -.1 || curX > 1.1)
                death();
        }
    }
}
