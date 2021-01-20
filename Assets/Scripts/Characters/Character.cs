using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MovableObject
{
    [SerializeField]
    protected int maxHealth;
    [SerializeField]
    protected float baseSpeed;

    [SerializeField]
    protected Sprite moveDown = null;
    [SerializeField]
    protected Sprite moveLeft = null;
    [SerializeField]
    protected Sprite moveUp = null;
    [SerializeField]
    protected Sprite moveRight = null;

    protected float speed;
    protected int health;
    protected Vector3 moveDir;
    protected SpriteRenderer spriteRenderer;
    public Vector3 MoveDirection {
        get { return moveDir; }
    }
    public float Speed {
        get { return speed; }
    }
    public int Health {
        get { return health; }
    }

    public virtual void initialize(GameController gc) {
        gameController = gc;
    }

    protected new virtual void Start() {
        base.Start();
        speed = baseSpeed;
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update() {
        rb.velocity = getVelocity();
    }

    protected void setSprite(Sprite s)
    {
        if (s == null)
        {
            Debug.LogWarning("Will not switch to null sprite for " + gameObject);
            return;
        }
        spriteRenderer.sprite = s;
    }

    public Vector2 getVelocity() {
        return moveDir * speed / 10f;
    }

    // Note that negative damage is the same as healing
    // Returns true if this character was destroyed
    public bool applyDamage(int amount) {
        health -= amount;
        if (health > maxHealth)
            health = maxHealth;
        if (health <= 0) {
            death();
            return true;
        }
        return false;
    }

    protected virtual void death() {
        Enemy temp = gameObject.GetComponent<Enemy>();
        if (temp)
            gameController.enemyDeath(temp);
        Player temp2 = gameObject.GetComponent<Player>();
        if (temp2)
            gameController.playerDeath(temp2);
        Destroy(gameObject);
    }
}