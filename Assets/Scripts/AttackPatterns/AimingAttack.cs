using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingAttack : AttackPattern
{
    [SerializeField]
    protected Projectile projectile;
    [SerializeField]
    protected int projectileCount;
    [SerializeField]
    protected float aimVariance;
    [SerializeField]
    protected bool canAttackBackward;

    protected Character target;

    protected void updateTarget()
    {
        foreach (GameObject o in gameController.Players)
        {
            target = o.GetComponent<Player>();
        }
    }

    public override void startAttack()
    {
        updateTarget();
    }
    public override void endAttack()
    { }
    public override void attack()
    {
        // Note that we don't account for attackTime since our weighting mostly clears it
        Vector2 dir = target.transform.position - character.transform.position;
        if (dir.y > 0 && !canAttackBackward)
            dir.y = -dir.y;
        dir = dir.normalized;
        Vector2 rotatedDir;
        for (int i = 0; i < projectileCount; i++)
        {
            rotatedDir = Util.Rotate(dir, Random.Range(-aimVariance, aimVariance));
            createProjectile(projectile, rotatedDir, Vector2.zero);
        }
    }
}
