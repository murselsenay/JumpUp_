using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;


    Rigidbody2D playerBody;
    Animator playerAnimController;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    public float speed = 5f;
    private float horizontalVelocity;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
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
        if (_velocity == 1)
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

    public void PlayerGetDamage()
    {
        float[] forces = { -1000f, 1000f };
        playerBody.AddForce(new Vector2(forces[Random.Range(0, 2)], 250f), ForceMode2D.Force);
        if (DamageEffectCoroutine != null)
            StopCoroutine(DamageEffectCoroutine);
        DamageEffectCoroutine = StartCoroutine(DamageEffect());
    }


    Coroutine DamageEffectCoroutine;

    IEnumerator DamageEffect()
    {


        var count = 10;
        var tempColor = gameObject.GetComponent<SpriteRenderer>().color;
        while (count > 0)
        {
            tempColor.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = tempColor;
            yield return new WaitForSeconds(0.075f);
            tempColor.a = 1f;
            gameObject.GetComponent<SpriteRenderer>().color = tempColor;
            yield return new WaitForSeconds(0.075f);
            count--;
        }


    }

}
