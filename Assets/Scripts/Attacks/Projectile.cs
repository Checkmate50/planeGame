using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Attack
{
    // Note that a negative value for damage provides healing
    [SerializeField]
    protected float maxSpeed;
    [SerializeField]
    protected float difficultySpeedScaling;

    protected float speed;

    public float MaxSpeed
    {
        get { return maxSpeed; }
    }

    public override void initialize(GameController gc, Character owner, Vector2 offset)
    {
        base.initialize(gc, owner, offset);
        maxSpeed = maxSpeed + difficultySpeedScaling * gc.Difficulty;
        speed = maxSpeed;
        banTarget(owner.GetInstanceID());
    }

    protected virtual void FixedUpdate()
    {
        transform.Translate(transform.up.normalized * speed / 10f, Space.World);
    }

    protected virtual void Update()
    {
        Vector3 camCheck = gameController.MainCamera.WorldToViewportPoint(transform.position);
        if (Mathf.Clamp01(camCheck.x) != camCheck.x || Mathf.Clamp01(camCheck.y) != camCheck.y)
            Destroy(gameObject);
    }

    protected override void checkCharacterCollision(Character other)
    {
        Destroy(gameObject);
    }
}