using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    Vector3 startPosition;
    bool canGoUp = false;
    public float cameraSpeed = 0.2f;
    public bool warn = false;

    public int floorCount;


    //ShakeEffect
    [Header("Shake Effect")]
    public GameObject tileParticle;
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
            Shake();
            WarningMessage();
            warn = false;
        }
    }

    public void Warn()
    {
        warn = true;
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
        Invoke("MoveCameraUp", 4.5f);

    }
    public void MoveCameraUp()
    {
        canGoUp = true;
    }

    void Shake()
    {
        Instantiate(tileParticle, new Vector3(transform.position.x, transform.position.y + 10f),Quaternion.identity);
        startPosition = transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermadiatePosition = transform.position;
        cameraIntermadiatePosition.x += cameraShakingOffsetX;
        cameraIntermadiatePosition.y += cameraShakingOffsetY;
        transform.position = cameraIntermadiatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        transform.position = startPosition;
    }
}
