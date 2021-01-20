using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    [SerializeField]
    protected AttackPattern[] difficulty1AttackPatterns;
    [SerializeField]
    protected AttackPattern[] difficulty2AttackPatterns;
    [SerializeField]
    protected AttackPattern[] difficulty3AttackPatterns;
    [SerializeField]
    protected AttackPattern[] difficulty4AttackPatterns;
    [SerializeField]
    protected float clusteredAttackVariance;
    [SerializeField]
    protected int collisionDamage;
    [SerializeField]
    protected int score;

    protected enum AttackState { reloading, preAttack, postAttack }
    protected struct AttackPatternStatus
    {
        public AttackPattern attackPattern;
        public float attackCD;
        public AttackState attackState;
    }

    protected AttackPatternStatus[] attackStatuses;
    protected Vector3 movement = Vector3.zero;
    protected Vector2 attackDir = Vector3.zero;

    public override void initialize(GameController gc)
    {
        base.initialize(gc);
        List<AttackPattern> attackPatterns = new List<AttackPattern>();
        foreach (AttackPattern ap in difficulty1AttackPatterns)
            attackPatterns.Add(ap);
        if (gameController.Difficulty > 0)
        {
            foreach (AttackPattern ap in difficulty2AttackPatterns)
                attackPatterns.Add(ap);
            if (gameController.Difficulty > 1)
            {
                foreach (AttackPattern ap in difficulty3AttackPatterns)
                    attackPatterns.Add(ap);
                if (gameController.Difficulty > 2)
                {
                    foreach (AttackPattern ap in difficulty4AttackPatterns)
                        attackPatterns.Add(ap);
                }
            }
        }
        attackStatuses = new AttackPatternStatus[attackPatterns.Count];
        for (int i = 0; i < attackPatterns.Count; i++)
        {
            var attackPattern = Instantiate(attackPatterns[i]);
            attackPattern.initialize(gc, this);
            AttackPatternStatus status = new AttackPatternStatus();
            status.attackPattern = attackPattern;
            status.attackCD = attackPattern.InitialDelay;
            status.attackState = AttackState.reloading;
            attackStatuses[i] = status;
        }
    }

    protected override void Start()
    {
        base.Start();
        Debug.Log(gameController.Difficulty);
    }

    protected virtual void setSprite()
    {
        float moveAngle = Mathf.Atan2(moveDir.y, moveDir.x);
        if (moveAngle < Mathf.PI / 4f && moveAngle > -Mathf.PI / 4f)
            setSprite(moveRight);
        else if (moveAngle < Mathf.PI * 3f / 4f && moveAngle > Mathf.PI / 4f)
            setSprite(moveUp);
        else if (moveAngle > -Mathf.PI * 3f / 4f && moveAngle < -Mathf.PI / 4f)
            setSprite(moveDown);
        else
            setSprite(moveLeft);
    }

    protected abstract void move();

    protected override void Update()
    {
        base.Update();
        setupMove();
        checkAttack();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        Player asPlayer = other.GetComponent<Player>();
        if (asPlayer != null)
        {
            asPlayer.applyDamage(collisionDamage);
            death();
        }
    }

    protected void restartMoving()
    {
        speed = baseSpeed;
    }

    protected void stopMoving()
    {
        speed = 0;
    }

    protected void setupMove()
    {
        setSprite();
        move();
    }

    protected override void death()
    {
        if (health <= 0)
            gameController.addScore(score);
        // Go backwards to avoid messing up the list
        for (int i = attackStatuses.Length - 1; i >= 0; i--)
        {
            Destroy(attackStatuses[i].attackPattern.gameObject);
        }
        base.death();
    }

    protected void checkAttack()
    {
        if (attackStatuses == null)
            return;
        var cav = Random.Range(-clusteredAttackVariance, clusteredAttackVariance);  
        for (int i = 0; i < attackStatuses.Length; i++)
        {
            attackStatuses[i].attackCD -= Time.deltaTime;
            if (attackStatuses[i].attackCD <= 0)
            {
                if (attackStatuses[i].attackState == AttackState.preAttack)
                {
                    attackStatuses[i].attackPattern.attack();
                    attackStatuses[i].attackCD = attackStatuses[i].attackPattern.PostAttackTime;
                    attackStatuses[i].attackState = AttackState.postAttack;
                }
                else if (attackStatuses[i].attackState == AttackState.postAttack)
                {
                    attackStatuses[i].attackPattern.endAttack();
                    var variance = attackStatuses[i].attackPattern.AttackCooldownVariance;
                    attackStatuses[i].attackCD = attackStatuses[i].attackPattern.AttackCooldown
                        + Random.Range(-variance, variance) + cav;
                    attackStatuses[i].attackState = AttackState.reloading;

                }
                else if (attackStatuses[i].attackState == AttackState.reloading)
                {
                    attackStatuses[i].attackPattern.startAttack();
                    attackStatuses[i].attackCD = attackStatuses[i].attackPattern.PreAttackTime;
                    attackStatuses[i].attackState = AttackState.preAttack;
                }
            }
        }
    }
}