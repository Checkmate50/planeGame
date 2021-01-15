using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightAttack : AttackPattern
{
    [SerializeField]
    protected Projectile projectile;
    [SerializeField]
    protected float aimVariance;
    [SerializeField]
    protected float angle; // Angle from Vector.down
    [SerializeField]
    protected Vector2 offset;

    public override void attack()
    {
        var dir = Util.Rotate(Vector2.down, angle);
        var aim = Random.Range(-aimVariance, aimVariance);
        dir = Util.Rotate(dir, aim);
        createProjectile(projectile, dir, offset);
    }

    public override void endAttack()
    { }

    public override void startAttack()
    { }
}
