using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Khi đạn va chạm vào Player thì Player + Bullet biến mất
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
