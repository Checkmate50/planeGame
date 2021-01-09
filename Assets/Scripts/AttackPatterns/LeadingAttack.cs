using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadingAttack : AttackPattern
{
    [SerializeField]
    protected Projectile projectile;
    [SerializeField]
    protected int projectileCount;
    [SerializeField]
    protected float aimVariance;
    // Magic variable to control how much the attacker leads the player, a bit fiddly
    [SerializeField]
    protected float leadingFactor;

    protected Character target;
    protected Vector3 targetPrevTransform;

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
        targetPrevTransform = target.transform.position;
    }
    public override void endAttack()
    { }
    public override void attack()
    {
        // Note that we don't account for attackTime since our weighting mostly clears it
        Vector3 targetTransform = target.transform.position - targetPrevTransform;
        float foundSpeed = targetTransform.magnitude * leadingFactor / preAttackTime;
        Vector2 dir = target.transform.position - character.transform.position;
        // If the player moved for over 2/3 the prepping time, lead the player
        // Note that 30f is a magic number to account for the player's speed using different physics
        if (foundSpeed > target.Speed * 2f / 3f / 30f)
            dir = Util.CalcInterceptDir(dir, targetTransform,
                foundSpeed, projectile.MaxSpeed);
        if (dir.y > 0 && target.transform.position.y < 0)
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
