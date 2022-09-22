using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    public float vertPos = -4;
    public BoundryLock boundries;
    private Camera CameraRef;
    public bool usingMobileInput = false;

    private void Start()
    {
        CameraRef = Camera.main;

        usingMobileInput = Application.platform == RuntimePlatform.Android ||
                           Application.platform == RuntimePlatform.IPhonePlayer;
    }

    // Update is called once per frame
    void Update()
    {



        if(usingMobileInput)
            TouchInput();
        else
            ConventionalInput();
  
        MoveChar();



    }

    public void ConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        //float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;


        //        transform.position = new Vector2(transform.position.x + x, transform.position.y + y);
        transform.position += new Vector3(x, 0.0f, 0.0f);
    }

    public void TouchInput()
    {
        foreach (var touch in Input.touches)
        {
            var destination = CameraRef.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, (Time.deltaTime * speed));
        }
    }
    

    public void MoveChar()
    {



        float clampedPos = Mathf.Clamp(transform.position.x, boundries.xAxisLockMin, boundries.xAxisLockMax);
        transform.position = new Vector2(clampedPos, vertPos);
    }
}
