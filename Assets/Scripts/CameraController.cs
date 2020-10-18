using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool canGoUp = false;
    public float cameraSpeed = 0.2f;
    public bool warn = false;

    public int floorCount;
    // Start is called before the first frame update
    void Start()
    {
        floorCount = floorCount - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (canGoUp)
        {
            GoUp();
        }


        if (warn)
        {
            WarningMessage();
            warn = false;
        }
    }


    void GoUp()
    {

        Vector2 move = new Vector2(0f, cameraSpeed);
        transform.Translate(move, Space.Self);
        if (transform.position.y > floorCount * 9f)
        {
            canGoUp = false;
        }
    }

    void WarningMessage()
    {
        TextController.instance.BlinkText("UP !");
        Invoke("MoveCameraUp", 3);

    }
    void MoveCameraUp()
    {
        canGoUp = true;
    }
}
