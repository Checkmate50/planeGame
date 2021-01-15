using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Spawner : EnemySpawner
{
    [SerializeField]
    protected Enemy basicPlane;
    [SerializeField]
    protected Enemy aimingPlane;
    [SerializeField]
    protected Enemy spreadPlane;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // Start with an empty wave for timing
        waves.Add(buildWave(2f, new List<Spawn>()));
        waves.Add(buildWave(15f, spawn1()));
        waves.Add(buildWave(15f, spawn2()));
        waves.Add(buildWave(15f, spawn3()));
        waves.Add(buildWave(10f, spawn4()));
        waves.Add(buildWave(20f, spawn5()));
        waves.Add(buildWave(15f, spawn6()));
        waves.Add(buildWave(15f, spawn7()));
        waves.Add(buildWave(15f, spawn8()));
        waves.Add(buildWave(25f, spawn9()));
        waves.Add(buildWave(0f, spawn10()));
    }

    protected List<Spawn> spawn1()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(basicPlane, .2f, 1.4f));
        spawns.Add(buildSpawn(basicPlane, .4f, 1.2f));
        spawns.Add(buildSpawn(basicPlane, .6f, 1.25f));
        spawns.Add(buildSpawn(basicPlane, .8f, 1.5f));
        spawns.Add(buildSpawn(basicPlane, .1f, 2.2f));
        spawns.Add(buildSpawn(basicPlane, .3f, 1.7f));
        spawns.Add(buildSpawn(basicPlane, .5f, 1.9f));
        spawns.Add(buildSpawn(basicPlane, .7f, 2.1f));
        spawns.Add(buildSpawn(basicPlane, .9f, 1.85f));
        return spawns;
    }

    protected List<Spawn> spawn2()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(basicPlane, .3f, 1.2f));
        spawns.Add(buildSpawn(basicPlane, .4f, 1.4f));
        spawns.Add(buildSpawn(basicPlane, .5f, 1.3f));
        spawns.Add(buildSpawn(basicPlane, .6f, 1.2f));
        spawns.Add(buildSpawn(basicPlane, .7f, 1.5f));
        spawns.Add(buildSpawn(spreadPlane, .35f, 1.3f));
        spawns.Add(buildSpawn(spreadPlane, .45f, 1.3f));
        spawns.Add(buildSpawn(spreadPlane, .55f, 1.3f));
        spawns.Add(buildSpawn(spreadPlane, .65f, 1.3f));
        return spawns;
    }

    protected List<Spawn> spawn3()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(basicPlane, .2f, 1.4f));
        spawns.Add(buildSpawn(basicPlane, .4f,  1.5f));
        spawns.Add(buildSpawn(basicPlane, .6f,  1.3f));
        spawns.Add(buildSpawn(basicPlane, .6f, 1.8f));
        spawns.Add(buildSpawn(basicPlane, .7f,  1.7f));
        spawns.Add(buildSpawn(spreadPlane, .3f, 1.3f));
        spawns.Add(buildSpawn(spreadPlane, .5f, 1.15f));
        spawns.Add(buildSpawn(spreadPlane, .6f, 1.2f));
        spawns.Add(buildSpawn(spreadPlane, .8f, 1.3f));
        return spawns;
    }

    protected List<Spawn> spawn4()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(basicPlane, .35f, 1.3f));
        spawns.Add(buildSpawn(basicPlane, .4f, 1.2f));
        spawns.Add(buildSpawn(basicPlane, .5f, 1.2f));
        spawns.Add(buildSpawn(basicPlane, .65f, 1.2f));
        spawns.Add(buildSpawn(basicPlane, .7f, 1.3f));
        spawns.Add(buildSpawn(aimingPlane, .2f, 1.3f));
        spawns.Add(buildSpawn(aimingPlane, .4f, 1.3f));
        spawns.Add(buildSpawn(aimingPlane, .6f, 1.3f));
        spawns.Add(buildSpawn(aimingPlane, .8f, 1.3f));
        return spawns;
    }

    protected List<Spawn> spawn5()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(basicPlane, .25f, 1.3f));
        spawns.Add(buildSpawn(basicPlane, .4f, 1.5f));
        spawns.Add(buildSpawn(basicPlane, .5f, 1.6f));
        spawns.Add(buildSpawn(basicPlane, .55f, 1.4f));
        spawns.Add(buildSpawn(basicPlane, .8f, 1.3f));
        spawns.Add(buildSpawn(basicPlane, .6f, 1.7f));
        spawns.Add(buildSpawn(basicPlane, .35f, 2.5f));
        spawns.Add(buildSpawn(basicPlane, .7f, 2.1f));
        spawns.Add(buildSpawn(basicPlane, .9f, 2.3f));
        spawns.Add(buildSpawn(aimingPlane, .2f, 1.2f));
        spawns.Add(buildSpawn(aimingPlane, .6f, 1.3f));
        spawns.Add(buildSpawn(aimingPlane, .8f, 1.25f));
        spawns.Add(buildSpawn(aimingPlane, .3f, 1.9f));
        spawns.Add(buildSpawn(aimingPlane, .5f, 1.85f));
        spawns.Add(buildSpawn(aimingPlane, .9f, 1.7f));
        return spawns;
    }

    protected List<Spawn> spawn6()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(spreadPlane, .2f, 1.3f));
        spawns.Add(buildSpawn(spreadPlane, .35f, 1.1f));
        spawns.Add(buildSpawn(spreadPlane, .55f, 1.2f));
        spawns.Add(buildSpawn(spreadPlane, .7f, 1.1f));
        spawns.Add(buildSpawn(aimingPlane, .3f, 1.1f));
        spawns.Add(buildSpawn(aimingPlane, .4f, 1.2f));
        spawns.Add(buildSpawn(aimingPlane, .5f, 1.25f));
        spawns.Add(buildSpawn(aimingPlane, .8f, 1.1f));
        return spawns;
    }

    protected List<Spawn> spawn7()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(spreadPlane, .3f, 1.1f));
        spawns.Add(buildSpawn(spreadPlane, .4f, 1.2f));
        spawns.Add(buildSpawn(spreadPlane, .6f, 1.1f));
        spawns.Add(buildSpawn(spreadPlane, .7f, 1.2f));
        spawns.Add(buildSpawn(aimingPlane, .1f, 1.2f));
        spawns.Add(buildSpawn(aimingPlane, .2f, 1.3f));
        spawns.Add(buildSpawn(aimingPlane, .8f, 1.4f));
        spawns.Add(buildSpawn(aimingPlane, .9f, 1.3f));
        return spawns;
    }

    protected List<Spawn> spawn8()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(basicPlane, .2f, 1.2f));
        spawns.Add(buildSpawn(basicPlane, .4f, 1.5f));
        spawns.Add(buildSpawn(basicPlane, .5f, 1.3f));
        spawns.Add(buildSpawn(basicPlane, .7f, 1.4f));
        spawns.Add(buildSpawn(basicPlane, .8f, 1.7f));
        spawns.Add(buildSpawn(spreadPlane, .3f, 1.1f));
        spawns.Add(buildSpawn(spreadPlane, .5f, 1.15f));
        spawns.Add(buildSpawn(aimingPlane, .6f, 1.15f));
        spawns.Add(buildSpawn(aimingPlane, .8f, 1.1f));
        return spawns;
    }

    protected List<Spawn> spawn9()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(basicPlane, .1f, 1.2f));
        spawns.Add(buildSpawn(basicPlane, .3f, 1.3f));
        spawns.Add(buildSpawn(basicPlane, .6f, 1.5f));
        spawns.Add(buildSpawn(basicPlane, .75f, 1.4f));
        spawns.Add(buildSpawn(basicPlane, .9f, 1.3f));
        spawns.Add(buildSpawn(basicPlane, .2f, 1.95f));
        spawns.Add(buildSpawn(basicPlane, .5f, 1.7f));
        spawns.Add(buildSpawn(basicPlane, .6f, 1.8f));
        spawns.Add(buildSpawn(basicPlane, .8f, 1.7f));
        spawns.Add(buildSpawn(basicPlane, .95f, 1.9f));
        spawns.Add(buildSpawn(spreadPlane, .3f, 1.1f));
        spawns.Add(buildSpawn(spreadPlane, .5f, 1.15f));
        spawns.Add(buildSpawn(aimingPlane, .6f, 1.15f));
        spawns.Add(buildSpawn(aimingPlane, .8f, 1.1f));
        spawns.Add(buildSpawn(aimingPlane, .2f, 1.4f));
        spawns.Add(buildSpawn(aimingPlane, .4f, 1.3f));
        spawns.Add(buildSpawn(spreadPlane, .8f, 1.35f));
        spawns.Add(buildSpawn(spreadPlane, .9f, 1.4f));
        return spawns;
    }

    protected List<Spawn> spawn10()
    {
        List<Spawn> spawns = new List<Spawn>();
        spawns.Add(buildSpawn(basicPlane, .5f, 1.2f));
        return spawns;
    }
}
