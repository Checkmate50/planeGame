using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : Spawner
{
    [SerializeField]
    protected Background tile;

    protected float width;
    protected float height;
    protected float viewPortWidth;

    protected float tileCD;
    protected float screenTop;
    protected Camera cam;

    public override void initialize(GameController gc)
    {
        initialize(gc, new Vector2());
    }

    public override void initialize(GameController gc, Vector2 spawnCenterPoint)
    {
        base.initialize(gc, spawnCenterPoint);
        SpriteRenderer sr = tile.GetComponent<SpriteRenderer>();
        width = sr.sprite.bounds.size.x * tile.transform.localScale.x;
        height = sr.sprite.bounds.size.y * tile.transform.localScale.y;
        tileCD = 0;
        cam = gc.MainCamera;
        screenTop = cam.ViewportToWorldPoint(new Vector2(0, .5f + 
            cam.WorldToViewportPoint(new Vector2(0, height)).y)).y;
        viewPortWidth = cam.WorldToViewportPoint(new Vector2(width / 2, 0)).x - .5f;

        for (float h = screenTop; 
            cam.WorldToViewportPoint(new Vector2(0, h + height)).y > 0; h -= height)
        {
            for (float w = cam.ViewportToWorldPoint(new Vector2(Random.Range(-viewPortWidth, viewPortWidth), 0)).x; 
                cam.WorldToViewportPoint(new Vector2(w - width, 0)).x < 1; w += width)
            {
                createTile(new Vector2(w, h));
            }
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (tileCD <= 0)
        {
            for (float w = cam.ViewportToWorldPoint(new Vector2(Random.Range(-viewPortWidth, viewPortWidth), 0)).x;
                    cam.WorldToViewportPoint(new Vector2(w - width, 0)).x < 1; w += width)
            {
                createTile(new Vector2(w, screenTop));
            }
            // Dunno why the magic number, search me
            tileCD = tile.getSpeed() / 10f * height * 102f;
        }
        tileCD -= Time.deltaTime;
    }

    protected virtual void createTile(Vector2 position)
    {
        Background result = Instantiate(tile, position, Quaternion.identity);
        result.initialize(gameController);
    }
}
