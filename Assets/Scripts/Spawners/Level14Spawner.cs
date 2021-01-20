using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level14Spawner : EnemySpawner
{
    [SerializeField]
    protected Enemy basicPlane;

    [SerializeField]
    protected Enemy spreadPlane;

    [SerializeField]
    protected Enemy aimingPlane;

    [SerializeField]
    protected Enemy chargePlane;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // Start with an empty wave for timing
        waves.Add(buildWave(0f, new List<Spawn>()));
        waves.Add(buildWave(0f, spawn1()));
        waves.Add(buildWave(0f, spawn2()));
        waves.Add(buildWave(0f, spawn3()));
        waves.Add(buildWave(0f, spawn4()));
        waves.Add(buildWave(0f, spawn5()));
        waves.Add(buildWave(0f, spawn6()));
    }

    protected List<Spawn> spawn1()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(basicPlane, .2f, 1.4f));
        return spawns;
    }

    protected List<Spawn> spawn2()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn3()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn4()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn5()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn6()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }
}
