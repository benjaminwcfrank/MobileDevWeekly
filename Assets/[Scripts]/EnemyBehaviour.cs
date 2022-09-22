using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float horzSpeed = 5.0f;
    public BoundryLock horzBoundry;
    public BoundryLock vertBoundry;
    // Start is called before the first frame update
    void Start()
    {
        var randomXPos = Random.Range(horzBoundry.xAxisLockMin, horzBoundry.xAxisLockMax);
        var randomYPos = Random.Range(vertBoundry.xAxisLockMin, vertBoundry.xAxisLockMax);
        transform.position = new Vector3(randomXPos, randomYPos, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var horzLength = horzBoundry.xAxisLockMax - horzBoundry.xAxisLockMin;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horzSpeed, horzLength) - horzBoundry.xAxisLockMax, transform.position.y, transform.position.z);
    }
}
