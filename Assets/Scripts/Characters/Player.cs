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
    private AttackPattern baseAttackPattern;

    private AttackPattern attackPattern;
    private float bcd = 0f;

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
        attackPattern = Instantiate(baseAttackPattern);
        attackPattern.initialize(gc, this);
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
        if (bcd <= 0)
        {
            if (inputs[attack].state)
            {
                attackPattern.attack();
                bcd = attackPattern.AttackCooldown;
            }
        }
        else
            bcd -= Time.deltaTime;
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

        transform.position += (Vector3)currVel * Time.deltaTime;
    }
}