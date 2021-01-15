using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnerTemplate : EnemySpawner
{
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
        waves.Add(buildWave(0f, spawn7()));
        waves.Add(buildWave(0f, spawn8()));
        waves.Add(buildWave(0f, spawn9()));
        waves.Add(buildWave(0f, spawn10()));
        waves.Add(buildWave(0f, spawn11()));
        waves.Add(buildWave(0f, spawn12()));
        waves.Add(buildWave(0f, spawn13()));
        waves.Add(buildWave(0f, spawn14()));
        waves.Add(buildWave(0f, spawn15()));
        waves.Add(buildWave(0f, spawn16()));
        waves.Add(buildWave(0f, spawn17()));
        waves.Add(buildWave(0f, spawn18()));
        waves.Add(buildWave(0f, spawn19()));
        // Last wave has a useless timer
        waves.Add(buildWave(0f, spawn20()));
    }

    protected List<Spawn> spawn1()
    {
        List<Spawn> spawns = new List<Spawn>();
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

    protected List<Spawn> spawn7()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn8()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn9()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn10()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn11()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn12()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn13()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn14()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn15()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn16()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn17()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn18()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn19()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }

    protected List<Spawn> spawn20()
    {
        List<Spawn> spawns = new List<Spawn>();
        return spawns;
    }
}
