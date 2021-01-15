using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    protected struct Spawn
    {
        public Enemy enemy;
        public float xRatio;
        public float yRatio;
    }

    protected Spawn buildSpawn(Enemy enemy, float xRatio, float yRatio)
    {
        Spawn toReturn;
        toReturn.enemy = enemy;
        toReturn.xRatio = xRatio;
        toReturn.yRatio = yRatio;
        return toReturn;
    }

    protected struct Wave
    {
        public float timeToNextWave;
        public List<Spawn> spawns;
    }

    protected Wave buildWave(float timeToNextWave, List<Spawn> spawns)
    {
        Wave toReturn;
        toReturn.timeToNextWave = timeToNextWave;
        toReturn.spawns = spawns;
        return toReturn;
    }

    protected List<Wave> waves;
    protected int waveIndex;
    protected float waveCD;

    protected new virtual void Start()
    {
        base.Start();
        waves = new List<Wave>();
        waveIndex = 0;
        waveCD = 0;
    }

    protected new virtual void Update()
    {
        base.Update();
        if (waveIndex < waves.Count) {
            waveCD -= Time.deltaTime;
            if (waveCD <= 0)
            {
                waveCD = waves[waveIndex].timeToNextWave;
                foreach (Spawn spawn in waves[waveIndex].spawns)
                {
                    spawnEnemy(spawn.enemy, getScreenPoint(spawn.xRatio, spawn.yRatio));
                }
                waveIndex++;
            }
        }
    }

    protected Vector2 getScreenPoint(float xRatio, float yRatio)
    {
        float pixelWidth = gameController.MainCamera.pixelWidth;
        float pixelHeight = gameController.MainCamera.pixelHeight;
        return gameController.MainCamera.ScreenToWorldPoint(
                    new Vector2(pixelWidth * xRatio, pixelHeight * yRatio));
    }

    protected void spawnEnemy(Enemy enemy, Vector2 position)
    {
        Enemy result = Instantiate(enemy, position, Quaternion.identity);
        result.initialize(gameController);
        gameController.addEnemy(result);
    }
}