using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalkerScript : MonoBehaviour
{
    [SerializeField]
    private Transform startPos, endPos = null;

    public bool is_collision;

    public float speed = 1f;

    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start()
    {

    }

    void ChangeDirection()
    {
        // Kiểm tra spider có va chạm với điểm đầu và điểm cuối layer ground.
        is_collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));

        // Vẽ đường kết lối giữa spider với gameobject end pos.
        Debug.DrawLine(startPos.position, endPos.position, Color.green);

        // Xác định chiều đi
        if (!is_collision)
        {
            Vector3 tmp = transform.localScale;
            if (tmp.x == 1f)
            {
                tmp.x = -1f;
            }
            else
            {
                tmp.x = 1f;
            }

            transform.localScale = tmp;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }

    void Move()
    {
        // Set tốc độ for spider walker
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
    
    // Kiểm tra va chạm với Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
