using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    protected GameController gameController;
    protected int initializedFrameCount;
    protected Vector2 centerPoint;

    public virtual void initialize(GameController gc)
    {
        initialize(gc, new Vector2());
    }

    public virtual void initialize(GameController gc, Vector2 spawnCenterPoint)
    {
        gameController = gc;
        centerPoint = spawnCenterPoint;
    }

    protected virtual void Start()
    {
        initializedFrameCount = Time.frameCount;
    }

    protected virtual void Update()
    {
        checkTime(Time.frameCount - initializedFrameCount);
    }

    protected virtual void checkTime(int timer) { }
}