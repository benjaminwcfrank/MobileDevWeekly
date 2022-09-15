using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    public float vertPos = -4;
    public BoundryLock boundries;

    // Update is called once per frame
    void Update()
    {
        MoveChar();



    }

    public void MoveChar()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        //float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;


        //        transform.position = new Vector2(transform.position.x + x, transform.position.y + y);
        transform.position += new Vector3(x, 0.0f, 0.0f);
        float clampedPos = Mathf.Clamp(transform.position.x, boundries.xAxisLockMin, boundries.xAxisLockMax);
        transform.position = new Vector2(clampedPos, vertPos);
    }
}
