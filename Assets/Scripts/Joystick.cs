using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;
    public GameObject joystickTemp;

    bool canClickScreen = true;

    Animator playerAnimController;

    void Start()
    {
        playerAnimController = player.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (canClickScreen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

                circle.transform.position = pointA * 1;
                outerCircle.transform.position = pointA * 1;
                circle.GetComponent<SpriteRenderer>().enabled = true;
                outerCircle.GetComponent<SpriteRenderer>().enabled = true;
                joystickTemp.SetActive(false);
            }
            if (Input.GetMouseButton(0))
            {
                touchStart = true;
                pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            }
            else
            {
                touchStart = false;
            }
        }
        

    }
    private void FixedUpdate()
    {
        if (canClickScreen)
        {
            if (touchStart)
            {
                Vector2 offset = pointB - pointA;
                Vector2 direction = Vector2.ClampMagnitude(offset, 0.5f);
                if (direction.x > 0f)
                {
                    player.transform.localScale = new Vector2(1f, 1f);
                }
                else if (direction.x < 0f)
                {
                    player.transform.localScale = new Vector2(-1f, 1f);
                }


                moveCharacter(direction * 1);



                playerAnimController.SetBool("canRun", true);
                circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * 1;
            }
            else
            {
                playerAnimController.SetBool("canRun", false);
                circle.GetComponent<SpriteRenderer>().enabled = false;
                outerCircle.GetComponent<SpriteRenderer>().enabled = false;
                joystickTemp.SetActive(true);
            }
        }
        

    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(new Vector2(direction.x * speed, 0f) * Time.deltaTime);
    }


    public void EnterTheJumpButton()
    {
        canClickScreen = false;
    }
    public void ExitTheJumpButton()
    {
        canClickScreen = true;
    }
}