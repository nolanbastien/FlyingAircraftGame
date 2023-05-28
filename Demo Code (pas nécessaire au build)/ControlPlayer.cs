using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float jumpAmount = 10f;
    public float FlyAmount = 10f;
    public float jumpDelay = 0.1f;
    public float maxHeight = 6.0f;
    public bool canMove = true;
    public bool moveWithDelayedJumps = true;
    public bool gameStarted = false;

    private float lastTime;
    private float timeSinceLastJump;

    void Start()
    {
        lastTime = Time.time;
    }

    void FixedUpdate()
    {
        if (moveWithDelayedJumps) ControlWithDelayedJumps();
        else Control();
    }

    private void Control() {
        if (Input.GetKey(KeyCode.Space) && canMove && transform.position.y < maxHeight)
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
            rb.AddForce(Vector3.up * FlyAmount * Time.deltaTime * 1000f);
        }
    }

    private void ControlWithDelayedJumps() {
        timeSinceLastJump = Time.time - lastTime;

        if (Input.GetKey(KeyCode.Space) && timeSinceLastJump > jumpDelay && canMove && transform.position.y < maxHeight)
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
            rb.AddForce(Vector3.up * jumpAmount * Time.deltaTime * 1000f);

            lastTime = Time.time;
        }
    }
}
 