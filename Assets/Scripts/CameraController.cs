﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    Vector3 startPosition;
    public float cameraSpeed = 0.2f;
 

    public int floorCount;


    //ShakeEffect
    [Header("Shake Effect")]
    public GameObject tileParticle;
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.5f;

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        floorCount = floorCount - 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        


    }

    public void Warn()
    {
        Shake();
        WarningMessage();
    }




    public IEnumerator GoUp()
    {
        while (transform.position.y < floorCount * 10f)
        {
            Vector2 move = new Vector2(0f, cameraSpeed);
            transform.Translate(move, Space.Self);
            yield return new WaitForFixedUpdate();
        }

    }

    void WarningMessage()
    {
        TextController.instance.BlinkText("UP !");
        Invoke("MoveCameraUp", 4.5f);

    }
    public void MoveCameraUp()
    {
        StartCoroutine(GoUp());
    }

    void Shake()
    {
        startPosition = transform.position;
        InvokeRepeating("ProduceFallingTile", 0.5f, 0.5f);
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void ProduceFallingTile()
    {
        pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, 1.1f, 0f));
        pos.z = 0f;
        Instantiate(tileParticle, pos, Quaternion.identity);
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
        CancelInvoke("ProduceFallingTile");
        transform.position = startPosition;
    }

}
