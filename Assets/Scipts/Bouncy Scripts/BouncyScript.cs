using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyScript : MonoBehaviour
{

    public float force = 800f;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Tạo animatin
    IEnumerator AnimateBouncy()
    {
        anim.Play("Up");
        yield return new WaitForSeconds(.5f);
        anim.Play("Down");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().BouncePlayerWithBouncy(force);
            StartCoroutine(AnimateBouncy());
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
