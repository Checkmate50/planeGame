using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadAttack : AttackPattern
{
    [SerializeField]
    protected Projectile[] projectile;
    [SerializeField]
    protected float[] angle; // Angles from Vector.down

    public override void attack()
    {
        for (int i = 0; i < angle.Length; i++)
        {
            var dir = Util.Rotate(Vector2.down, angle[i]);
            createProjectile(projectile[i], dir, Vector2.zero);
        }
    }

    public override void endAttack()
    { }

    public override void startAttack()
    { }
}
