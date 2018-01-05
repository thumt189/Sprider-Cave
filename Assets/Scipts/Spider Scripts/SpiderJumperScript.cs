using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumperScript : MonoBehaviour
{

    public float forceY = 350f;

    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Hàm thay đổi trạng thái tấn công.
    IEnumerator Attack()
    {
        // Random trong khoảng từ 5 đến 10 s chuyển trạng thái một lần.
        yield return new WaitForSeconds(Random.Range(5, 10));
        // Random độ cao nhảy trong khoảng từ 350 đến 500.
        forceY = Random.Range(350f, 500f);
        myBody.AddForce(new Vector2(0, forceY));

        anim.SetBool("Attack", true);

        // Mỗi lần chuyển trạng thái đợi 0.5s
        yield return new WaitForSeconds(0.5f);

        // Thực hiện
        StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Ground")
        {
            anim.SetBool("Attack", false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
