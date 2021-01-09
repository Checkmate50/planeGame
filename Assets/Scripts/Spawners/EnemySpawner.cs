using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField]
    protected Enemy leadingEnemy;
    [SerializeField]
    protected Enemy straightShotEnemy;
    [SerializeField]
    protected Enemy tripleShotEnemy;
    [SerializeField]
    protected int spawnTimer;

    float spawnCD;

    protected new virtual void Start()
    {
        base.Start();
        spawnCD = spawnTimer;
    }

    protected new virtual void Update()
    {
        base.Update();
        spawnCD -= Time.deltaTime;
        if (spawnCD <= 0)
        {
            spawnCD = spawnTimer;
            Enemy enemy;
            if (Random.Range(0, 3) == 0)
                enemy = leadingEnemy;
            else if (Random.Range(0, 2) == 0)
                enemy = straightShotEnemy;
            else
                enemy = tripleShotEnemy;
            spawnEnemy(enemy, getAboveScreenPoint());
        }
    }

    protected Vector2 getAboveScreenPoint()
    {
        float pixelWidth = gameController.MainCamera.pixelWidth;
        return gameController.MainCamera.ScreenToWorldPoint(
                   new Vector2(Random.Range(0, pixelWidth),
                   gameController.MainCamera.pixelHeight * 5 / 4));
    }

    protected void spawnEnemy(Enemy enemy, Vector2 position)
    {
        Enemy result = Instantiate(enemy, position, Quaternion.identity);
        result.initialize(gameController);
        gameController.addEnemy(result);
    }
}