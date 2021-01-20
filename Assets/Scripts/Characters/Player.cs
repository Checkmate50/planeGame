using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Player : Character
{
    [SerializeField]
    private string up;
    [SerializeField]
    private string down;
    [SerializeField]
    private string left;
    [SerializeField]
    private string right;
    [SerializeField]
    private string attack;

    [SerializeField]
    private float accelRatio;

    [SerializeField]
    private AttackPattern[] attackPatterns;

    protected struct AttackStatus
    { public float cd; public AttackPattern attackPattern; }

    private AttackStatus[] attackStatuses;

    private Vector2 attackDirection = Vector2.zero;
    Dictionary<string, InputState> inputs = new Dictionary<string, InputState>();
    Vector2 currVel = Vector2.zero;
    Vector2 currAccel = Vector2.zero;
    float inputAccel; // The actual acceleration of an input
    // if mu = max_accel*deltaTime / max_vel is in [-1, 1],
    // then velocity converges to max_vel
    // mu is inversely proportional to max velocity and 'slipperiness'
    float mu = 0.7f;

    public override void initialize(GameController gc)
    {
        base.initialize(gc);
        attackStatuses = new AttackStatus[attackPatterns.Length];
        for (int i = 0; i < attackPatterns.Length; i++)
        {
            var ap = Instantiate(attackPatterns[i]);
            ap.initialize(gc, this);
            attackStatuses[i].attackPattern = ap;
            attackStatuses[i].cd = ap.InitialDelay;
        }
    }

    protected override void Start()
    {
        base.Start();
        List<string> inputNames = new List<string>();
        inputNames.Add(up);
        inputNames.Add(down);
        inputNames.Add(left);
        inputNames.Add(right);
        inputNames.Add(attack);
        inputs = inputNames.ConvertAll((key_name) => new InputState(key_name))
            .ToDictionary(input => input.key_name, input => input);
    }

    protected override void Update()
    {
        base.Update();
        inputAccel = accelRatio * speed;
        checkInputs();
        checkAttack();
    }

    protected virtual void FixedUpdate()
    {
        checkMove();
    }

    class InputState
    {
        public string key_name;
        public bool state = false;
        public bool pressed = false;
        public bool unpressed = false;

        public InputState(string key_name) => this.key_name = key_name;

        public void update()
        {
            pressed = Input.GetKeyDown(key_name);
            unpressed = Input.GetKeyUp(key_name);
            state = pressed || (state && !unpressed);
        }

    }   

    private void checkInputs()
    {
        foreach (var input in inputs) { input.Value.update(); }
    }

    private void checkAttack()
    {
        for (int i = 0; i < attackStatuses.Length; i++)
        {
            if (inputs[attack].state)
            {
                if (attackStatuses[i].cd <= 0)
                {
                    attackStatuses[i].attackPattern.attack();
                    attackStatuses[i].cd += attackStatuses[i].attackPattern.AttackCooldown;
                }
                else
                    attackStatuses[i].cd -= Time.deltaTime;
            }
        }
    }

    private void checkMove()
    {
        kinematic_smoothing();
    }

    private void kinematic_smoothing()
    {
        Vector2 input_a =
            new Vector2(
                inputs[right].state ? inputAccel : inputs[left].state ? -inputAccel : 0,
                inputs[up].state ? inputAccel : inputs[down].state ? -inputAccel : 0);
        currAccel += input_a - (inputAccel / speed) * currAccel;
        currVel += currAccel * Time.deltaTime - mu * currVel;

        var screenPosition = gameController.MainCamera.WorldToScreenPoint(transform.position);
        var pixelWidth = gameController.MainCamera.pixelWidth;
        var pixelHeight = gameController.MainCamera.pixelHeight;
        if (currVel.y < 0 && screenPosition.y < pixelHeight / 50)
            currVel.y = 0;
        if (currVel.y > 0 && screenPosition.y > pixelHeight - pixelHeight / 50)
            currVel.y = 0;
        if (currVel.x < 0 && screenPosition.x < pixelWidth / 50)
            currVel.x = 0;
        if (currVel.x > 0 && screenPosition.x > pixelWidth - pixelWidth / 50)
            currVel.x = 0;

        if (inputs[right].state)
        {
            if (spriteRenderer.sprite == moveLeft)
                setSprite(moveUp);
            else
                setSprite(moveRight);
        }
        else if (inputs[left].state)
        {
            if (spriteRenderer.sprite == moveRight)
                setSprite(moveUp);
            else
                setSprite(moveLeft);
        }
        else
            GetComponent<SpriteRenderer>().sprite = moveUp;

        transform.position += (Vector3)currVel * Time.deltaTime;
    }
}