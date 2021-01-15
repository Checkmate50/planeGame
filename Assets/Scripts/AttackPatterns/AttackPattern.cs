using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackPattern : MonoBehaviour
{
    [SerializeField]
    protected float preAttackTime;
    [SerializeField]
    protected float postAttackTime;
    [SerializeField]
    protected float attackCooldown;
    [SerializeField]
    protected float attackCooldownVariance;
    [SerializeField]
    protected float initialDelay;
    protected GameController gameController;
    protected Character character;

    public virtual void initialize(GameController gc, Character c)
    {
        gameController = gc;
        character = c;
    }

    public float PreAttackTime { get { return preAttackTime; } }
    public float PostAttackTime { get { return postAttackTime; } }
    public float AttackCooldown { get { return attackCooldown; } }
    public float AttackCooldownVariance { get { return attackCooldownVariance; } }
    public float InitialDelay { get { return initialDelay; } }
    public abstract void attack();
    public abstract void startAttack();
    public abstract void endAttack();

    protected virtual void createProjectile(Projectile proj, 
        Vector2 direction, Vector2 offset)
    {
        Projectile result = Instantiate(proj, character.transform.position, 
            Quaternion.LookRotation(Vector3.forward, direction.normalized));
        result.initialize(gameController, character, offset);
    }
}
