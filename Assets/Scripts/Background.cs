using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    protected Sprite[] sprites;
    [SerializeField]
    protected float speed;

    protected GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        if (sprites.Length > 0)
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        transform.Translate(-transform.up.normalized * speed / 10f, Space.World);
    }

    protected virtual void Update()
    {
        Vector3 camCheck = gameController.MainCamera.WorldToViewportPoint(transform.position);
        if (camCheck.y < -.5)
            Destroy(gameObject);
    }

    public virtual void initialize(GameController gc)
    {
        gameController = gc;
    }

    public float getSpeed()
    {
        return speed;
    }
}
