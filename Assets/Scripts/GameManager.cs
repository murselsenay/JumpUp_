using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MoveCameraUp", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void MoveCameraUp()
    {
        CameraController.instance.Warn();
    }

}
