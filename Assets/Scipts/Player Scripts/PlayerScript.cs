using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public float moveForce = 8f;
    public float jumpForce = 720f;
    public float maxVelocity = 5f;

    private Rigidbody2D myBody;
    private Animator anim;

    // Bg_nền
    public bool grounded;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveByKeyBoard();
    }

    void MoveByKeyBoard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float current_vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            if (current_vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }
            Vector3 tmp = transform.localScale;
            tmp.x = 1f;
            transform.localScale = tmp;

            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (current_vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }
            Vector3 tmp = transform.localScale;
            tmp.x = -1f;
            transform.localScale = tmp;

            anim.SetBool("Walk", true);
        }
        else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }
        // Bấm phím space để jump
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpForce;
            }
        }

        myBody.AddForce(new Vector2(forceX, forceY));
    }

    // Kiểm tra va chạm của Box Collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    public void BouncePlayerWithBouncy(float force)
    {
        if (grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0, force));
        }
    }
}
