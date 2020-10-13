using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool canGoUp = false;
    public float cameraSpeed = 0.2f;
    public bool warn = false;
    // Start is called before the first frame update
    void Start()
    {

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
