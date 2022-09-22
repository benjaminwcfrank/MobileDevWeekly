using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float vertSpeed;
    public BoundryLock boundry;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        transform.position -= new Vector3(0, vertSpeed * Time.deltaTime);
    }

    public void CheckBounds()
    {
        if (transform.position.y < boundry.xAxisLockMin)
            ResetBackground();
    }

    public void ResetBackground()
    {
        transform.position = new Vector2(0, boundry.xAxisLockMax);
    }
}
