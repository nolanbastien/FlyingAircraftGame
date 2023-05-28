using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovementManager : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool debugResetPosition = false;
    public float deceleration = 0.001f;

    public bool hasCrashed = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(- moveSpeed * Time.deltaTime, 0, 0);
        if (hasCrashed && moveSpeed > 0)
            moveSpeed = moveSpeed - deceleration;
        if (moveSpeed < 0)
            moveSpeed = 0;
    }

}
