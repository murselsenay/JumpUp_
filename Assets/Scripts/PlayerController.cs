using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerBody;
    Transform playerTransform;
    Animator playerAnimController;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    public float speed=5f;
    private float horizontalVelocity;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        playerAnimController = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckInput();
        Move(horizontalVelocity);
    }

    public void MoveButtonHandler(float _velocity)
    {
        horizontalVelocity = _velocity;
        gameObject.GetComponent<Animator>().SetBool("canRun", true);
        if(_velocity==1)
            transform.localScale = new Vector2(1f, 1f);
        if (_velocity == -1)
            transform.localScale = new Vector2(-1f, 1f);
    }

    public void MoveButtonNormalizer()
    {
        horizontalVelocity = 0;
        gameObject.GetComponent<Animator>().SetBool("canRun", false);
    }

    public void Move(float _horizontal)
    {
        Vector2 _movementVelocity = playerBody.velocity;
        _movementVelocity.x = _horizontal * speed;
        playerBody.velocity = _movementVelocity;

    }
    void CheckInput()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        playerAnimController.SetFloat("velocityY", playerBody.velocity.y);
        /* if (Input.GetAxisRaw("Horizontal") < 0f)
         {
             transform.Translate(Vector3.left * Time.deltaTime);
             playerAnimController.SetBool("canRun", true);
             transform.localScale = new Vector2(-1f, 1f);
         }
         else if (Input.GetAxisRaw("Horizontal") > 0f)
         {
             transform.Translate(Vector3.right * Time.deltaTime);
             playerAnimController.SetBool("canRun", true);
             transform.localScale = new Vector2(1f, 1f);
         }
         else if (Input.GetAxisRaw("Horizontal") == 0f)
         {
             playerAnimController.SetBool("canRun", false);
         }
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheck.position, checkRadius);
    }

    public void Jump()
    {
        if (isGrounded)
            playerBody.velocity = Vector2.up * 7f;
    }

   
}
